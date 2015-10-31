using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EindopdrachtProg5RubenSam.ViewModel
{
    public class QuizViewModel : ViewModelBase
    {
        public int Id
        {
            get { return _Quiz.Id; }
            set { _Quiz.Id = value; RaisePropertyChanged("Id"); }
        }

        public string Name
        {
            get { return _Quiz.Name; }
            set { _Quiz.Name = value; RaisePropertyChanged("Name"); }
        }

        public int Vragen
        {
            get { return _Quiz.Vraags.Count(); }
            set { /*_Quiz.Vraags = value; RaisePropertyChanged("Name");*/ }
        }

        public Quiz Quiz { get { return _Quiz; } }

        private Quiz _Quiz;
        public QuizViewModel()
        {
            this._Quiz = new Quiz();
        }

        public QuizViewModel(Quiz _Quiz)
        {
            this._Quiz = _Quiz;
        }
    }
}
