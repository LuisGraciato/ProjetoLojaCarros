using DevIoBusiness.Models;

namespace DevIoBusiness.Interfaces
{
    public interface IAdicionaisService
    {
        Task<IEnumerable<Adicionais>> GetAllAdicionais();
        Task<Adicionais> GetAdicionaisById(int id);
        Task<Adicionais> AddAdicionais(Adicionais adicionais);
        Task<Adicionais> UpdateAdicionais(Adicionais adicionais);
        Task DeleteAdicionais(int id);
    }
}
