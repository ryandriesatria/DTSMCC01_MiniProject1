using System;
using System.Collections.Generic;
using System.Text;

namespace DTSMCC01_MiniProject1.Models
{
    class SuratMasuk
    {
        public int Id { get; set; }
        public string TanggalMasuk{ get; set; }
        public string NomorSurat{ get; set; }
        public string KodeSurat{ get; set; }
        public string AsalSurat{ get; set; }
        public string Perihal{ get; set; }
        public string Lampiran{ get; set; }
        public string Keterangan{ get; set; }
        public int KaryawanId{ get; set; }
        



    }
}
