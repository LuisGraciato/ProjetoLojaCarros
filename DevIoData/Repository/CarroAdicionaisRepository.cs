using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using DevIoData.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIoData.Repository
{
    public class CarroAdicionaisRepository : ICarroAdicionaisRepository
    {
        private readonly MyDbContext _dbContext;

        public CarroAdicionaisRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<CarroAdicionais>> GetAllCarrosAdicionais()
        {
            return await _dbContext.CarroAdicionais.ToListAsync();
        }

        public async Task<CarroAdicionais> GetCarroAdicionaisById(int id)
        {
            return await _dbContext.CarroAdicionais.FindAsync(id);
        }

        public async Task<CarroAdicionais> AddCarroAdicionais(CarroAdicionais carroAdicionais)
        {
            _dbContext.CarroAdicionais.Add(carroAdicionais);
            await _dbContext.SaveChangesAsync();
            return carroAdicionais;
        }

        public async Task<CarroAdicionais> UpdateCarroAdicionais(CarroAdicionais carroAdicionais)
        {
            _dbContext.Entry(carroAdicionais).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return carroAdicionais;
        }

        public async Task<bool> DeactivateCarroAdicionais(int id)
        {
            var carroAdicionais = await _dbContext.CarroAdicionais.FindAsync(id);
            if (carroAdicionais == null)
                return false;

            carroAdicionais.Ativo = false;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActivateCarroAdicionais(int id)
        {
            var carroAdicionais = await _dbContext.CarroAdicionais.FindAsync(id);
            if (carroAdicionais == null)
                return false;

            carroAdicionais.Ativo = true;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
