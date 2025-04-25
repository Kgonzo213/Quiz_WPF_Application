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
    /// Logika interakcji dla klasy Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        private readonly IAskRepos _AskRepos = new AskRepos();
        private int selectedQuestionId;

        public Delete()
        {
            InitializeComponent();
            LoadQuestions();
        }
        private void DisplayQuestion()
        {

            Ask ask = _AskRepos.GetAsk(selectedQuestionId);
            txtQuestion.Text = ask.Question;
            txtCategory.Text = ask.Category;
            txtAnswerA.Text = ask.Answers[0].Content;
            txtAnswerB.Text = ask.Answers[1].Content;
            txtAnswerC.Text = ask.Answers[2].Content;
            txtAnswerD.Text = ask.Answers[3].Content;
            chkAnswerA.IsChecked = ask.Answers[0].IsCorrect == 1 ? true : false;
            chkAnswerB.IsChecked = ask.Answers[1].IsCorrect == 1 ? true : false;
            chkAnswerC.IsChecked = ask.Answers[2].IsCorrect == 1 ? true : false;
            chkAnswerD.IsChecked = ask.Answers[3].IsCorrect == 1 ? true : false;
            imgImage.Source = Utility.ByteArrayToBitmapImage(ask.Image);


        }
        private void LoadQuestions()
        {
            List<Ask> questions = _AskRepos.ShowQuestions();
            cmbQuestion.ItemsSource = questions;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            _AskRepos.DeleteAsk(selectedQuestionId);
            Delete del = new Delete();
            del.Show();
            this.Close();



        }

        private void cmbQuestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbQuestion.SelectedValue != null)
            {
                selectedQuestionId = (int)cmbQuestion.SelectedValue;
                Ask ask = _AskRepos.GetAsk(selectedQuestionId);
                DisplayQuestion();

            }
        }
    }
}
