using DevIoBusiness.Models;

namespace DevIoBusiness.Intefaces
{
    public interface IFormaPagamentoRepository
    {
        Task<IEnumerable<FormaPagamento>> GetAllFormasPagamento();
        Task<FormaPagamento> GetFormaPagamentoById(int id);
        Task AddFormaPagamento(FormaPagamento formaPagamento);
        Task UpdateFormaPagamento(FormaPagamento formaPagamento);
        Task DeleteFormaPagamento(int id);
    }

}
