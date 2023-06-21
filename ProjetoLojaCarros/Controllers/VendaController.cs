using AutoMapper;
using DevIOApi.ViewModels;
using DevIoBusiness.Intefaces;
using DevIoBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIOApi.Controllers
{
    [ApiController]
    [Route("api/vendas")]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _vendaService;
        private readonly IMapper _mapper;

        public VendaController(IVendaService vendaService, IMapper mapper)
        {
            _vendaService = vendaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVendas()
        {
            var vendas = await _vendaService.GetAllVendas();
            var vendaViewModels = _mapper.Map<IEnumerable<VendaViewModel>>(vendas);
            return Ok(vendaViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendaById(int id)
        {
            var venda = await _vendaService.GetVendaById(id);
            if (venda == null)
                return NotFound();

            var vendaViewModel = _mapper.Map<VendaViewModel>(venda);
            return Ok(vendaViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddVenda([FromBody] VendaViewModel vendaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var venda = _mapper.Map<Venda>(vendaViewModel);


            await _vendaService.AddVenda(venda);

            var createdVendaViewModel = _mapper.Map<VendaViewModel>(venda);

            return CreatedAtAction(nameof(GetVendaById), new { id = createdVendaViewModel.IdVenda }, createdVendaViewModel);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVenda(int id, [FromBody] VendaViewModel vendaViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var venda = await _vendaService.GetVendaById(id);
            if (venda == null)
                return NotFound();

            _mapper.Map(vendaViewModel, venda);

            await _vendaService.UpdateVenda(venda);

            var updatedVendaViewModel = _mapper.Map<VendaViewModel>(venda);

            return Ok(updatedVendaViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVenda(int id)
        {
            var venda = await _vendaService.GetVendaById(id);
            if (venda == null)
                return NotFound();

            await _vendaService.DeleteVenda(id);

            return NoContent();
        }
    }

}
