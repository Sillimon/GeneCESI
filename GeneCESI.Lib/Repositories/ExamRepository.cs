
using GeneCESI.Lib.Objects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneCESI.Lib.Repositories
{
    public interface IExamRepository : IRepository<Exam>
    {

    }

    public class ExamRepository : IExamRepository
    {
        public IDbConnection _connection { get; set; }
        public IDbCommand _command { get; set; }

        public ExamRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        #region CRUD
        public void Insert(Exam entity)
        {
            try
            {
                _command = new SqlCommand("INSERT INTO dbo.[Exams](Label, NbrQuestions, Time, End_Date, Tries) " +
                    "VALUES(@Label, @NbrQuestions, @Time, @End_Date, @Tries)", _connection as SqlConnection);

                _command.Parameters.Add(new SqlParameter("@Label", entity.Label));
                _command.Parameters.Add(new SqlParameter("@NbrQuestions", entity.NbrQuestions));
                _command.Parameters.Add(new SqlParameter("@Time", entity.Time));
                _command.Parameters.Add(new SqlParameter("@End_Date", entity.EndDate));
                _command.Parameters.Add(new SqlParameter("@Tries", entity.Tries));

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

        public void Delete(Exam entity)
        {
            try
            {
                _command = new SqlCommand("DELETE FROM dbo.Exams WHERE Id = @ID", _connection as SqlConnection);
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

        public Exam GetById(UInt32 id)
        {
            Exam exam = new Exam(String.Empty, String.Empty);

            try
            {
                _command = new SqlCommand("SELECT * FROM dbo.Exams WHERE Id = @ID", _connection as SqlConnection);
                _command.Parameters.Add(new SqlParameter("@ID", id));

                _connection.Open();
                SqlDataReader results = _command.ExecuteReader() as SqlDataReader;

                while (results.Read())
                {
                    //TODO
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

            return exam;
        }

        public IQueryable<Exam> GetAll()
        {
            IQueryable<Exam> users = new List<Exam>().AsQueryable();

            try
            {
                _command = new SqlCommand("SELECT * FROM dbo.Exams", _connection as SqlConnection);

                _connection.Open();
                SqlDataReader results = _command.ExecuteReader() as SqlDataReader;

                while (results.Read())
                {
                    //TODO
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

            return users;
        }
        #endregion
    }
}
