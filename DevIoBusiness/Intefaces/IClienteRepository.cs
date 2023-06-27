using DevIoBusiness.Models;

namespace DevIoBusiness.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllClientes();
        Task<Cliente> GetClienteById(int id);
        Task<Cliente> AddCliente(Cliente cliente);
        Task<Cliente> UpdateCliente(Cliente cliente);
        Task<bool> DeactivateCliente(int id);
        Task<bool> ActivateCliente(int id);
    }
}
