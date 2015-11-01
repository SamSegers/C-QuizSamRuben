using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EindopdrachtProg5RubenSam.Views
{
    /// <summary>
    /// Interaction logic for ViewScoreQuiz.xaml
    /// </summary>
    public partial class ViewScoreQuiz : Window
    {


        public ViewScoreQuiz()
        {
            InitializeComponent();
        }

        public ViewScoreQuiz(int Points)
        {
            // TODO: Complete member initialization
            //this.Points = Points;
            InitializeComponent();
            this.lblScore.Content = Points;
        }

        public ViewScoreQuiz(int Points, int TotalPoints)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.lblScore.Content = Points;
            this.lblTotal.Content = "Het totaal te behaalde punten was: " + TotalPoints.ToString();


        }
    }
}
