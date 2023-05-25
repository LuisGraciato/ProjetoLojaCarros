using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using DevIoData.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIoData.Repository
{
    public class CarroRepository : ICarroRepository
    {
        private readonly MyDbContext _dbContext;

        public CarroRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Carro>> GetAllCarros()
        {
            return await _dbContext.Carros.ToListAsync();
        }

        public async Task<Carro> GetCarroById(int id)
        {
            return await _dbContext.Carros.FindAsync(id);
        }

        public async Task<Carro> AddCarro(Carro carro)
        {
            _dbContext.Carros.Add(carro);
            await _dbContext.SaveChangesAsync();
            return carro;
        }

        public async Task<Carro> UpdateCarro(Carro carro)
        {
            _dbContext.Entry(carro).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return carro;
        }

        public async Task<bool> DeactivateCarro(int id)
        {
            var carro = await _dbContext.Carros.FindAsync(id);
            if (carro == null)
                return false;

            carro.Ativo = false;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActivateCarro(int id)
        {
            var carro = await _dbContext.Carros.FindAsync(id);
            if (carro == null)
                return false;

            carro.Ativo = true;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
