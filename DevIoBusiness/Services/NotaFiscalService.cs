using DevIoBusiness.Intefaces;
using DevIoBusiness.Models;

namespace DevIoBusiness.Services
{
    public class NotaFiscalService : INotaFiscalService
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;

        public NotaFiscalService(INotaFiscalRepository notaFiscalRepository)
        {
            _notaFiscalRepository = notaFiscalRepository;
        }

        public async Task<IEnumerable<NotaFiscal>> GetAllNotasFiscais()
        {
            return await _notaFiscalRepository.GetAllNotasFiscais();
        }

        public async Task<NotaFiscal> GetNotaFiscalById(int id)
        {
            return await _notaFiscalRepository.GetNotaFiscalById(id);
        }

        public async Task<IEnumerable<NotaFiscal>> GetNotasFiscaisByVendaId(int idVenda)
        {
            return await _notaFiscalRepository.GetNotasFiscaisByVendaId(idVenda);
        }

        public async Task AddNotaFiscal(NotaFiscal notaFiscal)
        {
            await _notaFiscalRepository.AddNotaFiscal(notaFiscal);
        }

        public async Task UpdateNotaFiscal(NotaFiscal notaFiscal)
        {
            await _notaFiscalRepository.UpdateNotaFiscal(notaFiscal);
        }

        public async Task DeleteNotaFiscal(int id)
        {
            await _notaFiscalRepository.DeleteNotaFiscal(id);
        }

        public async Task GerarNotaFiscalAposVenda(NotaFiscal notaFiscal)
        {
            await _notaFiscalRepository.GerarNotaFiscalAposVenda(notaFiscal);
        }
    }

}
