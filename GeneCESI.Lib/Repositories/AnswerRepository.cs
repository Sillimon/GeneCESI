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
    public interface IAnswerRepository : IRepository<Answer>
    {

    }

    public class AnswerRepository : IAnswerRepository
    {
        public IDbConnection _connection { get; set; }
        public IDbCommand _command { get; set; }

        public AnswerRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        #region CRUD
        public void Insert(Answer entity)
        {
            try
            {
                _command = new SqlCommand("INSERT INTO dbo.[Answers](Correct, Type, Statements) " +
                    "VALUES(@Correct, @Type, @Statements)", _connection as SqlConnection);

                _command.Parameters.Add(new SqlParameter("@Name", entity.Correct));
                _command.Parameters.Add(new SqlParameter("@Firstname", entity.Type));
                _command.Parameters.Add(new SqlParameter("@Roles", entity.Statements));

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

        public void Delete(Answer entity)
        {
            try
            {
                _command = new SqlCommand("DELETE FROM dbo.Answers WHERE Id = @ID", _connection as SqlConnection);
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

        public Answer GetById(UInt32 id)
        {
            Answer answer = new Answer(String.Empty, String.Empty);

            try
            {
                _command = new SqlCommand("SELECT * FROM dbo.Answers WHERE Id = @ID", _connection as SqlConnection);
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

            return answer;
        }

        public IQueryable<Answer> GetAll()
        {
            IQueryable<Answer> users = new List<Answer>().AsQueryable();

            try
            {
                _command = new SqlCommand("SELECT * FROM dbo.Answer", _connection as SqlConnection);

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
