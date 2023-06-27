using DevIoBusiness.Models;

namespace DevIoBusiness.Interfaces
{
    public interface ICarroService
    {
        Task<IEnumerable<Carro>> GetAllCarros();
        Task<Carro> GetCarroById(int id);
        Task<Carro> AddCarro(Carro carro);
        Task<Carro> UpdateCarro(Carro carro);
        Task<bool> DeactivateCarro(int id);
        Task<bool> ActivateCarro(int id);
        Task AtualizarEstadoCarroAposVenda(int id);

    }
}
