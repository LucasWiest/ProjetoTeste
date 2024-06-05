using ProjetoTeste.Models;

namespace ProjetoTeste.Repository.Client
{
    public interface IClientRep
    {
        public Task<List<Clients>> Save(List<Clients> clients);

        public Task<Clients> Save (Clients client);

        public Task<List<Clients>> GetAll();

    }
}
