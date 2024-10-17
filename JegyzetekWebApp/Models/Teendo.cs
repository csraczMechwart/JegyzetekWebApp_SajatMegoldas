namespace JegyzetekWebApp.Models
{
    public class Teendo
    {
        public int Id { get; set; }
        public string? Tartalom { get; set; }
        public DateTime Letrehozve { get; set; }
        public DateTime Modositva { get; set; }
        public bool Kesz { get; set; }
        public int KartyaId { get; set; }
        public Kartya Kartya { get; set; }
    }
}
