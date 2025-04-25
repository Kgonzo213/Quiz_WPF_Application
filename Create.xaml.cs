using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Programowanie_Projekt.Model;
using Programowanie_Projekt.Repo;

namespace Programowanie_Projekt
{
    public partial class Create : Window
    {
        private readonly IAskRepos _AskRepos = new AskRepos();
        private string _imagePath;

        public Create()
        {
            InitializeComponent();
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Ask ask = new Ask
            {
                Category = txtCategory.Text,
                Question = txtQuestion.Text,
                Answers = getAnswers(),
            };

            if (!string.IsNullOrEmpty(_imagePath))
            {
                using (FileStream fileStream = File.Open(_imagePath, FileMode.Open))
                {
                    ask.Image = Utility.ImageToByteArray(fileStream);
                }
            }

            if (!_AskRepos.IsAskNull(ask))
            {
                if (_AskRepos.AddAsk(ask))
                {
                    new Create().Show();
                    this.Close();

                }
                else
                {
                    MessageBox.Show("Nie udało się dodać pytania", "Error", MessageBoxButton.OK);
                }
                
            }
            else
            {
                MessageBox.Show("Nie można dodać pustego pytania dodaj wymagane treści", "Error", MessageBoxButton.OK);
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
