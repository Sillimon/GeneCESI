using GeneCESI.Lib.Helpers;
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
                _command = new SqlCommand("INSERT INTO dbo.[Users](Name, Firstname, Roles, Email, Password) " +
                    "VALUES(@Name, @Firstname, @Roles, @Email, @Password)", _connection as SqlConnection);

                _command.Parameters.Add(new SqlParameter("@Name", entity.Name));
                _command.Parameters.Add(new SqlParameter("@Firstname", entity.Firstname));
                _command.Parameters.Add(new SqlParameter("@Roles", entity.Roles));
                _command.Parameters.Add(new SqlParameter("@Email", entity.Email));
                _command.Parameters.Add(new SqlParameter("@Password", CommonHelpers.ComputeHash(entity.Password)));

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
                _command = new SqlCommand("DELETE FROM dbo.Users WHERE Id = @ID", _connection as SqlConnection);
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
        
        public User GetById(int id)
        {
            User user = new User();
            user.Id = id;

            try
            {
                _command = new SqlCommand("SELECT * FROM dbo.Users WHERE Id = @ID", _connection as SqlConnection);
                _command.Parameters.Add(new SqlParameter("@ID", id));

                _connection.Open();
                SqlDataReader results = _command.ExecuteReader() as SqlDataReader;

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
                _command = new SqlCommand("SELECT * FROM dbo.Users", _connection as SqlConnection);

                _connection.Open();
                SqlDataReader results = _command.ExecuteReader() as SqlDataReader;

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
                _command = new SqlCommand("SELECT * FROM dbo.Users WHERE Email = @email AND Password = @password", _connection as SqlConnection);
                _command.Parameters.Add(new SqlParameter("@email", email));
                _command.Parameters.Add(new SqlParameter("@password", CommonHelpers.ComputeHash(password)));

                _connection.Open();
                SqlDataReader results = _command.ExecuteReader() as SqlDataReader;

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
