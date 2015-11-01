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
using System.Windows.Media;

namespace EindopdrachtProg5RubenSam.ViewModel
{
    public class ViewModelPlayQuiz : ViewModelBase
    {
        private int Points = 0;
        private int TotalPoints = 0;
        private Context DbContext;
        private string _QuestionName;
        private int _QuestionId;
        private int _QuizId;

        private bool Selected1 = false;
        private bool Selected2 = false;
        private bool Selected3 = false;
        private bool Selected4 = false;

        private SolidColorBrush _Color1;
        private SolidColorBrush _Color2;
        private SolidColorBrush _Color3;
        private SolidColorBrush _Color4;

        public ViewModelPlayQuiz()
        {
            DbContext = new Context();
            _QuestionName = "X";
            _QuestionId = -1;
            this.NextQuestion = new RelayCommand(GetNextQuestion,CanGetNextQuestion);

            this.Answer1Selected = new RelayCommand(Select1,CanSelect1);
            this.Answer2Selected = new RelayCommand(Select2,CanSelect2);
            this.Answer3Selected = new RelayCommand(Select3,CanSelect3);
            this.Answer4Selected = new RelayCommand(Select4, CanSelect4);

            this._Color1 = Brushes.White;
            this._Color2 = Brushes.White;
            this._Color3 = Brushes.White;
            this._Color4 = Brushes.White;

            RaisePropertyChanged("Color1");
            RaisePropertyChanged("Color2");
            RaisePropertyChanged("Color3");
            RaisePropertyChanged("Color4");
        }

        private void GetNextQuestion()
        {
            

            // update waardes in de knoppen.
            // update vraagnaam, nr
            try
            {
                CheckPoints();
                this.Questions.Remove(this.Questions.First());
                this.QuestionId = this.Questions.First().Id;
                this.QuestionName = this.Questions.First().Name;
                RaisePropertyChanged("QuestionId");
                RaisePropertyChanged("QuestionName");
                this.FillAnswers();

                this._Color1 = Brushes.White;
                this._Color2 = Brushes.White;
                this._Color3 = Brushes.White;
                this._Color4 = Brushes.White;

                RaisePropertyChanged("Color1");
                RaisePropertyChanged("Color2");
                RaisePropertyChanged("Color3");
                RaisePropertyChanged("Color4");

                this.Selected1 = false;
                this.Selected2 = false;
                this.Selected3 = false;
                this.Selected4 = false;
                // als er geen vragen meer zijn roep ViewScorequiz aan met het aantal punten
            }
            catch 
            {
                ViewScoreQuiz VSQ = new ViewScoreQuiz(Points,TotalPoints);
                VSQ.Show();
            }
            

        }

        private void CheckPoints()
        {
            var Q = this.Questions.First();

            for (int i = 0; i < Q.Antwoorden; i++)
            {
                if (i == 0)
                    if (Q.Question.Antwoords.ElementAt(i).Correct == Convert.ToInt32(this.Selected1))
                        this.Points++;
                if (i == 1)
                    if (Q.Question.Antwoords.ElementAt(i).Correct == Convert.ToInt32(this.Selected2))
                        this.Points++;
                if (i == 2)
                    if (Q.Question.Antwoords.ElementAt(i).Correct == Convert.ToInt32(this.Selected3))
                        this.Points++;
                if (i == 3)
                    if (Q.Question.Antwoords.ElementAt(i).Correct == Convert.ToInt32(this.Selected4))
                        this.Points++;

                this.TotalPoints++;
                
           }
            
        }

        private bool CanGetNextQuestion()
        {
            return true;
        }

        private void FillAnswers()
        {
            this.Answer1 = "";
            this.Answer2 = "";
            this.Answer3 = "";
            this.Answer4 = "";
            RaisePropertyChanged("Answer1");
            RaisePropertyChanged("Answer2");
            RaisePropertyChanged("Answer3");
            RaisePropertyChanged("Answer4");

            var Answers = this.Questions.First().Question.Antwoords;

            for (int i = 0; i < Answers.Count(); i++)
            {
                switch (i)
                { 
                    case 0:
                        this.Answer1 = Answers.ElementAt(i).Name;
                        RaisePropertyChanged("Answer1");
                        break;
                    case 1:
                        this.Answer2 = Answers.ElementAt(i).Name;
                        RaisePropertyChanged("Answer2");
                        break;
                    case 2:
                        this.Answer3 = Answers.ElementAt(i).Name;
                        RaisePropertyChanged("Answer3");
                        break;
                    case 3:
                        this.Answer4 = Answers.ElementAt(i).Name;
                        RaisePropertyChanged("Answer4");
                        break;
                }
            }
        }

