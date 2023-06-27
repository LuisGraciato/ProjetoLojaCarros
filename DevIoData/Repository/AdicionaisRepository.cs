using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using DevIoData.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIoData.Repository
{
    public class AdicionaisRepository : IAdicionaisRepository
    {
        private readonly MyDbContext _dbContext;

        public AdicionaisRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Adicionais>> GetAllAdicionais()
        {
            return await _dbContext.Adicionais.ToListAsync();
        }

        public async Task<Adicionais> GetAdicionaisById(int id)
        {
            return await _dbContext.Adicionais.FindAsync(id);
        }

        public async Task<Adicionais> AddAdicionais(Adicionais adicionais)
        {
            _dbContext.Adicionais.Add(adicionais);
            await _dbContext.SaveChangesAsync();
            return adicionais;
        }

        public async Task<Adicionais> UpdateAdicionais(Adicionais adicionais)
        {
            _dbContext.Entry(adicionais).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return adicionais;
        }

        public async Task DeleteAdicionais(int id)
        {
            var adicionais = await _dbContext.Adicionais.FindAsync(id);
            if (adicionais != null)
            {
                _dbContext.Adicionais.Remove(adicionais);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
