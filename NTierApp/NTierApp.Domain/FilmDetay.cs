using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Domain
{
    public class FilmDetay : BaseClass
    {
        public string FilmAciklama { get; set; }
        public int FilmID { get; set; }
        public Film Film { get; set; }
    }
}
