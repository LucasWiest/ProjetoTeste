using AutoMapper;
using ProjetoTeste.Models;
using ProjetoTeste.Repository.Client;
using ProjetoTeste.Views.Client;

namespace ProjetoTeste.Services.Client
{
    public class ClientService : IClientService
    {

        private readonly IClientRep _clientRep;

        private readonly IMapper _mapper;

        public ClientService (IClientRep clientRep, IMapper mapper)
        {
            this._clientRep = clientRep; 
            this._mapper = mapper;
        }

        public async Task<List<ClientView>> Save (List<ClientView> clientViews)
        {
            return _mapper.Map<List<ClientView>>(await _clientRep.Save(_mapper.Map<List<Clients>>(clientViews))); 
        } 

        public async Task<ClientView> Save (ClientView clientView)
        {
            return _mapper.Map<ClientView>(await _clientRep.Save(_mapper.Map<Clients>(clientView)));
        }

        public async Task<List<ClientView>> GetAll ()
        {
            return _mapper.Map<List<ClientView>>(await _clientRep.GetAll());
        }

    }
}
