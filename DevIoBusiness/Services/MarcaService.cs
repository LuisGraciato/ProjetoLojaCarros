using DevIoBusiness.Intefaces;
using DevIoBusiness.Models;

namespace DevIoBusiness.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;


        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;

        }

        public async Task<IEnumerable<Marca>> GetAllMarcas()
        {
            return await _marcaRepository.GetAllMarcas();
        }

        public async Task<Marca> GetMarcaById(int id)
        {
            return await _marcaRepository.GetMarcaById(id);
        }

        public async Task<Marca> AddMarca(Marca marca)
        {
            return await _marcaRepository.AddMarca(marca);
        }

        public async Task<Marca> UpdateMarca(Marca marca)
        {
            return await _marcaRepository.UpdateMarca(marca);
        }

        public async Task<bool> DeactivateMarca(int id)
        {
            return await _marcaRepository.DeactivateMarca(id);
        }
        public async Task<bool> ActivateMarca(int id)
        {
            return await _marcaRepository.ActivateMarca(id);
        }
    }
}
