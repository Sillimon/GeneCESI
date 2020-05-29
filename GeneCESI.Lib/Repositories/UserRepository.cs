using GeneCESI.Lib.Helpers;
using GeneCESI.Lib.Objects;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneCESI.Lib.Repositories
{
    public interface IUserRepository : IRepository<User>
    {

    }
    public class UserRepository : IUserRepository
    {
        public IDbConnection _connection { get; set; }
        public IDbCommand _command { get; set; }

        public UserRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public User ReaderToObject(IDataReader reader)
        {
            var user = new User();

            user.Id = (int)reader[0];
            user.Name = (string)reader[1];
            user.Firstname = (string)reader[2];
            user.Roles = (bool)reader[3];
            user.Email = (string)reader[4];
            user.Password = (string)reader[5];

            return user;
        }

        #region CRUD
        public void Insert(User entity)
        {
            try
            {
                _command = new SqliteCommand("INSERT INTO [Users](Name, Firstname, Roles, Email, Password) " +
                    "VALUES(@Name, @Firstname, @Roles, @Email, @Password)", _connection as SqliteConnection);

                _command.Parameters.Add(new SqliteParameter("@Name", entity.Name));
                _command.Parameters.Add(new SqliteParameter("@Firstname", entity.Firstname));
                _command.Parameters.Add(new SqliteParameter("@Roles", entity.Roles));
                _command.Parameters.Add(new SqliteParameter("@Email", entity.Email));
                _command.Parameters.Add(new SqliteParameter("@Password", CommonHelpers.ComputeHash(entity.Password)));

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

        public void Delete(User entity)
        {
            try
            {
                _command = new SqliteCommand("DELETE FROM Users WHERE Id = @ID", _connection as SqliteConnection);
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
        
        public User GetById(int id)
        {
            User user = new User();
            user.Id = id;

            try
            {
                _command = new SqliteCommand("SELECT * FROM Users WHERE Id = @ID", _connection as SqliteConnection);
                _command.Parameters.Add(new SqliteParameter("@ID", id));

                _connection.Open();
                SqliteDataReader results = _command.ExecuteReader() as SqliteDataReader;

                while (results.Read())
                {
                    user = ReaderToObject(results);
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

            return user;
        }
        
        public IQueryable<User> GetAll()
        {
            var users = new List<User>();

            try
            {
                _command = new SqliteCommand("SELECT * FROM Users", _connection as SqliteConnection);

                _connection.Open();
                SqliteDataReader results = _command.ExecuteReader() as SqliteDataReader;

                while (results.Read())
                    users.Add(ReaderToObject(results));

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

            return users.AsQueryable();
        }
        #endregion

        public User UserLoggin(string email, string password)
        {
            User loggingInUser = new User();
            try
            {
                _command = new SqliteCommand("SELECT * FROM Users WHERE Email = @email AND Password = @password", _connection as SqliteConnection);
                _command.Parameters.Add(new SqliteParameter("@email", email));
                _command.Parameters.Add(new SqliteParameter("@password", CommonHelpers.ComputeHash(password)));

                _connection.Open();
                SqliteDataReader results = _command.ExecuteReader() as SqliteDataReader;

                if (!results.HasRows)
                    return null;

                while (results.Read())
                    loggingInUser = ReaderToObject(results);

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

            return loggingInUser;
        }
    }
}
