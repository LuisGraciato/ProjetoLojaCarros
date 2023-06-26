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
            var AdicionaisViewModels = _mapper.Map<IEnumerable<AdicionaisViewModel>>(Adicionais);
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

            var adicionais = _mapper.Map<Adicionais>(adicionaisViewModel);
            await _AdicionaisService.AddAdicionais(adicionais);
            return Ok();
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
            Adicionais.Preco = adicionaisViewModel.Preco;

            await _AdicionaisService.UpdateAdicionais(Adicionais);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdicionais(int id)
        {
            var adicionais = await _AdicionaisService.GetAdicionaisById(id);
            if (adicionais == null)
                return NotFound();

            await _AdicionaisService.DeleteAdicionais(id);
            return Ok();
        }
    }
}
