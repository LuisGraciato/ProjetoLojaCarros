using AutoMapper;
using DevIOApi.ViewModels;
using DevIOApi.ViewModels.ViewModelsCompletas;
using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaCarrosApi.Controllers
{
    [ApiController]
    [Route("api/funcionarios")]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioService _funcionarioService;
        private readonly IMapper _mapper;

        public FuncionarioController(IFuncionarioService funcionarioService, IMapper mapper)
        {
            _funcionarioService = funcionarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFuncionarios()
        {
            var funcionarios = await _funcionarioService.GetAllFuncionarios();
            var funcionarioViewModels = _mapper.Map<IEnumerable<FuncionarioCompletoViewModel>>(funcionarios);
            return Ok(funcionarioViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFuncionarioById(int id)
        {
            var funcionario = await _funcionarioService.GetFuncionarioById(id);
            if (funcionario == null)
                return NotFound();

            var funcionarioViewModel = _mapper.Map<FuncionarioCompletoViewModel>(funcionario);
            return Ok(funcionarioViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddFuncionario([FromBody] FuncionarioViewModel funcionarioViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var funcionario = _mapper.Map<Funcionario>(funcionarioViewModel);
            funcionario.Ativo = true;
            funcionario.DataAlteracao = DateTime.Now;

            var createdFuncionario = await _funcionarioService.AddFuncionario(funcionario);
            var createdFuncionarioViewModel = _mapper.Map<FuncionarioViewModel>(createdFuncionario);

            return CreatedAtAction(nameof(GetFuncionarioById), new { id = createdFuncionario.Id }, createdFuncionarioViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFuncionario(int id, [FromBody] FuncionarioViewModel funcionarioViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var funcionario = await _funcionarioService.GetFuncionarioById(id);
            if (funcionario == null)
                return NotFound();

            funcionario.Nome = funcionarioViewModel.Nome;
            funcionario.Email = funcionarioViewModel.Email;
            funcionario.Cargo = funcionarioViewModel.Cargo;
            funcionario.IdEndereco = funcionarioViewModel.IdEndereco;
            funcionario.IdTelefone = funcionarioViewModel.IdTelefone;
            funcionario.DataAlteracao = DateTime.Now;

            var updatedFuncionario = await _funcionarioService.UpdateFuncionario(funcionario);
            var updatedFuncionarioViewModel = _mapper.Map<FuncionarioViewModel>(updatedFuncionario);

            return Ok(updatedFuncionarioViewModel);
        }

        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> DeactivateFuncionario(int id)
        {
            var result = await _funcionarioService.DeactivateFuncionario(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpPut("activate/{id}")]
        public async Task<IActionResult> ActivateFuncionario(int id)
        {
            var result = await _funcionarioService.ActivateFuncionario(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
