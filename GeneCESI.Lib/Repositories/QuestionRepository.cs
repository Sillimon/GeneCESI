using GeneCESI.Lib.Helpers;
using GeneCESI.Lib.Objects;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GeneCESI.Lib.Helpers.EnumHelper;

namespace GeneCESI.Lib.Repositories
{
    public interface IQuestionRepository : IRepository<Question>
    {

    }

    public class QuestionRepository : IQuestionRepository
    {
        public IDbConnection _connection { get; set; }
        public IDbCommand _command { get; set; }

        public QuestionRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public Question ReaderToObject(IDataReader reader)
        {
            var question = new Question();

            question.Id = (int)reader[0];

            question.FK_Answers = new AnswerRepository(new SqliteConnection(@"Data Source=" +
           Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))) +
           @"\GeneCESI_DB.db;")).GetById((int)reader[1]);

            question.FK_Exam = new ExamRepository(new SqliteConnection(@"Data Source=" +
           Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()))) +
           @"\GeneCESI_DB.db;")).GetById((int)reader[2]);
            
            question.Label = (string)reader[3];
            
            question.Type = EnumHelper.ToEnum<QuestionType, int>((int)reader[4]);

            return question;
        }

        #region CRUD
        public void Insert(Question entity)
        {
            try
            {
                _command = new SqliteCommand("INSERT INTO [Questions](Id_Answers, Id_Exams, Label, Type) " +
                    "VALUES(@Id_Answers, @Id_Exams, @Label, @Type)", _connection as SqliteConnection);

                _command.Parameters.Add(new SqliteParameter("@Id_Answers", entity.FK_Answers));
                _command.Parameters.Add(new SqliteParameter("@Id_Exams", entity.FK_Exam));
                _command.Parameters.Add(new SqliteParameter("@Label", entity.Label));
                _command.Parameters.Add(new SqliteParameter("@Type", entity.Type));

                _connection.Open();
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //TODO
            }
            finally
            {
                _command?.Dispose();
                _connection?.Close();
            }
        }

        public void Delete(Question entity)
        {
            try
            {
                _command = new SqliteCommand("DELETE FROM Questions WHERE Id = @ID", _connection as SqliteConnection);
                _command.Parameters.Add(new SqliteParameter("@ID", entity.Id));

                _connection.Open();
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //TODO
            }
            finally
            {
                _command?.Dispose();
                _connection?.Close();
            }
        }

        public Question GetById(int id)
        {
            Question question = new Question();

            try
            {
                _command = new SqliteCommand("SELECT * FROM Questions WHERE Id = @ID", _connection as SqliteConnection);
                _command.Parameters.Add(new SqliteParameter("@ID", id));

                _connection.Open();
                SqliteDataReader results = _command.ExecuteReader() as SqliteDataReader;

                while (results.Read())
                {
                    question = ReaderToObject(results);
                }
                results?.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _command?.Dispose();
                _connection?.Close();
            }

            return question;
        }
        
        public IQueryable<Question> GetAll()
        {
            var questions = new List<Question>();

            try
            {
                _command = new SqliteCommand("SELECT * FROM Questions", _connection as SqliteConnection);

                _connection.Open();
                SqliteDataReader results = _command.ExecuteReader() as SqliteDataReader;

                while (results.Read())
                    questions.Add(ReaderToObject(results));

                results?.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                _command?.Dispose();
                _connection?.Close();
            }

            return questions.AsQueryable();
        }
        #endregion
    }
}
