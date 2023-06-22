using DevIoBusiness.Models;

namespace DevIoBusiness.Intefaces
{
    public interface INotaFiscalService
    {
        Task<IEnumerable<NotaFiscal>> GetAllNotasFiscais();
        Task<NotaFiscal> GetNotaFiscalById(int Id);
        Task<IEnumerable<NotaFiscal>> GetNotasFiscaisByVendaId(int idVenda);
        Task AddNotaFiscal(NotaFiscal notaFiscal);
        Task UpdateNotaFiscal(NotaFiscal notaFiscal);
        Task DeleteNotaFiscal(int Id);
        Task GerarNotaFiscalAposVenda(NotaFiscal notaFiscal);
    }

}
