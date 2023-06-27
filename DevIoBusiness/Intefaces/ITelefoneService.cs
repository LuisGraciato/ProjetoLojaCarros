using DevIoBusiness.Models;

namespace DevIoBusiness.Interfaces
{
    public interface ITelefoneService
    {
        Task<IEnumerable<Telefone>> GetAllTelefones();
        Task<Telefone> GetTelefoneById(int id);
        Task<Telefone> AddTelefone(Telefone telefone);
        Task<Telefone> UpdateTelefone(Telefone telefone);
        Task<bool> ActivateTelefone(int id);
        Task<bool> DeactivateTelefone(int id);
    }
}
