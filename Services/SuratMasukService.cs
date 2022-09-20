using System;
using System.Collections.Generic;
using System.Text;
using DTSMCC01_MiniProject1.Models;
using System.Data.SqlClient;

namespace DTSMCC01_MiniProject1.Services
{
    class SuratMasukService
    {
        SqlConnection sqlConnection;

        string connectionString = "Data Source=DESKTOP-BMTQ0KM;Initial Catalog=DTSMCC01;User ID=ryan;Password=123456;";
        public void Insert(SuratMasuk suratMasuk)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "INSERT INTO surat_masuk " +
                        "(id, tgl_masuk, no_surat, kode_surat, asal_surat, perihal, lampiran, keterangan, karyawan_id) " +
                        $"VALUES ({suratMasuk.Id}, '{suratMasuk.TanggalMasuk}', '{suratMasuk.NomorSurat}', " +
                        $"'{suratMasuk.KodeSurat}', '{suratMasuk.AsalSurat}', " +
                        $"'{suratMasuk.Perihal}', '{suratMasuk.Lampiran}', " +
                        $"'{suratMasuk.Keterangan}', {suratMasuk.KaryawanId}) ";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Surat dengan nomor {suratMasuk.NomorSurat} berhasil ditambahkan!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void UpdateById(int id, SuratMasuk suratMasuk)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "UPDATE surat_masuk " +
                        $"SET tgl_masuk = '{suratMasuk.TanggalMasuk}', " +
                        $"no_surat = '{suratMasuk.NomorSurat}', " +
                        $"kode_surat = '{suratMasuk.KodeSurat}', " +
                        $"asal_surat = '{suratMasuk.AsalSurat}', " +
                        $"perihal = '{suratMasuk.Perihal}', " +
                        $"lampiran = '{suratMasuk.Lampiran}', " +
                        $"keterangan = '{suratMasuk.Keterangan}', " +
                        $"karyawan_id = '{suratMasuk.KaryawanId}' " +
                        $"WHERE id = {id}";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Surat dengan nomor {suratMasuk.NomorSurat} berhasil diperbarui!");
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
                    sqlCommand.CommandText = "DELETE FROM surat_masuk " +
                        $"WHERE id = {id}";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Surat berhasil dihapus!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void GetAll()
        {
            string query = "SELECT * FROM surat_masuk";

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
                            for (int i = 0; i < 9; i++)
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
            string query = $"SELECT * FROM surat_masuk WHERE Id = {id}";


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
                            for (int i = 0; i < 9; i++)
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
