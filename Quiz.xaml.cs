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

namespace Programowanie_Projekt
{
    /// <summary>
    /// Logika interakcji dla klasy Quiz.xaml
    /// </summary>
    public partial class Quiz : Window
    {
        private Ask[] _questions;
        private int NOF = 0;
        private int _Score = 0;
        private int _currentQuestionIndex = 0;

        public Quiz(Ask[] questions)
        {
            InitializeComponent();
            _questions = questions;
            NOF = questions.Length;
            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            if (_currentQuestionIndex < _questions.Length)
            {
                Ask ask = _questions[_currentQuestionIndex];
                txtQuestion.Text = ask.Question;
                txtCategory.Text = ask.Category;
                txtAnswerA.Text = ask.Answers[0].Content;
                txtAnswerB.Text = ask.Answers[1].Content;
                txtAnswerC.Text = ask.Answers[2].Content;
                txtAnswerD.Text = ask.Answers[3].Content;
                chkAnswerA.IsChecked = false;
                chkAnswerB.IsChecked = false;
                chkAnswerC.IsChecked = false;
                chkAnswerD.IsChecked = false;
                imgImage.Source = Utility.ByteArrayToBitmapImage(ask.Image);
            }
            else
            {
                Score score = new Score(NOF, _Score);
                score.Show();
                this.Close();
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (_currentQuestionIndex < _questions.Length)
            {
                Ask currentAsk = _questions[_currentQuestionIndex];

                if ((bool)chkAnswerA.IsChecked && currentAsk.Answers[0].IsCorrect == 1)
                {
                    _Score += 10;
                }
                else if ((bool)chkAnswerA.IsChecked && currentAsk.Answers[0].IsCorrect == 0)
                {
                    _Score -= 10;
                }
                if ((bool)chkAnswerB.IsChecked && currentAsk.Answers[1].IsCorrect == 1)
                {
                    _Score += 10;
                }
                else if ((bool)chkAnswerB.IsChecked && currentAsk.Answers[1].IsCorrect == 0)
                {
                    _Score -= 10;
                }
                if ((bool)chkAnswerC.IsChecked && currentAsk.Answers[2].IsCorrect == 1)
                {
                    _Score += 10;
                }
                else if ((bool)chkAnswerC.IsChecked && currentAsk.Answers[2].IsCorrect == 0)
                {
                    _Score -= 10;
                }
                if ((bool)chkAnswerD.IsChecked && currentAsk.Answers[3].IsCorrect == 1)
                {
                    _Score += 10;
                }
                else if ((bool)chkAnswerD.IsChecked && currentAsk.Answers[3].IsCorrect == 0)
                {
                    _Score -= 10;
                }

                _currentQuestionIndex++;
                DisplayQuestion();
            }
            else
            {
                Score score = new Score(NOF, _Score);
                score.Show();
                this.Close();
            }
        }
    }
}
