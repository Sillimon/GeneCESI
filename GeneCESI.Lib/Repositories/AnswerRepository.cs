using GeneCESI.Lib.Helpers;
using GeneCESI.Lib.Objects;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GeneCESI.Lib.Helpers.EnumHelper;

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

        public Answer ReaderToObject(IDataReader reader)
        {
            var answer = new Answer();

            answer.Id = (int)reader[0];
            answer.Correct = (string)reader[1];
            answer.Statements = (string)reader[2];

            return answer;
        }

        #region CRUD
        public void Insert(Answer entity)
        {
            try
            {
                _command = new SqliteCommand("INSERT INTO [Answers](Correct, Statements) " +
                    "VALUES(@Correct, @Statements)", _connection as SqliteConnection);

                _command.Parameters.Add(new SqliteParameter("@Correct", entity.Correct));
                _command.Parameters.Add(new SqliteParameter("@Statements", entity.Statements));

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
                _command = new SqliteCommand("DELETE FROM Answers WHERE Id = @ID", _connection as SqliteConnection);
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

        public Answer GetById(int id)
        {
            Answer answer = new Answer();
            answer.Id = (int)id;

            try
            {
                _command = new SqliteCommand("SELECT * FROM Answers WHERE Id = @ID", _connection as SqliteConnection);
                _command.Parameters.Add(new SqliteParameter("@ID", id));

                _connection.Open();
                SqliteDataReader results = _command.ExecuteReader() as SqliteDataReader;

                while (results.Read())
                {
                    answer = ReaderToObject(results);
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
            var answers = new List<Answer>();

            try
            {
                _command = new SqliteCommand("SELECT * FROM Answer", _connection as SqliteConnection);

                _connection.Open();
                SqliteDataReader results = _command.ExecuteReader() as SqliteDataReader;

                while (results.Read())
                    answers.Add(ReaderToObject(results));

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

            return answers.AsQueryable();
        }
        #endregion
    }
}
