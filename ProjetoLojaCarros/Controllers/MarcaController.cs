﻿using AutoMapper;
using DevIoBusiness.Intefaces;
using DevIoBusiness.Models;
using LojaCarrosApi.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LojaCarrosApi.Controllers
{
    [ApiController]
    [Route("api/marcas")]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _marcaService;
        private readonly IMapper _mapper;

        public MarcaController(IMarcaService marcaService, IMapper mapper)
        {
            _marcaService = marcaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMarcas()
        {
            var marcas = await _marcaService.GetAllMarcas();
            var marcaViewModels = _mapper.Map<IEnumerable<MarcaViewModel>>(marcas);
            return Ok(marcaViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMarcaById(int id)
        {
            var marca = await _marcaService.GetMarcaById(id);
            if (marca == null)
                return NotFound();

            var marcaViewModel = _mapper.Map<MarcaViewModel>(marca);
            return Ok(marcaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddMarca([FromBody] MarcaViewModel marcaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var marca = _mapper.Map<Marca>(marcaViewModel);
            marca.Ativo = true;
            marca.DataAlteracao = DateTime.Now;

            var createdMarca = await _marcaService.AddMarca(marca);
            var createdMarcaViewModel = _mapper.Map<MarcaViewModel>(createdMarca);

            return CreatedAtAction(nameof(GetMarcaById), new { id = createdMarcaViewModel.IdMarca }, createdMarcaViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMarca(int id, [FromBody] MarcaViewModel marcaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var marca = await _marcaService.GetMarcaById(id);
            if (marca == null)
                return NotFound();

            marca.Nome = marcaViewModel.Nome;
            marca.Ativo = marcaViewModel.Ativo;
            marca.DataAlteracao = DateTime.Now;

            var updatedMarca = await _marcaService.UpdateMarca(marca);
            var updatedMarcaViewModel = _mapper.Map<MarcaViewModel>(updatedMarca);

            return Ok(updatedMarcaViewModel);
        }

    }
}
