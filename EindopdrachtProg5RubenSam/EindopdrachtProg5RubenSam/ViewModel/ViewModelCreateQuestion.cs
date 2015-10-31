using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace EindopdrachtProg5RubenSam.ViewModel
{
    public class ViewModelCreateQuestion : ViewModelBase
    {
        private Context DbContext;
        private string _QuizName;
        private string _VraagNaam;
        private int _QuizId;

        private QuestionsViewModel _SelectedQuestion;
        public QuestionsViewModel SelectedQuestion
        {
            get
            {
                return _SelectedQuestion;
            }
            set
            {
                _SelectedQuestion = value;
                RaisePropertyChanged();
            }
        }

        public ViewModelCreateQuestion()
        {
            
            DbContext = new Context();
            /*this._QuizName = "Quiz naam hier invullen";
            CreateQuiz = new RelayCommand(AddQuiz,CanAddQuiz);
            OpenEditQuiz = new RelayCommand(OpenQuiz,CanOpenQuiz);
            DeleteQuiz = new RelayCommand(RemoveQuiz, CanDeleteQuiz);

            var QuizList = DbContext.Quizen.ToList().Select(Q => new QuizViewModel(Q));
            Quizes = new ObservableCollection<QuizViewModel>(QuizList);*/

            CreateQuestion = new RelayCommand(CreateNewQuestion,CanCreateQuestion);
            UpdateQuizName = new RelayCommand(UpdateQuiz, CanUpdateQuiz);
        }

        private void CreateNewQuestion()
        {
            Vraag V = new Vraag();
            V.Name = _VraagNaam;
            V.QuizId = _QuizId;
            
            DbContext.Vragen.Add(V);
            DbContext.SaveChanges();
            this._VraagNaam = "";

            var QuestionList = DbContext.Vragen.ToList().Select(Q => new QuestionsViewModel(Q));
            QuestionList = new ObservableCollection<QuestionsViewModel>(QuestionList);
        }

        private bool CanCreateQuestion()
        {
            return true;
        }

        private void UpdateQuiz()
        {
            
        }

        private bool CanUpdateQuiz()
        {
            return true;
        }

        public string QuizName
        {
            get { return _QuizName; }
            set { var _OldValue = _QuizName; _QuizName = value; RaisePropertyChanged(QuizName, _OldValue, value, true); }
        }

        public ICommand CreateQuestion { get; set; }
        public ICommand UpdateQuizName { get; set; }

        public ObservableCollection<QuestionsViewModel> Questions { get; set; }
    }
}
