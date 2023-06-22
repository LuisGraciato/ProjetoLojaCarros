using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;

namespace DevIoBusiness.Services
{
    public class CarroService : ICarroService
    {
        private readonly ICarroRepository _carroRepository;

        public CarroService(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        public async Task<IEnumerable<Carro>> GetAllCarros()
        {
            return await _carroRepository.GetAllCarros();
        }

        public async Task<Carro> GetCarroById(int id)
        {
            return await _carroRepository.GetCarroById(id);
        }

        public async Task<Carro> AddCarro(Carro carro)
        {
            return await _carroRepository.AddCarro(carro);
        }

        public async Task<Carro> UpdateCarro(Carro carro)
        {
            return await _carroRepository.UpdateCarro(carro);
        }

        public async Task<bool> DeactivateCarro(int id)
        {
            return await _carroRepository.DeactivateCarro(id);
        }

        public async Task<bool> ActivateCarro(int id)
        {
            return await _carroRepository.ActivateCarro(id);
        }

        public async Task AtualizarEstadoCarroAposVenda(int id)
        {
            await _carroRepository.AtualizarEstadoCarroAposVenda(id);
        }
    }
}
