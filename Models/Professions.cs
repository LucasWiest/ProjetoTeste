namespace ProjetoTeste.Models
{
    public class Professions
    { 
        public required string Description { get; set; }
        public decimal? AverageWage { get; set; } 

        public ICollection<Clients>? Clients { get; set; } 
    }
}
