using DevIoBusiness.Intefaces;
using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;

namespace DevIoBusiness.Services
{
    public class AdicionaisService : IAdicionaisService
    {
        private readonly IAdicionaisRepository _AdicionaisRepository;

        public AdicionaisService(IAdicionaisRepository adicionaisRepository)
        {
            _AdicionaisRepository = adicionaisRepository;
        }

        public async Task<IEnumerable<Adicionais>> GetAllAdicionais()
        {
            return await _AdicionaisRepository.GetAllAdicionais();
        }

        public async Task<Adicionais> GetAdicionaisById(int id)
        {
            return await _AdicionaisRepository.GetAdicionaisById(id);
        }

        public async Task<Adicionais> AddAdicionais(Adicionais adicionais)
        {
            return await _AdicionaisRepository.AddAdicionais(adicionais);
        }

        public async Task<Adicionais> UpdateAdicionais(Adicionais adicionais)
        {
            return await _AdicionaisRepository.UpdateAdicionais(adicionais);
        }

        public async Task DeleteAdicionais(int id)
        {
            await _AdicionaisRepository.DeleteAdicionais(id);
        }
    }
}

