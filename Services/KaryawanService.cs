using System;
using System.Collections.Generic;
using System.Text;
using DTSMCC01_MiniProject1.Models;
using System.Data.SqlClient;

namespace DTSMCC01_MiniProject1.Services
{
    class KaryawanService
    {
        SqlConnection sqlConnection;

        string connectionString = "Data Source=DESKTOP-BMTQ0KM;Initial Catalog=DTSMCC01;User ID=ryan;Password=123456;";
        public void Insert(Karyawan karyawan)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "INSERT INTO karyawan " +
                        "(id, username, password, email, jabatan) " +
                        $"VALUES ({karyawan.Id}, '{karyawan.Username}', '{karyawan.Password}', '{karyawan.Email}', '{karyawan.Jabatan}')";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Karyawan dengan username {karyawan.Username} berhasil ditambahkan!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void UpdateById(int id, Karyawan karyawan)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "UPDATE karyawan " +
                        $"SET username = '{karyawan.Username}', " +
                        $"password = '{karyawan.Password}', " +
                        $"email = '{karyawan.Email}', " +
                        $"jabatan = '{karyawan.Jabatan}' " +
                        $"WHERE id = {id}";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Karyawan dengan username {karyawan.Username} berhasil diperbarui!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void DeleteById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "DELETE FROM karyawan " +
                        $"WHERE id = {id}";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Karyawan berhasil dihapus!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void GetAll()
        {
            string query = "SELECT * FROM Karyawan";

            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            
                            Console.WriteLine(sqlDataReader[1] + " - " + sqlDataReader[3] + " - " + sqlDataReader[4]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void GetById(int id)
        {
            string query = $"SELECT * FROM Karyawan WHERE Id = {id}";


            sqlConnection = new SqlConnection(connectionString);
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            try
            {
                sqlConnection.Open();
                using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
                {
                    if (sqlDataReader.HasRows)
                    {
                        while (sqlDataReader.Read())
                        {
                            
                            Console.WriteLine(sqlDataReader[1] + " - " + sqlDataReader[3] + " - " + sqlDataReader[4]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Data Rows");
                    }
                    sqlDataReader.Close();
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
