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
using Programowanie_Projekt.Model;
using Programowanie_Projekt.Repo;

namespace Programowanie_Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy NumberOfQuestions.xaml
    /// </summary>
    public partial class NumberOfQuestions : Window
    {
        public NumberOfQuestions()
        {
            InitializeComponent();
        }
        private readonly IAskRepos _AskRepos = new AskRepos();

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            
            if (txtNumberOfQuestions.Text.Length == 0 )
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
                return;
            }
           
            if (!int.TryParse(txtNumberOfQuestions.Text, out int numberOfQuestions))
            {
                MessageBox.Show("Wpisz liczbe!!!.");
                return;
            }

            Ask[] questions = _AskRepos.Questions(numberOfQuestions);
            if(numberOfQuestions != 0 && questions.Length>0)
            {
                Quiz quiz = new Quiz(questions);
                quiz.Show();
                this.Close();
                return;
            }
            else
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
            

            return;

        }
    }
}
