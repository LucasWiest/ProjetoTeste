using ProjetoTeste.Types.Curreancy;

namespace ProjetoTeste.Models
{
    public class Professions
    { 
        public required string Description { get; set; }
        public Currency? AverageWage { get; set; } 

        public ICollection<Clients>? Clients { get; set; } 
    }
}
