using DevIoBusiness.Intefaces;
using DevIoBusiness.Models;
using DevIoData.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIoData.Repository
{
    public class NotaFiscalRepository : INotaFiscalRepository
    {
        private readonly MyDbContext _dbContext;

        public NotaFiscalRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<NotaFiscal>> GetAllNotasFiscais()
        {
            return await _dbContext.NotasFiscais.ToListAsync();
        }

        public async Task<NotaFiscal> GetNotaFiscalById(int Id)
        {
            return await _dbContext.NotasFiscais.FindAsync(Id);
        }

        public async Task<IEnumerable<NotaFiscal>> GetNotasFiscaisByVendaId(int idVenda)
        {
            return await _dbContext.NotasFiscais
                .Where(nf => nf.IdVenda == idVenda)
                .ToListAsync();
        }

        public async Task AddNotaFiscal(NotaFiscal notaFiscal)
        {
            _dbContext.NotasFiscais.Add(notaFiscal);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateNotaFiscal(NotaFiscal notaFiscal)
        {
            _dbContext.Entry(notaFiscal).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteNotaFiscal(int Id)
        {
            var notaFiscal = await _dbContext.NotasFiscais.FindAsync(Id);
            if (notaFiscal != null)
            {
                _dbContext.NotasFiscais.Remove(notaFiscal);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task GerarNotaFiscalAposVenda(NotaFiscal notaFiscal)
        {
            notaFiscal.NumeroNota = await GerarNumeroNotaFiscal();
            notaFiscal.DataEmissao = DateTime.Now;

            _dbContext.NotasFiscais.Add(notaFiscal);
            await _dbContext.SaveChangesAsync();
        }
        private async Task<int> GerarNumeroNotaFiscal()
        {
            Random random = new Random();
            int numeroNota = random.Next(10000, 99999);
            return numeroNota;
        }
    }

}
