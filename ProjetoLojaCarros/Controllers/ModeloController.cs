using AutoMapper;
using DevIoBusiness.Intefaces;
using DevIoBusiness.Models;
using LojaCarrosApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LojaCarrosApi.Controllers
{
    [ApiController]
    [Route("api/modelos")]
    public class ModeloController : ControllerBase
    {
        private readonly IModeloService _modeloService;
        private readonly IMapper _mapper;

        public ModeloController(IModeloService modeloService, IMapper mapper)
        {
            _modeloService = modeloService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllModelos()
        {
            var modelos = await _modeloService.GetAllModelos();
            var modeloCompletoViewModels = _mapper.Map<IEnumerable<ModeloCompletoViewModel>>(modelos);
            return Ok(modeloCompletoViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetModeloById(int id)
        {
            var modelo = await _modeloService.GetModeloById(id);
            if (modelo == null)
                return NotFound();

            var modeloViewModel = _mapper.Map<ModeloCompletoViewModel>(modelo);
            return Ok(modeloViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddModelo([FromBody] ModeloViewModel modeloViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var modelo = _mapper.Map<Modelo>(modeloViewModel);
            modelo.Ativo = true;
            modelo.DataAlteracao = DateTime.Now;

            var createdModelo = await _modeloService.AddModelo(modelo);
            var createdModeloViewModel = _mapper.Map<ModeloViewModel>(modelo);

            return CreatedAtAction(nameof(GetModeloById), new { id = createdModelo.IdModelo }, createdModeloViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateModelo(int id, [FromBody] ModeloViewModel modeloViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var modelo = await _modeloService.GetModeloById(id);
            if (modelo == null)
                return NotFound();

            modelo.Nome = modeloViewModel.Nome;
            modelo.TipoCombustivel = modeloViewModel.TipoCombustivel;
            modelo.TipoMotor = modeloViewModel.TipoMotor;
            modelo.NumeroPortas = modeloViewModel.NumeroPortas;
            modelo.NumeroLugares = modeloViewModel.NumeroLugares;
            modelo.AnoFabricacao = modeloViewModel.AnoFabricacao;
            modelo.AnoModelo = modeloViewModel.AnoModelo;
            modelo.IdMarca = modeloViewModel.IdMarca;
            modelo.DataAlteracao = DateTime.Now;

            var updatedModelo = await _modeloService.UpdateModelo(modelo);
            var updatedModeloViewModel = _mapper.Map<ModeloViewModel>(updatedModelo);

            return Ok(updatedModeloViewModel);
        }

        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> DeactivateModelo(int id)
        {
            var result = await _modeloService.DeactivateModelo(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpPut("activate/{id}")]
        public async Task<IActionResult> ActivateModelo(int id)
        {
            var result = await _modeloService.ActivateModelo(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}

