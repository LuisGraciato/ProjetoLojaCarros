using AutoMapper;
using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using LojaCarrosApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LojaCarrosApi.Controllers
{
    [ApiController]
    [Route("api/carros")]
    public class CarroController : ControllerBase
    {
        private readonly ICarroService _carroService;
        private readonly IMapper _mapper;

        public CarroController(ICarroService carroService, IMapper mapper)
        {
            _carroService = carroService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarros()
        {
            var carros = await _carroService.GetAllCarros();
            var carroViewModels = _mapper.Map<IEnumerable<CarroCompletoViewModel>>(carros);
            return Ok(carroViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarroById(int id)
        {
            var carro = await _carroService.GetCarroById(id);
            if (carro == null)
                return NotFound();

            var carroViewModel = _mapper.Map<CarroCompletoViewModel>(carro);
            return Ok(carroViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddCarro([FromBody] CarroViewModel carroViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var carro = _mapper.Map<Carro>(carroViewModel);
            carro.Ativo = true;
            carro.DataAlteracao = DateTime.Now;

            var createdCarro = await _carroService.AddCarro(carro);
            var createdCarroViewModel = _mapper.Map<CarroViewModel>(createdCarro);

            return CreatedAtAction(nameof(GetCarroById), new { id = createdCarro.IdCarro }, createdCarroViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarro(int id, [FromBody] CarroViewModel carroViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var carro = await _carroService.GetCarroById(id);
            if (carro == null)
                return NotFound();


            carro.Placa = carroViewModel.Placa;
            carro.Quilometragem = carroViewModel.Quilometragem;
            carro.Cor = carroViewModel.Cor;
            carro.Preco = carroViewModel.Preco;
            carro.EstadoConservacao = carroViewModel.EstadoConservacao;
            carro.IdModelo = carroViewModel.IdModelo;
            carro.DataAlteracao = DateTime.Now;
            
            var updatedCarro = await _carroService.UpdateCarro(carro);
            var updatedCarroViewModel = _mapper.Map<CarroViewModel>(updatedCarro);

            return Ok(updatedCarroViewModel);
        }

        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> DeactivateCarro(int id)
        {
            var result = await _carroService.DeactivateCarro(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpPut("activate/{id}")]
        public async Task<IActionResult> ActivateCarro(int id)
        {
            var result = await _carroService.ActivateCarro(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
