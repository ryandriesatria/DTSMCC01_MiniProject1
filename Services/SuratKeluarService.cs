using System;
using System.Collections.Generic;
using System.Text;
using DTSMCC01_MiniProject1.Models;
using System.Data.SqlClient;

namespace DTSMCC01_MiniProject1.Services
{
    class SuratKeluarService
    {
        SqlConnection sqlConnection;

        string connectionString = "Data Source=DESKTOP-BMTQ0KM;Initial Catalog=DTSMCC01;User ID=ryan;Password=123456;";
        public void Insert(SuratKeluar suratKeluar)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "INSERT INTO surat_keluar " +
                        "(id, tgl_terbit, no_surat, kode_surat, tujuan_surat, perihal, lampiran, keterangan, karyawan_id, surat_masuk_id) " +
                        $"VALUES ({suratKeluar.Id}, '{suratKeluar.TanggalTerbit}', '{suratKeluar.NomorSurat}', " +
                        $"'{suratKeluar.KodeSurat}', '{suratKeluar.TujuanSurat}', " +
                        $"'{suratKeluar.Perihal}', '{suratKeluar.Lampiran}', " +
                        $"'{suratKeluar.Keterangan}', {suratKeluar.KaryawanId}, {suratKeluar.SuratMasukId}) ";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Surat dengan nomor {suratKeluar.NomorSurat} berhasil ditambahkan!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public void UpdateById(int id, SuratKeluar suratKeluar)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlTransaction sqlTransaction = sqlConnection.BeginTransaction();

                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.Transaction = sqlTransaction;

                try
                {
                    sqlCommand.CommandText = "UPDATE surat_keluar " +
                        $"SET tgl_terbit = '{suratKeluar.TanggalTerbit}', " +
                        $"no_surat = '{suratKeluar.NomorSurat}', " +
                        $"kode_surat = '{suratKeluar.KodeSurat}', " +
                        $"tujuan_surat = '{suratKeluar.TujuanSurat}', " +
                        $"perihal = '{suratKeluar.Perihal}', " +
                        $"lampiran = '{suratKeluar.Lampiran}', " +
                        $"keterangan = '{suratKeluar.Keterangan}', " +
                        $"karyawan_id = '{suratKeluar.KaryawanId}', " +
                        $"surat_masuk_id = '{suratKeluar.SuratMasukId}' " +
                        $"WHERE id = {id}";
                    sqlCommand.ExecuteNonQuery();
                    sqlTransaction.Commit();
                    Console.WriteLine($"Surat dengan nomor {suratKeluar.NomorSurat} berhasil diperbarui!");
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
                    sqlCommand.CommandText = "DELETE FROM surat_keluar " +
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
            string query = "SELECT * FROM surat_keluar";

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
                            for (int i = 0; i < 10; i++)
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
            string query = $"SELECT * FROM surat_keluar WHERE Id = {id}";


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
                            for (int i = 0; i < 10; i++)
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
