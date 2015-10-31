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

            */

            CreateQuestion = new RelayCommand(CreateNewQuestion,CanCreateQuestion);
            UpdateQuizName = new RelayCommand(UpdateQuiz, CanUpdateQuiz);
            OpenEditQuestion = new RelayCommand(EditQuestion,CanEditQuestion);
            DeleteQuestion = new RelayCommand(RemoveQuestion,CanDeleteQuestion);

            var QuestionList = DbContext.Vragen.ToList().Select(Q => new QuestionsViewModel(Q));
            Questions = new ObservableCollection<QuestionsViewModel>(QuestionList);
        }

        private void CreateNewQuestion()
        {
           
            Vraag V = new Vraag();
            V.Name = _VraagNaam;
            V.QuizId = _QuizId;
            V.Category = "Leeg";
            try
            {
                DbContext.Vragen.Add(V);
                DbContext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                   // throw raise;
                }

            }
            this.VraagName = "";
                        
            var QuestionList = DbContext.Vragen.ToList().Select(Q => new QuestionsViewModel(Q));
            QuestionList = new ObservableCollection<QuestionsViewModel>(QuestionList);
        }

        private bool CanCreateQuestion()
        {
            return true;
        }

        private void UpdateQuiz()
        {
            try
            {
                DbContext.Quizen.Where(Q => Q.Id == this._QuizId).First().Name = this._QuizName;
                DbContext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                    //throw raise;
                }
            }
        }

        private bool CanUpdateQuiz()
        {
            return true;
        }

        private void EditQuestion()
        {
            try
            {
                Views.ViewEditVraag VEV = new Views.ViewEditVraag(this.SelectedQuestion.Id,this.SelectedQuestion.Name);
                VEV.Show();
            }
            catch { }
        }

        private bool CanEditQuestion()
        {
            return true;
        }

        private void RemoveQuestion()
        {
            try
            {
                DbContext.Vragen.Remove(SelectedQuestion.Question);
                DbContext.SaveChanges();
                RaisePropertyChanged();
            }
            catch
            { }
        }

        private bool CanDeleteQuestion()
        {
            return true;
        }


        public string VraagName
        {
            get { return _VraagNaam; }
            set { var _OldValue = _VraagNaam; _VraagNaam = value; RaisePropertyChanged(VraagName,_OldValue,value,true); }
        }

        public string QuizName
        {
            get { return _QuizName; }
            set { var _OldValue = _QuizName; _QuizName = value; RaisePropertyChanged(QuizName, _OldValue, value, true); }
        }

        public int QuizId
        {
            get { return _QuizId; }
            set { var _OldValue = _QuizId; _QuizId = value; RaisePropertyChanged(QuizId.ToString(), _OldValue, value, true);
                    var QuestionList = DbContext.Vragen.ToList().Select(Q => new QuestionsViewModel(Q)).Where(Q => Q.Question.Id == _QuizId);
                    QuestionList = new ObservableCollection<QuestionsViewModel>(QuestionList);
            }
        }
        
        public ICommand CreateQuestion { get; set; }
        public ICommand UpdateQuizName { get; set; }

        public ICommand OpenEditQuestion { get; set; }

        public ICommand DeleteQuestion { get; set; }

        public ObservableCollection<QuestionsViewModel> Questions { get; set; }
    }
}
