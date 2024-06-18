
namespace ProjetoTeste.Views.Client
{
    public class ClientView
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; }
        public DateOnly Birth { get; set; }
        public required string Profession { get; set; }

        public decimal GrossSalary { get; set; }

        public decimal Discount { get; set; }

        public decimal NetSalary { get; set; }

    }
}
