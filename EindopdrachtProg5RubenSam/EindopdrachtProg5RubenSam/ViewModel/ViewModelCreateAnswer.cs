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
    public class ViewModelCreateAnswer : ViewModelBase
    {
        private Context DbContext;
        private string _QuestionName;
        private string _AnswerName;
        private int _QuestionId;
        private string _Category;

        private AnswerViewModel _SelectedAnswer;
        public AnswerViewModel SelectedAnswer
        {
            get
            {
                return _SelectedAnswer;
            }
            set
            {
                _SelectedAnswer = value;
                RaisePropertyChanged();
            }
        }

        public ViewModelCreateAnswer()
        {
            DbContext = new Context();

            UpdateQuestionName = new RelayCommand(UpdateName,CanUpdateQuestionName);
            UpdateCategory = new RelayCommand(UpdateQuestionCategory,CanUpdateQuestionCategory);
            AddAnswer = new RelayCommand(AddNewAnswer,CanAddAnswer);
            DeleteAnswer = new RelayCommand(RemoveAnswer,CanDeleteAnswer);

            var AnswersList = DbContext.Antwoorden.ToList().Select(A => new AnswerViewModel(A));
            Answers = new ObservableCollection<AnswerViewModel>(AnswersList);
        }

        private void UpdateName()
        {
            try
            {
                DbContext.Vragen.Where(V => V.Id == this._QuestionId).First().Name = this._QuestionName;
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

        private bool CanUpdateQuestionName()
        {
            return true;
        }

        private void UpdateQuestionCategory()
        {
            try
            {
                DbContext.Vragen.Where(V => V.Id == this._QuestionId).First().Category = this.Category;
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

        private bool CanUpdateQuestionCategory()
        {
            return true;
        }

        private void AddNewAnswer()
        {
            Antwoord A = new Antwoord();
            A.Name = this._QuestionName;
            A.Correct = 0;
            A.VraagId = this._QuestionId;
            try
            {
                DbContext.Antwoorden.Add(A);
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
            this.AnswerName = "";
        }

        private bool CanAddAnswer()
        {
            if (DbContext.Vragen.Where(V => V.Id == this._QuestionId).First().Antwoords.Count() > 3)
                return false;
            else
                return true;
        }

        private void RemoveAnswer()
        {
            try
            {
                DbContext.Antwoorden.Remove(_SelectedAnswer.Antwoord);
                DbContext.SaveChanges();
                RaisePropertyChanged();
            }
            catch
            { }
        }

        private bool CanDeleteAnswer()
        {
            return true;
        }

        public string AnswerName
        {
            get { return _AnswerName; }
            set { var _OldValue = _AnswerName; _AnswerName = value; RaisePropertyChanged(_AnswerName, _OldValue, value, true); }
        }

        public string QuestionName
        {
            get { return _QuestionName; }
            set { var _OldValue = _QuestionName; _QuestionName = value; RaisePropertyChanged(_QuestionName, _OldValue, value, true); }
        }

        public int QuestionId
        {
            get { return _QuestionId; }
            set
            {
                var _OldValue = _QuestionId; _QuestionId = value; RaisePropertyChanged(_QuestionId.ToString(), _OldValue, value, true);
                var AnswerList = DbContext.Antwoorden.ToList().Select(A => new AnswerViewModel(A)).Where(A => A.Antwoord.VraagId == _QuestionId);
                AnswerList = new ObservableCollection<AnswerViewModel>(AnswerList);

                this.Category = DbContext.Vragen.Where(V => V.Id == this._QuestionId).First().Category;
            }
        }

        public string Category
        {
            get { return _Category; }
            set { var _OldValue = _Category; _Category = value; RaisePropertyChanged(_Category, _OldValue, value, true); }
        }

        public bool IsCorrect
        {
            get { return Convert.ToBoolean(this._SelectedAnswer.Antwoord.Correct); }
            set
            {
                var _Oldvalue = this._SelectedAnswer.Antwoord.Correct;
                DbContext.Antwoorden.ToList().Select(A => new AnswerViewModel(A)).Where(A => A.Antwoord.VraagId == _QuestionId).First().IsCorrect = Convert.ToInt32(value);
                RaisePropertyChanged(_SelectedAnswer.Antwoord.Correct.ToString(), _Oldvalue.ToString(), value.ToString(), true);
            }
        }

        public ICommand UpdateQuestionName { get; set;}
        public ICommand UpdateCategory { get; set; }
        public ICommand AddAnswer { get; set; }
        public ICommand DeleteAnswer { get; set; }

        public ObservableCollection<AnswerViewModel> Answers { get; set; }
    }
}
