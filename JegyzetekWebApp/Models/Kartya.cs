namespace JegyzetekWebApp.Models
{
    public class Kartya
    {
        public int Id { get; set; }
        public string? Nev { get; set; }
        public ICollection<Teendo> Teendok { get; set; }
    }
}
