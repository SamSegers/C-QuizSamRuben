using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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
            CreateQuiz = new RelayCommand(AddQuiz,CanAddQuiz);
            OpenEditQuiz = new RelayCommand(OpenQuiz,CanOpenQuiz);
        }

        private void AddQuiz()
        { 
        
        }

        private void OpenQuiz()
        { 
        
        }

        private bool CanAddQuiz()
        {
            /* todo: uitbreiden of er echt een naam is voor de quiz etc. */
            return true;
        }

        private bool CanOpenQuiz()
        {
            return true;
        }

        public ICommand CreateQuiz { get; set; }

        public ICommand OpenEditQuiz { get; set; }
    }
}
