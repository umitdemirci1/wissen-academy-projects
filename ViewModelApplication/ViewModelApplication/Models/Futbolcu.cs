namespace ViewModelApplication.Models
{
    public class Futbolcu
    {
        public int FutbolcuID { get; set; }
        public string AdiSoyadi { get; set; }
        public int Yas { get; set; }
        public int MevkiID { get; set; }
        public int TakimID { get; set; }
        public Mevki Mevki { get; set; }
        public Takim Takim { get; set; }
    }
}
