using DevIoBusiness.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIoBusiness.Interfaces
{
    public interface ICarroAdicionaisService
    {
        Task<IEnumerable<CarroAdicionais>> GetAllCarrosAdicionais();
        Task<CarroAdicionais> GetCarroAdicionaisById(int id);
        Task<CarroAdicionais> AddCarroAdicionais(CarroAdicionais carroAdicionais);
        Task<CarroAdicionais> UpdateCarroAdicionais(CarroAdicionais carroAdicionais);
        Task<bool> DeactivateCarroAdicionais(int id);
        Task<bool> ActivateCarroAdicionais(int id);
    }
}
