using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using DevIoData.Context;
using Microsoft.EntityFrameworkCore;

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
            var carros = await _dbContext.Carros
                .Include(v => v.CarroAdicionais)
                .ToListAsync();

            foreach (var carro in carros)
            {
                carro.CarroAdicionais = carro.CarroAdicionais.Select(cv => new CarroAdicionais
                {
                    IdAdicionais = cv.IdAdicionais,
                    Valor = cv.Valor
                }).ToList();    
            }

            return carros;
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
        public async Task AtualizarEstadoCarroAposVenda(int idCarro)
        {
            var carro = await GetCarroById(idCarro);

            if (carro == null || !carro.Ativo)
            {
                throw new Exception("Carro já vendido ou fora de estoque para venda.");
            }
            else
            {
                carro.Ativo = false;
            }
            await _dbContext.SaveChangesAsync();
        }

    }
}
