using DevIoBusiness.Intefaces;
using DevIoBusiness.Models;
using DevIoData.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIoData.Repository
{
    public class FormaPagamentoRepository : IFormaPagamentoRepository
    {
        private readonly MyDbContext _dbContext;

        public FormaPagamentoRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<FormaPagamento>> GetAllFormasPagamento()
        {
            return await _dbContext.FormasPagamento.ToListAsync();
        }

        public async Task<FormaPagamento> GetFormaPagamentoById(int id)
        {
            return await _dbContext.FormasPagamento.FindAsync(id);
        }

        public async Task AddFormaPagamento(FormaPagamento formaPagamento)
        {
            _dbContext.FormasPagamento.Add(formaPagamento);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateFormaPagamento(FormaPagamento formaPagamento)
        {
            _dbContext.Entry(formaPagamento).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteFormaPagamento(int id)
        {
            var formaPagamento = await _dbContext.FormasPagamento.FindAsync(id);
            if (formaPagamento != null)
            {
                _dbContext.FormasPagamento.Remove(formaPagamento);
                await _dbContext.SaveChangesAsync();
            }
        }
    }

}
