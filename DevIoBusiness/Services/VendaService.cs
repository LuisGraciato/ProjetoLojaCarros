using DevIoBusiness.Intefaces;
using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;

namespace DevIoBusiness.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly INotaFiscalService _notaFiscalService;
        private readonly ICarroService _carroService;

        public VendaService(IVendaRepository vendaRepository, INotaFiscalService notaFiscalService, ICarroService carroService)
        {
            _vendaRepository = vendaRepository;
            _notaFiscalService = notaFiscalService;
            _carroService = carroService;

        }

        public async Task<IEnumerable<Venda>> GetAllVendas()
        {
            return await _vendaRepository.GetAllVendas();
        }

        public async Task<Venda> GetVendaById(int id)
        {
            return await _vendaRepository.GetVendaById(id);
        }

        public async Task AddVenda(Venda venda)
        {
            foreach (var carroVenda in venda.CarrosVendidos)
            {
                await _carroService.AtualizarEstadoCarroAposVenda(carroVenda.IdCarro);
            }

            await _vendaRepository.AddVenda(venda);

            var notaFiscal = new NotaFiscal
            {
                IdVenda = venda.IdVenda
            };

            await _notaFiscalService.GerarNotaFiscalAposVenda(notaFiscal);
   
        }

        public async Task UpdateVenda(Venda venda)
        {
            await _vendaRepository.UpdateVenda(venda);
        }

        public async Task DeleteVenda(int id)
        {
            await _vendaRepository.DeleteVenda(id);
        }
    }
}

