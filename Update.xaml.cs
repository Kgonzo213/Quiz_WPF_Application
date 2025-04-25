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
using Programowanie_Projekt.Model;
using Microsoft.Win32;
using System.IO;

namespace Programowanie_Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        private readonly IAskRepos _AskRepos = new AskRepos();
        private int selectedQuestionId;
        private string _imagePath;

        public Update()
        {
            InitializeComponent();
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            List<Ask> questions = _AskRepos.ShowQuestions();
            cmbQuestion.ItemsSource = questions;
        }
        private Answer[] getAnswers()
        {
            Answer[] answers = new Answer[4];
            answers[0] = new Answer
            {
                Content = txtAnswerA.Text,
                IsCorrect = (bool)chkAnswerA.IsChecked ? 1 : 0
            };
            answers[1] = new Answer
            {
                Content = txtAnswerB.Text,
                IsCorrect = (bool)chkAnswerB.IsChecked ? 1 : 0
            };
            answers[2] = new Answer
            {
                Content = txtAnswerC.Text,
                IsCorrect = (bool)chkAnswerC.IsChecked ? 1 : 0
            };
            answers[3] = new Answer
            {
                Content = txtAnswerD.Text,
                IsCorrect = (bool)chkAnswerD.IsChecked ? 1 : 0
            };
            return answers;
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Ask ask = new Ask();
            ask.Id = selectedQuestionId;
            ask.Category = txtCategory.Text;
            ask.Question = txtQuestion.Text;
            ask.Answers = getAnswers();
            if (!string.IsNullOrEmpty(_imagePath))
            {
                using (FileStream fileStream = File.Open(_imagePath, FileMode.Open))
                {
                    ask.Image = Utility.ImageToByteArray(fileStream);
                }
            }
            else
            {
                ask.Image = _AskRepos.GetAsk(selectedQuestionId).Image;
            }

            if (!_AskRepos.IsAskNull(ask))
            {
                if (_AskRepos.UpdateAsk(ask))
                {
                    MessageBox.Show("Pytanie zostało zaktualizowane", "Success", MessageBoxButton.OK);
                    new Update().Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Nie można zaktualizować pytania", "Error", MessageBoxButton.OK);
                }

            }
            else
            {
                MessageBox.Show("Uzupełnij dane", "Error", MessageBoxButton.OK);
            }

        }

        private void cmbQuestion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbQuestion.SelectedValue != null)
            {
                selectedQuestionId = (int)cmbQuestion.SelectedValue;
                DisplayQuestion();
            }
        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = false,
                Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                _imagePath = openFileDialog.FileName;
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = new Uri(_imagePath);
                image.EndInit();
                imgImage.Source = image;
            }
        }

       
    }
}


