using AutoMapper;
using DevIOApi.ViewModels;
using DevIOApi.ViewModels.ViewModelsCompletas;
using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using Microsoft.AspNetCore.Mvc;

namespace LojaCarrosApi.Controllers
{
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper)
        {
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientes()
        {
            var clientes = await _clienteService.GetAllClientes();
            var clienteViewModels = _mapper.Map<IEnumerable<ClienteCompletoViewModel>>(clientes);
            return Ok(clienteViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClienteById(int id)
        {
            var cliente = await _clienteService.GetClienteById(id);
            if (cliente == null)
                return NotFound();

            var clienteViewModel = _mapper.Map<ClienteCompletoViewModel>(cliente);
            return Ok(clienteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddCliente([FromBody] ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cliente = _mapper.Map<Cliente>(clienteViewModel);
            cliente.Ativo = true;
            cliente.DataAlteracao = DateTime.Now;

            var createdCliente = await _clienteService.AddCliente(cliente);
            var createdClienteViewModel = _mapper.Map<ClienteViewModel>(createdCliente);

            return CreatedAtAction(nameof(GetClienteById), new { id = createdCliente.Id }, createdClienteViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCliente(int id, [FromBody] ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cliente = await _clienteService.GetClienteById(id);
            if (cliente == null)
                return NotFound();

            cliente.Nome = clienteViewModel.Nome;
            cliente.Email = clienteViewModel.Email;
            cliente.IdEndereco = clienteViewModel.IdEndereco;
            cliente.IdTelefone = clienteViewModel.IdTelefone;
            cliente.DataAlteracao = DateTime.Now;

            var updatedCliente = await _clienteService.UpdateCliente(cliente);
            var updatedClienteViewModel = _mapper.Map<ClienteViewModel>(updatedCliente);

            return Ok(updatedClienteViewModel);
        }

        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> DeactivateCliente(int id)
        {
            var result = await _clienteService.DeactivateCliente(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpPut("activate/{id}")]
        public async Task<IActionResult> ActivateCliente(int id)
        {
            var result = await _clienteService.ActivateCliente(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
