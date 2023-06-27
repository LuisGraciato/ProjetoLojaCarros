using AutoMapper;
using DevIOApi.ViewModels;
using DevIoBusiness.Intefaces;
using DevIoBusiness.Models;
using LojaCarrosApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DevIOApi.Controllers
{
    [ApiController]
    [Route("api/notasfiscais")]
    public class NotaFiscalController : ControllerBase
    {
        private readonly INotaFiscalService _notaFiscalService;
        private readonly IMapper _mapper;

        public NotaFiscalController(INotaFiscalService notaFiscalService, IMapper mapper)
        {
            _notaFiscalService = notaFiscalService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotasFiscais()
        {
            var notasFiscais = await _notaFiscalService.GetAllNotasFiscais();
            var notaFiscalCompletaViewModel = _mapper.Map<IEnumerable<NotaFiscalCompletaViewModel>>(notasFiscais);
            return Ok(notaFiscalCompletaViewModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNotaFiscalById(int id)
        {
            var notaFiscal = await _notaFiscalService.GetNotaFiscalById(id);
            if (notaFiscal == null)
                return NotFound();

            var notaFiscalViewModel = _mapper.Map<NotaFiscalCompletaViewModel>(notaFiscal);
            return Ok(notaFiscalViewModel);
        }

        [HttpGet("venda/{idVenda}")]
        public async Task<IActionResult> GetNotasFiscaisByVendaId(int idVenda)
        {
            var notasFiscais = await _notaFiscalService.GetNotasFiscaisByVendaId(idVenda);
            var notaFiscalViewModels = _mapper.Map<IEnumerable<NotaFiscalViewModel>>(notasFiscais);
            return Ok(notaFiscalViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> AddNotaFiscal([FromBody] NotaFiscalViewModel notaFiscalViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var notaFiscal = _mapper.Map<NotaFiscal>(notaFiscalViewModel);
            await _notaFiscalService.AddNotaFiscal(notaFiscal);

            return CreatedAtAction(nameof(GetNotaFiscalById), new { id = notaFiscal.IdNotaFiscal }, notaFiscalViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNotaFiscal(int id, [FromBody] NotaFiscalViewModel notaFiscalViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingNotaFiscal = await _notaFiscalService.GetNotaFiscalById(id);
            if (existingNotaFiscal == null)
                return NotFound();

            var notaFiscal = _mapper.Map<NotaFiscal>(notaFiscalViewModel);
            notaFiscal.IdNotaFiscal = id;
            await _notaFiscalService.UpdateNotaFiscal(notaFiscal);

            return Ok(notaFiscalViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNotaFiscal(int id)
        {
            var existingNotaFiscal = await _notaFiscalService.GetNotaFiscalById(id);
            if (existingNotaFiscal == null)
                return NotFound();

            await _notaFiscalService.DeleteNotaFiscal(id);

            return NoContent();
        }
    }

}
