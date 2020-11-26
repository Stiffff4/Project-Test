using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DataAccesss.Interfaces;
using DataAccesss.Models;

namespace DataAccesss.InterfaceImplementations
{
    public class ProductsImplementation : IProducts
    {
        private readonly Database.HbrDBEntities db = new Database.HbrDBEntities();
        public List<Products> Retrieve()
        {
            List<Products> productList = new List<Products>();

            using (SqlConnection sqlConnection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("GetAllProducts", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlConnection.Open();

                SqlDataReader dataReader = sqlCommand.ExecuteReader();

                while (dataReader.Read())
                {
                    Products product = new Products
                    {
                        productId = Convert.ToInt32(dataReader["ProductId"]),
                        productName = dataReader["ProductName"].ToString(),
                        productDescription = dataReader["ProductDescription"].ToString(),
                        productCost = Convert.ToInt32(dataReader["ProductCost"]),
                        categoryId = Convert.ToInt32(dataReader["CategoryId"]),
                        categoryName = dataReader["CategoryName"].ToString(),
                    };

                    productList.Add(product);
                }

                sqlConnection.Close();
            }
            return productList;
        }
        public void Create(Products product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("CreateProduct", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@ProductName", product.productName);
                sqlCommand.Parameters.AddWithValue("@ProductDescription", product.productDescription);
                sqlCommand.Parameters.AddWithValue("@ProductCost", product.productCost);
                sqlCommand.Parameters.AddWithValue("@CategoryId", product.categoryId);
                sqlCommand.Parameters.AddWithValue("@CategoryName", product.categoryName);
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
        public void Update(Products product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("EditProduct", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@ProductID", product.productId);
                sqlCommand.Parameters.AddWithValue("@ProductName", product.productName);
                sqlCommand.Parameters.AddWithValue("@ProductDescription", product.productDescription);
                sqlCommand.Parameters.AddWithValue("@ProductCost", product.productCost);
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
        public void Delete(Products product)
        {
            using (SqlConnection sqlConnection = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("DeleteProduct", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.Clear();
                sqlCommand.Parameters.AddWithValue("@ProductID", product.productId);
                sqlCommand.ExecuteNonQuery();

                sqlConnection.Close();
            }
        }
    }
}