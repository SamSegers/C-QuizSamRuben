
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
    public class ViewModelPlayQuiz : ViewModelBase
    {
        private Context DbContext;
        private int _QuizId;
        private string _Answer1;
        private string _Answer2;
        private string _Answer3;
        private string _Answer4;

        public ViewModelPlayQuiz()
        {

            DbContext = new Context();
            var QuestionList = DbContext.Vragen.ToList().Select(Q => new QuestionsViewModel(Q));
            Questions = new ObservableCollection<QuestionsViewModel>(QuestionList);


        }
        //Where(Q => Q.QuizId == QuizId)
        public ObservableCollection<QuestionsViewModel> Questions
        {
            get;
            set;
        }
        public ObservableCollection<AnswerViewModel> Answers
        {
            get;
            set;
        }
        public int QuizId
        {
            get
            {
                return _QuizId;
            }
            set
            {
                var _OldValue = _QuizId;
                _QuizId = value;
                RaisePropertyChanged(QuizId.ToString(), _OldValue, value, true);

                for (int i = 0; i < Questions.Count(); i++)
                {
                    if (Questions[i].Question.QuizId != _QuizId)
                    {
                        Questions.RemoveAt(i);
                        i = -1;
                    }
                }


            }
        }
        public void initAnswerList(int vraagId)
        {
            var AnswerList = DbContext.Antwoorden.ToList().Where(A => A.VraagId == vraagId).Select(A => new AnswerViewModel(A));
            Answers = new ObservableCollection<AnswerViewModel>(AnswerList);
        }
        public string Answer1
        {
            get
            {
                return _Answer1;
            }


        }
        public string Answer2
        {
            get
            {
                return _Answer2;
            }


        }
        public string Answer3
        {
            get
            {
                return _Answer3;
            }


        }
        public string Answer4
        {
            get
            {
                return _Answer4;
            }


        }
        public void SelectAnswer()
        {
            try
            {

            }
            catch
            {
            }
        }
        private bool CanSelectAnswer()
        {

            return true;

        }
        public ICommand SelectAnAnswer
        {
            get;
            set;
        }

    }
}