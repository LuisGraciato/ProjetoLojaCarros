using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;

namespace DevIoBusiness.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> GetAllClientes()
        {
            return await _clienteRepository.GetAllClientes();
        }

        public async Task<Cliente> GetClienteById(int id)
        {
            return await _clienteRepository.GetClienteById(id);
        }

        public async Task<Cliente> AddCliente(Cliente cliente)
        {
            return await _clienteRepository.AddCliente(cliente);
        }

        public async Task<Cliente> UpdateCliente(Cliente cliente)
        {
            return await _clienteRepository.UpdateCliente(cliente);
        }

        public async Task<bool> DeactivateCliente(int id)
        {
            return await _clienteRepository.DeactivateCliente(id);
        }

        public async Task<bool> ActivateCliente(int id)
        {
            return await _clienteRepository.ActivateCliente(id);
        }
    }
}
