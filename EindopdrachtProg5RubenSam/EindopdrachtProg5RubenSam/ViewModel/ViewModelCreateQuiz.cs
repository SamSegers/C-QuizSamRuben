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
    public class ViewModelCreateQuiz : ViewModelBase
    {
        public ViewModelCreateQuiz()
        {
            OpenQuizes = new RelayCommand(Open, CanOpen);
        }
        
        private void Open()
        {
            ViewCreateQuiz VCQ = new ViewCreateQuiz();
            VCQ.Show();
        }

        private bool CanOpen()
        {
            return true;
        }

        public ICommand OpenQuizes { get; set; }
    }
}
