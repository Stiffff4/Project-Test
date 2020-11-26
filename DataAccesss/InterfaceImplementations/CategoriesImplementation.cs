using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DataAccesss.Interfaces;
using DataAccesss.Models;

namespace DataAccesss.InterfaceImplementations
{
    public class CategoriesImplementation : ICategories
    {
        private Database.HbrDBEntities db = new Database.HbrDBEntities();
        public List<Categories> Retrieve()
        {
            List<Categories> categoryList = new List<Categories>();

            using (SqlConnection sqlConnection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("GetAllCategories", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    Categories category = new Categories
                    {
                        categoryId = Convert.ToInt32(dataReader["CategoryID"]),
                        categoryName = dataReader["CategoryName"].ToString()
                    };

                    categoryList.Add(category);
                }

                sqlConnection.Close();
            }
            return categoryList;
        }
        public void Create(Categories category)
        {
            using (SqlConnection sqlConnection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("CreateCategory", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@CategoryName", category.categoryName);
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
        public void Update(Categories category)
        {
            using (SqlConnection sqlConnection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("EditCategory", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@CategoryID", category.categoryId);
                sqlCommand.Parameters.AddWithValue("@CategoryName", category.categoryName);
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
        public void Delete(Categories category)
        {
            using (SqlConnection sqlConnection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("DeleteCategory", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@CategoryID", category.categoryId);
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
    }
}