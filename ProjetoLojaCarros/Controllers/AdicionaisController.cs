using AutoMapper;
using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using LojaCarrosApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LojaCarrosApi.Controllers
{
    [ApiController]
    [Route("api/carros-adicionais")]
    public class AdicionaisController : ControllerBase
    {
        private readonly IAdicionaisService _AdicionaisService;
        private readonly IMapper _mapper;

        public AdicionaisController(IAdicionaisService adicionaisService, IMapper mapper)
        {
            _AdicionaisService = adicionaisService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAdicionais()
        {
            var Adicionais = await _AdicionaisService.GetAllAdicionais();
            var AdicionaisViewModels = _mapper.Map<IEnumerable<AdicionaisCompletoViewModel>>(Adicionais);
            return Ok(AdicionaisViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdicionaisById(int id)
        {
            var Adicionais = await _AdicionaisService.GetAdicionaisById(id);
            if (Adicionais == null)
                return NotFound();

            var AdicionaisViewModel = _mapper.Map<AdicionaisViewModel>(Adicionais);
            return Ok(AdicionaisViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddAdicionais([FromBody] AdicionaisViewModel adicionaisViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Adicionais = _mapper.Map<Adicionais>(adicionaisViewModel);
            Adicionais.Ativo = true;
            Adicionais.DataAlteracao = DateTime.Now;

            var createdAdicionais = await _AdicionaisService.AddAdicionais(Adicionais);
            var createdAdicionaisViewModel = _mapper.Map<AdicionaisViewModel>(createdAdicionais);

            return CreatedAtAction(nameof(GetAdicionaisById), new { id = createdAdicionais.IdAdicionais }, createdAdicionaisViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAdicionais(int id, [FromBody] AdicionaisViewModel adicionaisViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var Adicionais = await _AdicionaisService.GetAdicionaisById(id);
            if (Adicionais == null)
                return NotFound();

            Adicionais.Nome = adicionaisViewModel.Nome;
            Adicionais.Descricao = adicionaisViewModel.Descricao;
            Adicionais.Preco = adicionaisViewModel.Preco;           // Falta Setar a chave estrangeira Id do Carro, Rever depois
            Adicionais.DataAlteracao = DateTime.Now;

            var updatedAdicionais = await _AdicionaisService.UpdateAdicionais(Adicionais);
            var updatedAdicionaisViewModel = _mapper.Map<AdicionaisViewModel>(updatedAdicionais);

            return Ok(updatedAdicionaisViewModel);
        }

        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> DeactivateAdicionais(int id)
        {
            var result = await _AdicionaisService.DeactivateAdicionais(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpPut("activate/{id}")]
        public async Task<IActionResult> ActivateAdicionais(int id)
        {
            var result = await _AdicionaisService.ActivateAdicionais(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
