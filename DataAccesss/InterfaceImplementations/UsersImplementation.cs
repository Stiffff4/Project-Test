using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using DataAccesss.Interfaces;
using DataAccesss.Models;

namespace DataAccesss.InterfaceImplementations
{
    public class UsersImplementation : IUsers
    {
        private readonly Database.HbrDBEntities db = new Database.HbrDBEntities();
        public void Create(Users user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("CreateUser", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@UserName", user.userName);
                sqlCommand.Parameters.AddWithValue("@UserFirstName", user.userFirstName);
                sqlCommand.Parameters.AddWithValue("@UserLastName", user.userLastName);
                sqlCommand.Parameters.AddWithValue("@UserEmail", user.userEmail);
                sqlCommand.Parameters.AddWithValue("@UserPassword", HashPassword(user.userPassword));
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
        public string[] GetUser(string userName)
        {
            string[] arrayUser = new string[2];

            using (SqlConnection sqlConnection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("GetUsersFromUser", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@UserName", userName);

                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();


                while (dataReader.Read())
                {
                    Users userFromDatabase = new Users
                    {
                        userName = dataReader["UserName"].ToString(),
                        userPassword = dataReader["UserPassword"].ToString(),
                    };

                    arrayUser[0] = userFromDatabase.userName;
                    arrayUser[1] = userFromDatabase.userPassword;
                }
                sqlConnection.Close();
            }
            return arrayUser;
        }
        public string HashPassword(string password)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream;
            stream = sha256.ComputeHash(encoding.GetBytes(password));
            return Convert.ToBase64String(stream);
        }

        public bool IsUserValid(Users user)
        {
            string userName = user.userName;
            string hashedPassword = HashPassword(user.userPassword);

            string[] arrayUser = GetUser(user.userName); 

            if (userName == arrayUser[0])
                {
                    if (hashedPassword == arrayUser[1])
                    {
                        return true;
                    }
                }

                return false;
        }

        public List<Users> GetUserList(string username)
        {
            List<Users> userList = new List<Users>();

            using (SqlConnection sqlConnection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("GetUsersFromUser", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@UserName", username);

                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    Users userFromDB = new Users
                    {
                        userId = Convert.ToInt32(dataReader["UserId"]),
                        userFirstName = dataReader["UserFirstName"].ToString(),
                        userLastName = dataReader["UserLastName"].ToString(),
                        userName = dataReader["UserName"].ToString(),
                        userEmail = dataReader["UserEmail"].ToString(),
                        userPassword = dataReader["UserPassword"].ToString()
                    };
                    userList.Add(userFromDB);
                }
                sqlConnection.Close();
            }
            return userList;
        }
        public void Update(Users user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("EditUser", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@UserID", user.userId);
                sqlCommand.Parameters.AddWithValue("@UserName", user.userName);
                sqlCommand.Parameters.AddWithValue("@UserFirstName", user.userFirstName);
                sqlCommand.Parameters.AddWithValue("@UserLastName", user.userLastName);
                sqlCommand.Parameters.AddWithValue("@UserEmail", user.userEmail);
                sqlCommand.Parameters.AddWithValue("@UserPassword", HashPassword(user.userPassword));
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
        public void Delete(Users user)
        {
            using (SqlConnection sqlConnection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("DeleteUser", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@UserID", user.userId);
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
    }
}