using DevIoBusiness.Intefaces;
using DevIoBusiness.Models;

namespace DevIoBusiness.Services
{
    public class ModeloService : IModeloService
    {
        private readonly IModeloRepository _modeloRepository;


        public ModeloService(IModeloRepository modeloRepository)
        {
            _modeloRepository = modeloRepository;

        }

        public async Task<IEnumerable<Modelo>> GetAllModelos()
        {
            return await _modeloRepository.GetAllModelos();
        }

        public async Task<Modelo> GetModeloById(int id)
        {
            return await _modeloRepository.GetModeloById(id);
        }

        public async Task<Modelo> AddModelo(Modelo modelo)
        {
            return await _modeloRepository.AddModelo(modelo);
        }

        public async Task<Modelo> UpdateModelo(Modelo modelo)
        {
            return await _modeloRepository.UpdateModelo(modelo);
        }

        public async Task<bool> DeactivateModelo(int id)
        {
            return await _modeloRepository.DeactivateModelo(id);
        }
        public async Task<bool> ActivateModelo(int id)
        {
            return await _modeloRepository.ActivateModelo(id);
        }
    }
}
