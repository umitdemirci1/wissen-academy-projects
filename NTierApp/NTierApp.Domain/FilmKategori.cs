using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Domain
{
    public class FilmKategori : BaseClass
    {
        public string KategoriAdi { get; set; }
        public ICollection<Film> Filmler { get; set; }
    }
}
