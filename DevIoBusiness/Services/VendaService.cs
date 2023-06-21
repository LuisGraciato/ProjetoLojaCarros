using DevIoBusiness.Intefaces;
using DevIoBusiness.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIoBusiness.Services
{
    public class VendaService : IVendaService
    {
        private readonly IVendaRepository _vendaRepository;
        private readonly INotaFiscalService _notaFiscalService;

        public VendaService(IVendaRepository vendaRepository, INotaFiscalService notaFiscalService)
        {
            _vendaRepository = vendaRepository;
            _notaFiscalService = notaFiscalService;
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
            await _vendaRepository.AddVenda(venda);

            //Random random = new Random();
            //int numeroNota = random.Next(10000, 99999);
            //var notaFiscal = new NotaFiscal
            //{
            //    NumeroNota = numeroNota,
            //    DataEmissao = DateTime.Now,
            //    IdVenda = venda.IdVenda
            //};

            //await _notaFiscalService.AddNotaFiscal(notaFiscal);
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

