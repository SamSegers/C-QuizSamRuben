using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EindopdrachtProg5RubenSam.ViewModel
{
    class AnswerViewModel : ViewModelBase
    {
        public int Id
        {
            get { return _Antwoord.Id; }
            set { _Antwoord.Id = value; RaisePropertyChanged("Id"); }
        }

        public string Name
        {
            get { return _Antwoord.Name; }
            set { _Antwoord.Name = value; RaisePropertyChanged("Name"); }
        }
        public int IsCorrect
        {
            get { return _Antwoord.Correct; }
            set { _Antwoord.Correct = value; RaisePropertyChanged("Correct"); }
        }


        public Antwoord Antwoord { get { return _Antwoord; } }

        private Antwoord _Antwoord;
        public AnswerViewModel()
        {
            this._Antwoord = new Antwoord();
        }

        public AnswerViewModel(Antwoord _Antwoord)
        {
            this._Antwoord = _Antwoord;
        }
    }
}
