using DevIoBusiness.Models;

namespace DevIoBusiness.Intefaces
{
    public interface IModeloRepository
    {
        Task<IEnumerable<Modelo>> GetAllModelos();
        Task<Modelo> GetModeloById(int id);
        Task<Modelo> AddModelo(Modelo modelo);
        Task<Modelo> UpdateModelo(Modelo modelo);
        Task<bool> DeactivateModelo(int id);
        Task<bool> ActivateModelo(int id);
    }
}
