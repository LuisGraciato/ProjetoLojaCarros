using DevIoBusiness.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIoBusiness.Interfaces
{
    public interface ICarroRepository
    {
        Task<IEnumerable<Carro>> GetAllCarros();
        Task<Carro> GetCarroById(int id);
        Task<Carro> AddCarro(Carro carro);
        Task<Carro> UpdateCarro(Carro carro);
        Task<bool> DeactivateCarro(int id);
        Task<bool> ActivateCarro(int id);
    }
}
