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
    public class ViewModelSelectQuiz : ViewModelBase
    {
        private Context DbContext;

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
        public ViewModelSelectQuiz()
        {
            DbContext = new Context();
            var QuizList = DbContext.Quizen.ToList().Select(Q => new QuizViewModel(Q));
            Quizes = new ObservableCollection<QuizViewModel>(QuizList);
            PlayAQuiz = new RelayCommand(PlayQuiz, CanPlayQuiz);

        }

        public void PlayQuiz()
        {
            try
            {
              Views.ViewPlayQuiz VPQ = new Views.ViewPlayQuiz(this._SelectedQuiz.Id);
                //Views.ViewPlayQuiz VPQ = new Views.ViewPlayQuiz();
                VPQ.Show();
            }
            catch
            {
            }
        }
        private bool CanPlayQuiz()
        {

            return true;

        }
        public ICommand PlayAQuiz
        {
            get;
            set;
        }

        public ObservableCollection<QuizViewModel> Quizes
        {
            get;
            set;
        }

    }
}
