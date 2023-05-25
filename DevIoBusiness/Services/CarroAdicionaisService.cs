using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIoBusiness.Services
{
    public class CarroAdicionaisService : ICarroAdicionaisService
    {
        private readonly ICarroAdicionaisRepository _carroAdicionaisRepository;

        public CarroAdicionaisService(ICarroAdicionaisRepository carroAdicionaisRepository)
        {
            _carroAdicionaisRepository = carroAdicionaisRepository;
        }

        public async Task<IEnumerable<CarroAdicionais>> GetAllCarrosAdicionais()
        {
            return await _carroAdicionaisRepository.GetAllCarrosAdicionais();
        }

        public async Task<CarroAdicionais> GetCarroAdicionaisById(int id)
        {
            return await _carroAdicionaisRepository.GetCarroAdicionaisById(id);
        }

        public async Task<CarroAdicionais> AddCarroAdicionais(CarroAdicionais carroAdicionais)
        {
            return await _carroAdicionaisRepository.AddCarroAdicionais(carroAdicionais);
        }

        public async Task<CarroAdicionais> UpdateCarroAdicionais(CarroAdicionais carroAdicionais)
        {
            return await _carroAdicionaisRepository.UpdateCarroAdicionais(carroAdicionais);
        }

        public async Task<bool> DeactivateCarroAdicionais(int id)
        {
            return await _carroAdicionaisRepository.DeactivateCarroAdicionais(id);
        }

        public async Task<bool> ActivateCarroAdicionais(int id)
        {
            return await _carroAdicionaisRepository.ActivateCarroAdicionais(id);
        }
    }
}

