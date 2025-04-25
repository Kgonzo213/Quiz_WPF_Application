using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Programowanie_Projekt.Model;
using Microsoft.Data.Sqlite;
using System.IO;
using System.Data.Common;
using System.Data;
using System.Windows;
using Programowanie_Projekt.Repo;



namespace Programowanie_Projekt.Repo
{
    class AskRepos : IAskRepos

    {
        private static string dbFilePath = Path.Combine(Environment.CurrentDirectory, "dbQuestions.db");
        private static string connectionString = $"Data Source={dbFilePath}";

        private bool isDbExist()
        {
            bool exists = false;
            if (File.Exists(dbFilePath))
            {
                exists = true;
            }
            return exists;
        }
        private void createDb()
        {
            SqliteConnection dbConetioncs = new SqliteConnection(connectionString);
            dbConetioncs.Open();
            string sql = "CREATE TABLE Questions (Id INTEGER PRIMARY KEY AUTOINCREMENT, Category TEXT, Question TEXT, Image BLOB)";
            SqliteCommand command = new SqliteCommand(sql, dbConetioncs);
            command.ExecuteNonQuery();
            sql = "CREATE TABLE Answers (Id INTEGER PRIMARY KEY AUTOINCREMENT, Content TEXT, IsCorrect INTEGER, QuestionId INTEGER)";
            command = new SqliteCommand(sql, dbConetioncs);
            command.ExecuteNonQuery();
            sql = "CREATE TABLE Scores (Id INTEGER PRIMARY KEY AUTOINCREMENT, Score INTEGER, Name TEXT, NOF INTEGER)";
            command = new SqliteCommand(sql, dbConetioncs);
            command.ExecuteNonQuery();
            dbConetioncs.Close();

        }
        bool IAskRepos.IsAskNull(Ask ask)
        {
            if (ask == null || ask.Answers == null || ask.Answers.Length != 4)
            {
                return true;
            }

            return ask.Category == "" || ask.Question == "" ||
                   ask.Answers[0].Content == "" || ask.Answers[1].Content == "" ||
                   ask.Answers[2].Content == "" || ask.Answers[3].Content == "";
        }

