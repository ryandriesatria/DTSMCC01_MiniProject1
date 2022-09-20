using System;
using System.Collections.Generic;
using System.Text;

namespace DTSMCC01_MiniProject1.Models
{
    class Disposisi
    {
        public int Id { get; set; }
        public int KaryawanId { get; set; }
        public int SuratMasukId { get; set; }
        public string StatusDisposisi { get; set; }
        public string Isi { get; set; }
        public string Kepentingan { get; set; }
        public string Catatan { get; set; }

    }
}
