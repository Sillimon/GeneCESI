using GeneCESI.Lib.Helpers;
using GeneCESI.Lib.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            question.FK_Answers = new AnswerRepository(new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\murie\Documents\GeneCESI\GeneCESI_BDD.mdf;Integrated Security=True;Connect Timeout=30")).GetById((int)reader[1]);
            question.FK_Exam = new ExamRepository(new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\murie\Documents\GeneCESI\GeneCESI_BDD.mdf;Integrated Security=True;Connect Timeout=30")).GetById((int)reader[2]);
            question.Label = (string)reader[3];
            question.Type = EnumHelper.ToEnum<QuestionType, int>((int)reader[4]);

            return question;
        }

        #region CRUD
        public void Insert(Question entity)
        {
            try
            {
                _command = new SqlCommand("INSERT INTO dbo.[Questions](Id_Answers, Id_Exams, Label, Type) " +
                    "VALUES(@Id_Answers, @Id_Exams, @Label, @Type)", _connection as SqlConnection);

                _command.Parameters.Add(new SqlParameter("@Id_Answers", entity.FK_Answers));
                _command.Parameters.Add(new SqlParameter("@Id_Exams", entity.FK_Exam));
                _command.Parameters.Add(new SqlParameter("@Label", entity.Label));
                _command.Parameters.Add(new SqlParameter("@Type", entity.Type));

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
                _command = new SqlCommand("DELETE FROM dbo.Questions WHERE Id = @ID", _connection as SqlConnection);
                _command.Parameters.Add(new SqlParameter("@ID", entity.Id));

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
                _command = new SqlCommand("SELECT * FROM dbo.Questions WHERE Id = @ID", _connection as SqlConnection);
                _command.Parameters.Add(new SqlParameter("@ID", id));

                _connection.Open();
                SqlDataReader results = _command.ExecuteReader() as SqlDataReader;

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
                _command = new SqlCommand("SELECT * FROM dbo.Questions", _connection as SqlConnection);

                _connection.Open();
                SqlDataReader results = _command.ExecuteReader() as SqlDataReader;

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
