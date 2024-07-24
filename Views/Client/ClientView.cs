
namespace ProjetoTeste.Views.Client
{
    public class ClientView
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; }
        public required DateOnly Birth { get; set; }
        public required string Profession { get; set; }

        public required decimal GrossSalary { get; set; }

        public required decimal Discount { get; set; }

        public required decimal NetSalary { get; set; }

    }
}
