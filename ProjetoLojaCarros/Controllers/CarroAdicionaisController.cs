using AutoMapper;
using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using LojaCarrosApi.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LojaCarrosApi.Controllers
{
    [ApiController]
    [Route("api/carros-adicionais")]
    public class CarroAdicionaisController : ControllerBase
    {
        private readonly ICarroAdicionaisService _carroAdicionaisService;
        private readonly IMapper _mapper;

        public CarroAdicionaisController(ICarroAdicionaisService carroAdicionaisService, IMapper mapper)
        {
            _carroAdicionaisService = carroAdicionaisService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCarrosAdicionais()
        {
            var carrosAdicionais = await _carroAdicionaisService.GetAllCarrosAdicionais();
            var carroAdicionaisViewModels = _mapper.Map<IEnumerable<CarroAdicionaisCompletoViewModel>>(carrosAdicionais);
            return Ok(carroAdicionaisViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCarroAdicionaisById(int id)
        {
            var carroAdicionais = await _carroAdicionaisService.GetCarroAdicionaisById(id);
            if (carroAdicionais == null)
                return NotFound();

            var carroAdicionaisViewModel = _mapper.Map<CarroAdicionaisViewModel>(carroAdicionais);
            return Ok(carroAdicionaisViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddCarroAdicionais([FromBody] CarroAdicionaisViewModel carroAdicionaisViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var carroAdicionais = _mapper.Map<CarroAdicionais>(carroAdicionaisViewModel);
            carroAdicionais.Ativo = true;
            carroAdicionais.DataAlteracao = DateTime.Now;

            var createdCarroAdicionais = await _carroAdicionaisService.AddCarroAdicionais(carroAdicionais);
            var createdCarroAdicionaisViewModel = _mapper.Map<CarroAdicionaisViewModel>(createdCarroAdicionais);

            return CreatedAtAction(nameof(GetCarroAdicionaisById), new { id = createdCarroAdicionais.IdAdicionais }, createdCarroAdicionaisViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarroAdicionais(int id, [FromBody] CarroAdicionaisViewModel carroAdicionaisViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var carroAdicionais = await _carroAdicionaisService.GetCarroAdicionaisById(id);
            if (carroAdicionais == null)
                return NotFound();

            carroAdicionais.Nome = carroAdicionaisViewModel.Nome;
            carroAdicionais.Descricao = carroAdicionaisViewModel.Descricao;
            carroAdicionais.Preco = carroAdicionaisViewModel.Preco;           // Falta Setar a chave estrangeira Id do Carro, Rever depois
            carroAdicionais.DataAlteracao = DateTime.Now;

            var updatedCarroAdicionais = await _carroAdicionaisService.UpdateCarroAdicionais(carroAdicionais);
            var updatedCarroAdicionaisViewModel = _mapper.Map<CarroAdicionaisViewModel>(updatedCarroAdicionais);

            return Ok(updatedCarroAdicionaisViewModel);
        }

        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> DeactivateCarroAdicionais(int id)
        {
            var result = await _carroAdicionaisService.DeactivateCarroAdicionais(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpPut("activate/{id}")]
        public async Task<IActionResult> ActivateCarroAdicionais(int id)
        {
            var result = await _carroAdicionaisService.ActivateCarroAdicionais(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
