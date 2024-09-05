using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Domain
{
    public class OyuncuFilm : BaseClass
    {
        public int CalismaGunu { get; set; }
        public int OyuncuID { get; set; }
        public Oyuncu Oyuncu { get; set; }
        public int FilmID { get; set; }
        public Film Film { get; set; }
    }
}
