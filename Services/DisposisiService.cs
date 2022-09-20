using System;
using System.Collections.Generic;
using System.Text;
using DTSMCC01_MiniProject1.Models;
using System.Data.SqlClient;

namespace DTSMCC01_MiniProject1.Services
{
    class DisposisiService
    {
        SqlConnection sqlConnection;

        string connectionString = "Data Source=DESKTOP-BMTQ0KM;Initial Catalog=DTSMCC01;User ID=ryan;Password=123456;";
        public void Insert(Disposisi disposisi)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "INSERT INTO disposisi " +
                        "(id, karyawan_id, surat_masuk_id, status_disposisi, isi, kepentingan, catatan) " +
                        $"VALUES ({disposisi.Id}, {disposisi.KaryawanId}, {disposisi.SuratMasukId}, " +
                        $"'{disposisi.StatusDisposisi}', '{disposisi.Isi}', '{disposisi.Kepentingan}', '{disposisi.Catatan}')";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Surat berhasil didisposisi!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void UpdateById(int id, Disposisi disposisi)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "UPDATE disposisi " +
                        $"SET karyawan_id = {disposisi.KaryawanId}, " +
                        $"surat_masuk_id = {disposisi.SuratMasukId}, " +
                        $"status_disposisi = '{disposisi.StatusDisposisi}', " +
                        $"isi = '{disposisi.Isi}', " +
                        $"kepentingan = '{disposisi.Kepentingan}', " +
                        $"catatan = '{disposisi.Catatan}' " +
                        $"WHERE id = {id}";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Disposisi berhasil diperbarui");
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
                    sqlCommand.CommandText = "DELETE FROM disposisi " +
                        $"WHERE id = {id}";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Disposisi Surat berhasil dihapus!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void GetAll()
        {
            string query = "SELECT * FROM disposisi";

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
                            for (int i = 0; i < 7; i++)
                            {
                                Console.Write(sqlDataReader[i] + "\t");
                            }
                            Console.WriteLine();
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
            string query = $"SELECT * FROM disposisi WHERE Id = {id}";


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
                            for (int i = 0; i < 7; i++)
                            {
                                Console.Write(sqlDataReader[i] + "\t");
                            }
                            Console.WriteLine();
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
