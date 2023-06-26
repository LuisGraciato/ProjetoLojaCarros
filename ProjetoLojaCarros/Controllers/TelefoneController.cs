using AutoMapper;
using DevIOApi.ViewModels;
using DevIOApi.ViewModels.ViewModelsCompletas;
using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaCarrosApi.Controllers
{
    [ApiController]
    [Route("api/telefones")]
    public class TelefoneController : ControllerBase
    {
        private readonly ITelefoneService _telefoneService;
        private readonly IMapper _mapper;

        public TelefoneController(ITelefoneService telefoneService, IMapper mapper)
        {
            _telefoneService = telefoneService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTelefones()
        {
            var telefones = await _telefoneService.GetAllTelefones();
            var telefoneViewModels = _mapper.Map<IEnumerable<TelefoneCompletoViewModel>>(telefones);
            return Ok(telefoneViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTelefoneById(int id)
        {
            var telefone = await _telefoneService.GetTelefoneById(id);
            if (telefone == null)
                return NotFound();

            var telefoneViewModel = _mapper.Map<TelefoneCompletoViewModel>(telefone);
            return Ok(telefoneViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddTelefone([FromBody] TelefoneViewModel telefoneViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var telefone = _mapper.Map<Telefone>(telefoneViewModel);
            telefone.Ativo = true;
            telefone.DataAlteracao = DateTime.Now;

            var createdTelefone = await _telefoneService.AddTelefone(telefone);
            var createdTelefoneViewModel = _mapper.Map<TelefoneViewModel>(createdTelefone);

            return CreatedAtAction(nameof(GetTelefoneById), new { id = createdTelefone.IdTelefone }, createdTelefoneViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTelefone(int id, [FromBody] TelefoneViewModel telefoneViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var telefone = await _telefoneService.GetTelefoneById(id);
            if (telefone == null)
                return NotFound();

            telefone.Numero = telefoneViewModel.Numero;
            telefone.DDD = telefoneViewModel.DDD;
            telefone.DDI = telefoneViewModel.DDI;
            telefone.DataAlteracao = DateTime.Now;

            var updatedTelefone = await _telefoneService.UpdateTelefone(telefone);
            var updatedTelefoneViewModel = _mapper.Map<TelefoneViewModel>(updatedTelefone);

            return Ok(updatedTelefoneViewModel);
        }

        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> DeactivateTelefone(int id)
        {
            var result = await _telefoneService.DeactivateTelefone(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpPut("activate/{id}")]
        public async Task<IActionResult> ActivateTelefone(int id)
        {
            var result = await _telefoneService.ActivateTelefone(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
