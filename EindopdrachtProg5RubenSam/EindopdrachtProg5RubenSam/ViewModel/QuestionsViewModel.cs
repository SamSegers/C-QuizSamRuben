using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EindopdrachtProg5RubenSam.ViewModel
{
    public class QuestionsViewModel : ViewModelBase
    {
        public int Id
        {
            get { return _Question.Id; }
            set { _Question.Id = value; RaisePropertyChanged("Id"); }
        }

        public string Name
        {
            get { return _Question.Name; }
            set { _Question.Name = value; RaisePropertyChanged("Name"); }
        }

        public string Categorie
        {
            get { return _Question.Category; }
            set { _Question.Category = value; RaisePropertyChanged("Categorie"); }
        }

        public int Antwoorden
        {
            get { return _Question.Antwoords.Count(); }
            set { /**/ }
        }

        public Vraag Question { get { return _Question; } }

        private Vraag _Question;
        public QuestionsViewModel()
        {
            this._Question = new Vraag();
        }

        public QuestionsViewModel(Vraag _Question)
        {
            this._Question = _Question;
        }
    }
}