        bool IAskRepos.AddAsk(Ask ask)
        {
            bool isAdded = false;
            if (!isDbExist())
            {
                createDb();
            }
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    SqliteCommand command = new SqliteCommand();
                    command.CommandText = "INSERT INTO Questions (Category, Question, Image) VALUES (@Category, @Question, @Image)";
                    command.Parameters.Add("@Category", SqliteType.Text).Value = ask.Category;
                    command.Parameters.Add("@Question", SqliteType.Text).Value = ask.Question;

                    if (ask.Image == null)
                    {
                        ask.Image = new byte[0];
                    }
                    command.Parameters.Add("@Image", SqliteType.Blob, ask.Image.Length).Value = ask.Image;
                    command.Connection = connection;
                    command.ExecuteNonQuery();

                    command.CommandText = "SELECT MAX(Id) from Questions";
                    command.Connection = connection;
                    ask.Id = Convert.ToInt32(command.ExecuteScalar());



                    for (int i = 0; i < 4; i++)
                    {
                        command.Parameters.Clear();
                        command.CommandText = "INSERT INTO Answers (Content, IsCorrect, QuestionId) VALUES (@Content, @IsCorrect, @QuestionId)";
                        command.Parameters.Add("@Content", SqliteType.Text).Value = ask.Answers[i].Content;
                        command.Parameters.Add("@IsCorrect", SqliteType.Integer).Value = ask.Answers[i].IsCorrect;
                        command.Parameters.Add("@QuestionId", SqliteType.Integer).Value = ask.Id;
                        command.Connection = connection;
                        command.ExecuteNonQuery();

                    }


                    isAdded = true;
                    connection.Close();


                }

            }
            return isAdded;
        }

        bool IAskRepos.DeleteAsk(int id)
        {
            bool isDeleted = false;

            if (!isDbExist())
            {
                createDb();
            }
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    SqliteCommand command = new SqliteCommand();
                    command.CommandText = "Delete FROM Questions WHERE Id = @Id";
                    command.Parameters.Add("@Id", SqliteType.Integer).Value = id;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    command.CommandText = "Delete FROM Answers WHERE QuestionId = @Id";
                    command.Parameters.Add("@Id", SqliteType.Integer).Value = id;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                    isDeleted = true;
                    connection.Close();

                }

            }


            return isDeleted;
        }

        bool IAskRepos.UpdateAsk(Ask ask)
        {
            bool isUpdated = false;
            if (!isDbExist())
            {
                createDb();
            }
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    SqliteCommand command = new SqliteCommand();
                    command.CommandText = "UPDATE Questions SET Category = @Category, Question = @Question, Image = @Image WHERE Id = @Id";
                    command.Parameters.Add("@Category", SqliteType.Text).Value = ask.Category;
                    command.Parameters.Add("@Question", SqliteType.Text).Value = ask.Question;

                    if (ask.Image == null)
                    {
                        ask.Image = new byte[0];
                    }

                    command.Parameters.Add("@Image", SqliteType.Blob, ask.Image.Length).Value = ask.Image;
                    command.Parameters.Add("@Id", SqliteType.Integer).Value = ask.Id;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    command.CommandText = "DELETE FROM Answers WHERE QuestionId = @Id";
                    command.Parameters.Add("@Id", SqliteType.Integer).Value = ask.Id;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                    for (int i = 0; i < 4; i++)
                    {
                        command.Parameters.Clear();
                        command.CommandText = "INSERT INTO Answers (Content, IsCorrect, QuestionId) VALUES (@Content, @IsCorrect, @QuestionId)";
                        command.Parameters.Add("@Content", SqliteType.Text).Value = ask.Answers[i].Content;
                        command.Parameters.Add("@IsCorrect", SqliteType.Integer).Value = ask.Answers[i].IsCorrect;
                        command.Parameters.Add("@QuestionId", SqliteType.Integer).Value = ask.Id;
                        command.Connection = connection;
                        command.ExecuteNonQuery();
                    }
                    isUpdated = true;
                    connection.Close();

                }
            }
            return isUpdated;
        }


        Ask[] IAskRepos.Questions(int NumberOfQuestions)
        {
            List<Ask> askList = new List<Ask>();
            

            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    SqliteCommand command = new SqliteCommand();
                    command.CommandText = "SELECT Id FROM Questions";
                    command.Connection = connection;

                   
                    List<int> allIds = new List<int>();
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            allIds.Add(reader.GetInt32(0));
                        }
                    }


                    if (allIds.Count == 0 || NumberOfQuestions > allIds.Count)
                    {
                        MessageBox.Show($"Nie mamy tyle pytań przepraszamy. Liczba pytań w bazie: {allIds.Count}");
                        return askList.ToArray();
                    }
                    
                    Random rnd = new Random();
                    HashSet<int> usedIds = new HashSet<int>();
                    while (askList.Count < NumberOfQuestions)
                    {
                        int randomIndex = rnd.Next(allIds.Count);
                        int randomId = allIds[randomIndex];

                        if (usedIds.Contains(randomId))
                        {
                            continue;
                        }

                        command.Parameters.Clear();
                        command.CommandText = "SELECT * FROM Questions WHERE Id = @Id";
                        command.Parameters.Add("@Id", SqliteType.Integer).Value = randomId;

                        Ask ask = null;
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                ask = new Ask
                                {
                                    Id = reader.GetInt32(0),
                                    Category = reader.GetString(1),
                                    Question = reader.GetString(2),
                                    Image = reader["Image"] as byte[]
                                };
                            }
                        }

                        if (ask != null)
                        {
                            command.Parameters.Clear();
                            command.CommandText = "SELECT * FROM Answers WHERE QuestionId = @Id";
                            command.Parameters.Add("@Id", SqliteType.Integer).Value = randomId;

                            List<Answer> answers = new List<Answer>();
                            using (var reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    answers.Add(new Answer
                                    {
                                        Id = reader.GetInt32(0),
                                        Content = reader.GetString(1),
                                        IsCorrect = reader.GetInt32(2),
                                        QuestionId = reader.GetInt32(3)
                                    });
                                }
                            }
                            ask.Answers = answers.ToArray();
                            askList.Add(ask);
                            usedIds.Add(randomId);
                        }
                    }

                    connection.Close();
                }
            }

            return askList.ToArray();
        }


        bool IAskRepos.addScore(int score, int numberOfQuestions, string name)
        {
            bool isAdded = false;
            if (!isDbExist())
            {
                createDb();
            }
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    SqliteCommand command = new SqliteCommand();
                    command.CommandText = "INSERT INTO Scores (Score, Name, NOF) VALUES (@Score, @Name, @NOF)";
                    command.Parameters.Add("@Score", SqliteType.Integer).Value = score;
                    command.Parameters.Add("@Name", SqliteType.Text).Value = name;
                    command.Parameters.Add("@NOF", SqliteType.Integer).Value = numberOfQuestions;
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                    isAdded = true;
                    connection.Close();
                }
            }
            return isAdded;
        }

        string[] IAskRepos.ShowScores()
        {
            string[] scores = new string[6];
            bool isShowed = false;
            if (!isDbExist())
            {
                createDb();
            }
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    SqliteCommand command = new SqliteCommand();
                    command.CommandText = "SELECT Score, Name, NOF FROM Scores ORDER BY Score DESC LIMIT 6 ";
                    command.Connection = connection;
                    using (var reader = command.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            scores[i] = "";
                            scores[i] += reader.GetInt32(0).ToString();
                            scores[i] += " ";
                            scores[i] += reader.GetString(1);
                            scores[i] += " ";
                            scores[i] += reader.GetInt32(2).ToString();
                            scores[i] += " ";
                            i++;

                        }
                    }
                    isShowed = true;
                    connection.Close();
                }
            }
            return scores;
        }
        List<Ask> IAskRepos.ShowQuestions()
        {
            List<Ask> questions = new List<Ask>();
            if (!isDbExist())
            {
                createDb();
            }
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    SqliteCommand command = new SqliteCommand();
                    command.CommandText = "SELECT Id, Question FROM Questions";
                    command.Connection = connection;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ask ask = new Ask
                            {
                                Id = reader.GetInt32(0),
                                Question = reader.GetString(1)
                            };
                            questions.Add(ask);
                        }
                    }
                    connection.Close();
                }
            }
            return questions;
        }

        Ask IAskRepos.GetAsk(int id) {
            Ask ask = new Ask();
            if (!isDbExist())
            {
                createDb();
            }
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                if (connection.State == ConnectionState.Open)
                {
                    SqliteCommand command = new SqliteCommand();
                    command.CommandText = "SELECT * FROM Questions WHERE Id = @Id";
                    command.Parameters.Add("@Id", SqliteType.Integer).Value = id;
                    command.Connection = connection;
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ask.Id = reader.GetInt32(0);
                            ask.Category = reader.GetString(1);
                            ask.Question = reader.GetString(2);
                            ask.Image = reader["Image"] as byte[];
                        }
                    }
                    command.Parameters.Clear();
                    command.CommandText = "SELECT * FROM Answers WHERE QuestionId = @Id";
                    command.Parameters.Add("@Id", SqliteType.Integer).Value = id;
                    command.Connection = connection;
                    using (var reader = command.ExecuteReader())
                    {
                        int i = 0;
                        while (reader.Read())
                        {
                            ask.Answers[i] = new Answer();
                            ask.Answers[i].Content = (string)reader["Content"];
                            ask.Answers[i].IsCorrect = reader.GetInt32(2);
                            i++;
                        }
                    }
                    connection.Close();
                }
            }
            return ask;
        
        }
    }
}
        
          
  
