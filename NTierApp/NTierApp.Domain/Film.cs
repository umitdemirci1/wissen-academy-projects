using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Domain
{
    public class Film : BaseClass
    {
        public string FilmAdi { get; set; }
        public DateTime SonYayinTarihi { get; set; }
        public int IzlenmeSayisi { get; set; }
        public int KategoriID { get; set; }
        public FilmKategori FilmKategori { get; set; }
        public int FilmDetayID { get; set; }
        public FilmDetay FilmDetay { get; set; }
        public ICollection<OyuncuFilm> FilmOyunculari { get; set; }
    }
}
