using AutoMapper;
using DevIOApi.ViewModels;
using DevIoBusiness.Intefaces;
using DevIoBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIOApi.Controllers
{
    [ApiController]
    [Route("api/formaspagamento")]
    public class FormaPagamentoController : ControllerBase
    {
        private readonly IFormaPagamentoService _formaPagamentoService;
        private readonly IMapper _mapper;

        public FormaPagamentoController(IFormaPagamentoService formaPagamentoService, IMapper mapper)
        {
            _formaPagamentoService = formaPagamentoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFormasPagamento()
        {
            var formasPagamento = await _formaPagamentoService.GetAllFormasPagamento();
            var formaPagamentoViewModels = _mapper.Map<IEnumerable<FormaPagamentoViewModel>>(formasPagamento);
            return Ok(formaPagamentoViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFormaPagamentoById(int id)
        {
            var formaPagamento = await _formaPagamentoService.GetFormaPagamentoById(id);
            if (formaPagamento == null)
                return NotFound();

            var formaPagamentoViewModel = _mapper.Map<FormaPagamentoViewModel>(formaPagamento);
            return Ok(formaPagamentoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddFormaPagamento([FromBody] FormaPagamentoViewModel formaPagamentoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var formaPagamento = _mapper.Map<FormaPagamento>(formaPagamentoViewModel);

            await _formaPagamentoService.AddFormaPagamento(formaPagamento);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFormaPagamento(int id, [FromBody] FormaPagamentoViewModel formaPagamentoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var formaPagamento = await _formaPagamentoService.GetFormaPagamentoById(id);
            if (formaPagamento == null)
                return NotFound();

            formaPagamento.Descricao = formaPagamentoViewModel.Descricao;
            formaPagamento.Nome = formaPagamentoViewModel.Nome;

            await _formaPagamentoService.UpdateFormaPagamento(formaPagamento);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormaPagamento(int id)
        {
            var formaPagamento = await _formaPagamentoService.GetFormaPagamentoById(id);
            if (formaPagamento == null)
                return NotFound();

            await _formaPagamentoService.DeleteFormaPagamento(id);
            return Ok();
        }
    }

}
