using DevIoBusiness.Intefaces;
using DevIoBusiness.Models;
using DevIoData.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIoData.Repository
{
    public class ModeloRepository : IModeloRepository
    {
        private readonly MyDbContext _dbContext;

        public ModeloRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Modelo>> GetAllModelos()
        {
            return await _dbContext.Modelos.ToListAsync();

        }
        public async Task<Modelo> GetModeloById(int id)
        {
            return await _dbContext.Modelos.FindAsync(id);
        }

        public async Task<Modelo> AddModelo(Modelo modelo)
        {
            _dbContext.Modelos.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<Modelo> UpdateModelo(Modelo modelo)
        {
            _dbContext.Entry(modelo).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return modelo;
        }

        public async Task<bool> DeactivateModelo(int id)
        {
            var modelo = await _dbContext.Modelos.FindAsync(id);
            if (modelo == null)
                return false;

            modelo.Ativo = false;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActivateModelo(int id)
        {
            var modelo = await _dbContext.Modelos.FindAsync(id);
            if (modelo == null)
                return false;

            modelo.Ativo = true;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
