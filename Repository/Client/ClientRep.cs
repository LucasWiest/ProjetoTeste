using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using ProjetoTeste.Data;
using ProjetoTeste.Models;

namespace ProjetoTeste.Repository.Client
{
    public class ClientRep : IClientRep
    {
        private readonly ApplicationDbContext _dbContext;

        public ClientRep (ApplicationDbContext dbContext) 
        {
            this._dbContext = dbContext;
        } 

        public async Task<List<Clients>> Save (List<Clients> clients)
        {
            var withId = clients.FindAll(x => x.Id != Guid.Empty);

            var noId = clients.FindAll(x => x.Id == Guid.Empty);

            if (withId.Count > 0)
                await Update(withId);  

            if (noId.Count > 0)
                await Insert(noId);

            return clients;
        }

        public async Task<Clients> Save (Clients clients)
        {

            if (clients.Id == null || clients.Id == Guid.Empty)
                await Insert(clients); 
            else 
                await Update(clients);

            return clients;
        } 

        private async Task<Clients> Insert (Clients clients)
        {

            await _dbContext.AddAsync(clients);

            await _dbContext.SaveChangesAsync();

            return clients;
        }

        private async Task<List<Clients>> Insert (List<Clients> clients)
        {
            await _dbContext.AddRangeAsync(clients);

            await _dbContext.SaveChangesAsync();

            return clients;
        }

        private async Task Update (Clients clients)
        {

            await Task.Run(() =>
            {
                _dbContext.Update(clients);
            });

            return;
        }


        private async Task Update(List<Clients> clients)
        {

            await Task.Run(() =>
            {
                _dbContext.UpdateRange(clients);
            });
            

            return;
        }


        public async Task<List<Clients>> GetAll ()
        {
            return await _dbContext.Clients.AsNoTracking().ToListAsync();
        }
            

    }
}
