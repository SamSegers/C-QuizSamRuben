using EindopdrachtProg5RubenSam.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EindopdrachtProg5RubenSam.ViewModel
{
    public class ViewModelQuizes : ViewModelBase
    {
        public ViewModelQuizes()
        {
            OpenQuizes = new RelayCommand(CreateOpen, CanOpen);
            PlayQuizes = new RelayCommand(PlayOpen,CanOpen);
        }
        
        private void CreateOpen()
        {
            ViewCreateQuiz VCQ = new ViewCreateQuiz();
            VCQ.Show();
        }

        private void PlayOpen()
        {
            ViewSelectQuiz VSQ = new ViewSelectQuiz();
            VSQ.Show();
        }

        private bool CanOpen()
        {
            return true;
        }

        public ICommand OpenQuizes { get; set; }
        public ICommand PlayQuizes { get; set; }
    }
}
