using DevIoBusiness.Intefaces;
using DevIoBusiness.Models;
using DevIoData.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIoData.Repository
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly MyDbContext _dbContext;

        public MarcaRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Marca>> GetAllMarcas()
        {
            return await _dbContext.Marcas.ToListAsync();
        }

        public async Task<Marca> GetMarcaById(int id)
        {
            return await _dbContext.Marcas.FindAsync(id);

        }

        public async Task<Marca> AddMarca(Marca marca)
        {
            _dbContext.Marcas.Add(marca);
            await _dbContext.SaveChangesAsync();
            return marca;
        }

        public async Task<Marca> UpdateMarca(Marca marca)
        {
            _dbContext.Entry(marca).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return marca;
        }

        public async Task<bool> DeactivateMarca(int id)
        {
            var marca = await _dbContext.Marcas.FindAsync(id);
            if (marca == null)
                return false;

            marca.Ativo = false;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActivateMarca(int id)
        {
            var marca = await _dbContext.Marcas.FindAsync(id);
            if (marca == null)
                return false;

            marca.Ativo = true;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }

}
