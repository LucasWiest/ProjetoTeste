using ProjetoTeste.Views.Client;

namespace ProjetoTeste.Services.Client
{
    public interface IClientService
    {
        public Task<List<ClientView>> GetAll();

        public Task<ClientView> Save(ClientView clientView);

        public Task<List<ClientView>> Save(List<ClientView> clientViews);
    }
}
