using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Programowanie_Projekt.Repo;
using Programowanie_Projekt.Model;

namespace Programowanie_Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IAskRepos _AskRepos = new AskRepos();
        public MainWindow()
        {
            InitializeComponent();
            string[] scores = _AskRepos.ShowScores();
            txtLeadboard.Text = string.Join(Environment.NewLine, scores);

        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            Create create = new Create(); create.Show();

           
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Update update = new Update(); update.Show();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Delete delete = new Delete(); delete.Show();
        }
        private void Quiz_Click(object sender, RoutedEventArgs e)
        {
            NumberOfQuestions number = new NumberOfQuestions(); number.Show();
            this.Close();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }






    }
}