using System;
using DTSMCC01_MiniProject1.Services;
using DTSMCC01_MiniProject1.Models;

namespace DTSMCC01_MiniProject1
{
    class Program
    {
        static void Main(string[] args)
        {
            //CRUD Tabel Karyawan
            Karyawan newKaryawan = new Karyawan()
            {
                Id = 3,
                Username = "kepsek",
                Password = "12345",
                Email = "kepsek@sekolah.com",
                Jabatan = "Kepala Sekolah"
            };

            KaryawanService karyawanService = new KaryawanService();

            karyawanService.Insert(newKaryawan);

            newKaryawan = new Karyawan()
            {
                Id = 3,
                Username = "kepsek1",
                Password = "12345",
                Email = "kepsek@sekolah.com",
                Jabatan = "Kepala Sekolah"
            };


            karyawanService.UpdateById(3, newKaryawan);

            karyawanService.GetAll();

            karyawanService.GetById(2);

            karyawanService.DeleteById(3);

            //CRUD Tabel Surat Masuk
            SuratMasuk newSuratMasuk = new SuratMasuk()
            {
                Id = 2,
                TanggalMasuk = DateTime.Now.ToString(),
                NomorSurat = "SM-002",
                KodeSurat = "43CV",
                AsalSurat = "DTS",
                Perihal = "Pelatihan",
                Lampiran = "modul.pdf",
                Keterangan = "check",
                KaryawanId = 1
            };

            SuratMasukService suratMasukService = new SuratMasukService();

            suratMasukService.Insert(newSuratMasuk);

            newSuratMasuk = new SuratMasuk()
            {
                Id = 2,
                TanggalMasuk = DateTime.Now.ToString(),
                NomorSurat = "SM-002",
                KodeSurat = "43CV",
                AsalSurat = "DTS",
                Perihal = "Pelatihan DTS",
                Lampiran = "modul.pdf",
                Keterangan = "check",
                KaryawanId = 1
            };

            suratMasukService.UpdateById(2, newSuratMasuk);

            suratMasukService.GetAll();

            suratMasukService.GetById(1);

            suratMasukService.DeleteById(2);

            //CRUD Tabel Surat Keluar
            SuratKeluar newSuratKeluar = new SuratKeluar()
            {
                Id = 2,
                TanggalTerbit = DateTime.Now.ToString(),
                NomorSurat = "SK-002",
                KodeSurat = "41CV",
                TujuanSurat = "Peserta",
                Perihal = "Pelatihan",
                Lampiran = "modul.pdf",
                Keterangan = "check",
                KaryawanId = 1,
                SuratMasukId = 1
            };

            SuratKeluarService suratKeluarService = new SuratKeluarService();

            suratKeluarService.Insert(newSuratKeluar);

            newSuratKeluar = new SuratKeluar()
            {
                Id = 2,
                TanggalTerbit = DateTime.Now.ToString(),
                NomorSurat = "SK-002",
                KodeSurat = "41CV",
                TujuanSurat = "Peserta DTS",
                Perihal = "Pelatihan",
                Lampiran = "modul.pdf",
                Keterangan = "check",
                KaryawanId = 1,
                SuratMasukId = 1
            };

            suratKeluarService.UpdateById(2, newSuratKeluar);

            suratKeluarService.GetAll();

            suratKeluarService.GetById(1);

            suratKeluarService.DeleteById(2);

            //CRUD Disposisi
            Disposisi newDisposisi = new Disposisi()
            {
                Id = 1,
                KaryawanId = 2,
                SuratMasukId = 1,
                StatusDisposisi = "Terdisposisi",
                Isi = "Review Modul",
                Kepentingan = "Cukup penting",
                Catatan = "-"
            };

            DisposisiService disposisiService = new DisposisiService();

            disposisiService.Insert(newDisposisi);

            newDisposisi = new Disposisi()
            {
                Id = 1,
                KaryawanId = 2,
                SuratMasukId = 1,
                StatusDisposisi = "Terdisposisi",
                Isi = "Review Modul 2",
                Kepentingan = "Cukup penting",
                Catatan = "-"
            };

            disposisiService.UpdateById(1, newDisposisi);

            disposisiService.GetAll();

            disposisiService.DeleteById(1);
        }
    }
}
