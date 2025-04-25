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
using Programowanie_Projekt.Repo;

namespace Programowanie_Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy Score.xaml
    /// </summary>
    public partial class Score : Window
    {
        private readonly IAskRepos _AskRepos = new AskRepos();
        private int _numberOfQuestions;
        private int _score;

        public Score(int numberOfQuestions, int score)
        {
            _numberOfQuestions = numberOfQuestions;
            _score = score;
            InitializeComponent();
            txtScore.Text = Convert.ToString(_score);
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            
            int NOF = _numberOfQuestions;
            string name = txtName.Text;

            _AskRepos.addScore(_score, NOF, name);
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
