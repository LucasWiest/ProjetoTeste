using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoTeste.Models
{
    public class Clients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        public required string Name { get; set; }
        public required DateOnly Birth { get; set; } 
        public required string Profession { get; set; } 

        public required decimal GrossSalary { get; set; }

        public required decimal Discount { get; set; }

        public required decimal NetSalary { get; set; } 

        public Professions? Professions { get; set; }

    }
}
