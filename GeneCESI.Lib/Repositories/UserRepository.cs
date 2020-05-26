using GeneCESI.Lib.Object;
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
                _command.Parameters.Add(new SqlParameter("@Password", entity.Password));

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
                _command.Parameters.Add(new SqlParameter("@Id", entity.Id));

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

        public User GetById(UInt32 id)
        {
            User user = new User(String.Empty, String.Empty);

            try
            {
                _command = new SqlCommand("SELECT * FROM dbo.Users WHERE Id = @ID", _connection as SqlConnection);
                _command.Parameters.Add(new SqlParameter("@Id", id));

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

            return user;
        }

        public IQueryable<User> GetAll()
        {
            IQueryable<User> users = new List<User>().AsQueryable();

            try
            {
                _command = new SqlCommand("SELECT * FROM dbo.Users", _connection as SqlConnection);

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
