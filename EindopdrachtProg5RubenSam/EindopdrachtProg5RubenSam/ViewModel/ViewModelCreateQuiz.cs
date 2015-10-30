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
        public ViewModelCreateQuiz()
        {
            this._QuizName = "Quiz naam hier invullen";
            DbContext = new Context();
            CreateQuiz = new RelayCommand(AddQuiz,CanAddQuiz);
            OpenEditQuiz = new RelayCommand(OpenQuiz,CanOpenQuiz);

            var QuizList = DbContext.Quizen.ToList().Select(Q => new QuizViewModel(Q));
            Quizes = new ObservableCollection<QuizViewModel>(QuizList);
        } 

        private void AddQuiz()
        {
            Quiz Q = new Quiz();
            Q.Name = _QuizName;
            DbContext.Quizen.Add(Q);
            DbContext.SaveChanges();
            this._QuizName = "";
        }

        private void OpenQuiz()
        { 
        
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

        public string QuizName
        {
            get { return _QuizName; }
            set { var _OldValue = _QuizName; _QuizName = value; RaisePropertyChanged(QuizName, _OldValue, value, true); }
        }

        public ICommand CreateQuiz { get; set; }

        public ICommand OpenEditQuiz { get; set; }

        public ObservableCollection<QuizViewModel> Quizes { get; set; }

    }
}
