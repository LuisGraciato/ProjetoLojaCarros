using AutoMapper;
using DevIOApi.ViewModels;
using DevIOApi.ViewModels.ViewModelsCompletas;
using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaCarrosApi.Controllers
{
    [ApiController]
    [Route("api/enderecos")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;
        private readonly IMapper _mapper;

        public EnderecoController(IEnderecoService enderecoService, IMapper mapper)
        {
            _enderecoService = enderecoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEnderecos()
        {
            var enderecos = await _enderecoService.GetAllEnderecos();
            var enderecoViewModels = _mapper.Map<IEnumerable<EnderecoCompletoViewModel>>(enderecos);
            return Ok(enderecoViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEnderecoById(int id)
        {
            var endereco = await _enderecoService.GetEnderecoById(id);
            if (endereco == null)
                return NotFound();

            var enderecoViewModel = _mapper.Map<EnderecoCompletoViewModel>(endereco);
            return Ok(enderecoViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddEndereco([FromBody] EnderecoViewModel enderecoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var endereco = _mapper.Map<Endereco>(enderecoViewModel);
            endereco.Ativo = true;
            endereco.DataAlteracao = DateTime.Now;

            var createdEndereco = await _enderecoService.AddEndereco(endereco);
            var createdEnderecoViewModel = _mapper.Map<EnderecoViewModel>(createdEndereco);

            return CreatedAtAction(nameof(GetEnderecoById), new { id = createdEndereco.IdEndereco }, createdEnderecoViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEndereco(int id, [FromBody] EnderecoViewModel enderecoViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var endereco = await _enderecoService.GetEnderecoById(id);
            if (endereco == null)
                return NotFound();

            endereco.Rua = enderecoViewModel.Rua;
            endereco.Bairro = enderecoViewModel.Bairro;
            endereco.Cep = enderecoViewModel.Cep;
            endereco.Numero = enderecoViewModel.Numero;
            endereco.Estado = enderecoViewModel.Estado;
            endereco.Complemento = enderecoViewModel.Complemento;
            endereco.DataAlteracao = DateTime.Now;

            var updatedEndereco = await _enderecoService.UpdateEndereco(endereco);
            var updatedEnderecoViewModel = _mapper.Map<EnderecoViewModel>(updatedEndereco);

            return Ok(updatedEnderecoViewModel);
        }

        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> DeactivateEndereco(int id)
        {
            var result = await _enderecoService.DeactivateEndereco(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpPut("activate/{id}")]
        public async Task<IActionResult> ActivateEndereco(int id)
        {
            var result = await _enderecoService.ActivateEndereco(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
