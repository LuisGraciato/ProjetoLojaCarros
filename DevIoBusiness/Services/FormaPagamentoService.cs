using DevIoBusiness.Intefaces;
using DevIoBusiness.Models;

namespace DevIoBusiness.Services
{
    public class FormaPagamentoService : IFormaPagamentoService
    {
        private readonly IFormaPagamentoRepository _formaPagamentoRepository;

        public FormaPagamentoService(IFormaPagamentoRepository formaPagamentoRepository)
        {
            _formaPagamentoRepository = formaPagamentoRepository;
        }

        public async Task<IEnumerable<FormaPagamento>> GetAllFormasPagamento()
        {
            return await _formaPagamentoRepository.GetAllFormasPagamento();
        }

        public async Task<FormaPagamento> GetFormaPagamentoById(int id)
        {
            return await _formaPagamentoRepository.GetFormaPagamentoById(id);
        }

        public async Task AddFormaPagamento(FormaPagamento formaPagamento)
        {
            await _formaPagamentoRepository.AddFormaPagamento(formaPagamento);
        }

        public async Task UpdateFormaPagamento(FormaPagamento formaPagamento)
        {
            await _formaPagamentoRepository.UpdateFormaPagamento(formaPagamento);
        }

        public async Task DeleteFormaPagamento(int id)
        {
            await _formaPagamentoRepository.DeleteFormaPagamento(id);
        }
    }

}
