namespace ViewModelApplication.Models
{
    public class Mevki
    {
        public int MevkiID { get; set; }
        public string MevkiAdi { get; set; }
        public ICollection<Futbolcu> Futbolcular { get; set; }
    }
}
