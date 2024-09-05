using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApp.Domain
{
    public class Oyuncu : BaseClass
    {
        public string OyuncuAdi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Biyografi { get; set; }
    }
}
