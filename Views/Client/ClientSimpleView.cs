namespace ProjetoTeste.Views.Client
{
    public class ClientSimpleView
    {
        public required Guid Id { get; set; }

        public required string Name { get; set; }
        public required DateOnly Birth { get; set; }
    }
}
