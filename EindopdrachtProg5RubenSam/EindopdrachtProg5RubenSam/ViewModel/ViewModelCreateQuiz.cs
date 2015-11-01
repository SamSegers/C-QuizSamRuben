using EindopdrachtProg5RubenSam.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EindopdrachtProg5RubenSam.ViewModel
{
    public class ViewModelCreateQuiz : ViewModelBase
    {
        private Context DbContext;
        private string _QuizName;

        private QuizViewModel _SelectedQuiz;
        public QuizViewModel SelectedQuiz
        {
            get
            {
                return _SelectedQuiz;
            }
            set
            {
                _SelectedQuiz = value;
                RaisePropertyChanged();
            }
        }
        public ViewModelCreateQuiz()
        {
            this._QuizName = "Quiz naam hier invullen";
            DbContext = new Context();
            CreateQuiz = new RelayCommand(AddQuiz,CanAddQuiz);
            OpenEditQuiz = new RelayCommand(OpenQuiz,CanOpenQuiz);
            DeleteQuiz = new RelayCommand(RemoveQuiz, CanDeleteQuiz);
            PlaySelectedQuiz = new RelayCommand(PlayQuiz,CanPlayQuiz);

            var QuizList = DbContext.Quizen.ToList().Select(Q => new QuizViewModel(Q));
            Quizes = new ObservableCollection<QuizViewModel>(QuizList);
        } 

        private void AddQuiz()
        {
            try
            {
                Quiz Q = new Quiz();
                Q.Name = _QuizName;
                DbContext.Quizen.Add(Q);
                DbContext.SaveChanges();
                QuizViewModel QVM = new QuizViewModel(Q);
                this.Quizes.Add(QVM);
                RaisePropertyChanged("Quizes");
            }
            catch { }
        }

        private void OpenQuiz()
        {
            try
            {
                Views.ViewEditQuiz VEQ = new Views.ViewEditQuiz(this._SelectedQuiz.Id, this._SelectedQuiz.Name);
                VEQ.Show();
            }
            catch { }
            
        }

        // Moet nog refreshen
        private void RemoveQuiz()
        {
            try
            {
                DbContext.Quizen.Remove(SelectedQuiz.Quiz);
                DbContext.SaveChanges();
                Quizes.Remove(SelectedQuiz);
                RaisePropertyChanged("Quizes");
                
            }
            catch
            { }
        }

        private void PlayQuiz()
        {
            try
            {
                if (this.SelectedQuiz != null)
                {
                    ViewPlayQuiz VPQ = new ViewPlayQuiz(this.SelectedQuiz.Id, this.SelectedQuiz.Name);
                    VPQ.Show();
                }
            }
            catch { }
        }

        private bool CanAddQuiz()
        {
            /* todo: uitbreiden of er echt een naam is voor de quiz etc. */
            return true;
        }

        private bool CanOpenQuiz()
        {
            return true;
        }

        private bool CanDeleteQuiz()
        {
            return true;
        }

        private bool CanPlayQuiz()
        {
            return true;
        }

        public string QuizName
        {
            get { return _QuizName; }
            set { var _OldValue = _QuizName; _QuizName = value; RaisePropertyChanged(QuizName, _OldValue, value, true); }
        }

        public ICommand CreateQuiz { get; set; }

        public ICommand OpenEditQuiz { get; set; }

        public ICommand DeleteQuiz { get; set; }

        public ICommand PlaySelectedQuiz { get; set; }

        public ObservableCollection<QuizViewModel> Quizes { get; set; }

    }
}
