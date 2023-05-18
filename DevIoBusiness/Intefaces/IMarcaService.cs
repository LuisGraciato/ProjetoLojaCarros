using DevIoBusiness.Models;

namespace DevIoBusiness.Intefaces
{
    public interface IMarcaService
    {
        Task<IEnumerable<Marca>> GetAllMarcas();
        Task<Marca> GetMarcaById(int id);
        Task<Marca> AddMarca(Marca marca);
        Task<Marca> UpdateMarca(Marca marca);
        Task<bool> DeactivateMarca(int id);
        Task<bool> ActivateMarca(int id);
    }
}