        public int QuizId
        {
            get { return _QuizId; }
            set
            {
                this.Answer1 = "";
                this.Answer2 = "";
                this.Answer3 = "";
                this.Answer4 = "";
                RaisePropertyChanged("Answer1");
                RaisePropertyChanged("Answer2");
                RaisePropertyChanged("Answer3");
                RaisePropertyChanged("Answer4");

                this._Color1 = Brushes.White;
                this._Color2 = Brushes.White;
                this._Color3 = Brushes.White;
                this._Color4 = Brushes.White;

                RaisePropertyChanged("Color1");
                RaisePropertyChanged("Color2");
                RaisePropertyChanged("Color3");
                RaisePropertyChanged("Color4");

                this.Selected1 = false;
                this.Selected2 = false;
                this.Selected3 = false;
                this.Selected4 = false;

                this._QuestionId = -1;
                this._QuestionName = "";
                RaisePropertyChanged("QuestionId");
                RaisePropertyChanged("QuestionName");

                this.TotalPoints = 0;
                this.Points = 0;

                var _OldValue = _QuizId; _QuizId = value; /*RaisePropertyChanged(_QuizId.ToString(), _OldValue, value, true);*/

                var QuestionList = DbContext.Vragen.ToList().Select(Q => new QuestionsViewModel(Q));
                Questions = new ObservableCollection<QuestionsViewModel>(QuestionList);
                for (int i = 0; i < Questions.Count(); i++)
                {
                    if (Questions[i].Question.QuizId != _QuizId)
                    {
                        Questions.RemoveAt(i);
                        i = -1;
                    }
                }

                try
                {
                    

                    

                    QuestionId = Questions.First().Id;
                    QuestionName = Questions.First().Name;
                    RaisePropertyChanged("QuestionId");
                    RaisePropertyChanged("QuestionName");
                    this.FillAnswers();
                }
                catch { }
            }
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
                
            }
        }

        private void Select1()
        {
            this.Selected1 = !this.Selected1;

            if (this._Color1 == Brushes.White)
                this._Color1 = Brushes.Blue;
            else if (this._Color1 == Brushes.Blue)
                this._Color1 = Brushes.White;

            RaisePropertyChanged("Color1");
        }

        private void Select2()
        {
            this.Selected2 = !this.Selected2;

            if (this._Color2 == Brushes.White)
                this._Color2 = Brushes.Blue;
            else if (this._Color2 == Brushes.Blue)
                this._Color2 = Brushes.White;

            RaisePropertyChanged("Color2");
        }

        private void Select3()
        {
            this.Selected3 = !this.Selected3;

            if (this._Color3 == Brushes.White)
                this._Color3 = Brushes.Blue;
            else if (this._Color3 == Brushes.Blue)
                this._Color3 = Brushes.White;

            RaisePropertyChanged("Color3");
        }

        private void Select4()
        {
            this.Selected4 = !this.Selected4;

            if (this._Color4 == Brushes.White)
                this._Color4 = Brushes.Blue;
            else if (this._Color4 == Brushes.Blue)
                this._Color4 = Brushes.White;

            RaisePropertyChanged("Color4");
        }

        private bool CanSelect1()
        {
            try
            {
                if (this.Questions.First().Antwoorden >= 1)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        private bool CanSelect2()
        {
            try
            {
                if (this.Questions.First().Antwoorden >= 2)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        private bool CanSelect3()
        {
            try
            {
                if (this.Questions.First().Antwoorden >= 3)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        private bool CanSelect4()
        {
            try
            {
                if (this.Questions.First().Antwoorden >= 4)
                    return true;
                else
                    return false;
            }
            catch { return false; }
        }

        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
        public string Answer4 { get; set; }

        public SolidColorBrush Color1 { get { return _Color1; } }
        public SolidColorBrush Color2 { get { return _Color2; } }
        public SolidColorBrush Color3 { get { return _Color3; } }
        public SolidColorBrush Color4 { get { return _Color4; } }

        public ICommand NextQuestion { get; set; }
        public ICommand Answer1Selected { get; set; }
        public ICommand Answer2Selected { get; set; }
        public ICommand Answer3Selected { get; set; }
        public ICommand Answer4Selected { get; set; }

        public ObservableCollection<QuestionsViewModel> Questions { get; set; }
        public ObservableCollection<AnswerViewModel> Answers { get; set; }
    }
}
