using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;

namespace DevIoBusiness.Services
{
    public class TelefoneService : ITelefoneService
    {
        private readonly ITelefoneRepository _telefoneRepository;

        public TelefoneService(ITelefoneRepository telefoneRepository)
        {
            _telefoneRepository = telefoneRepository;
        }

        public async Task<IEnumerable<Telefone>> GetAllTelefones()
        {
            return await _telefoneRepository.GetAllTelefones();
        }

        public async Task<Telefone> GetTelefoneById(int id)
        {
            return await _telefoneRepository.GetTelefoneById(id);
        }

        public async Task<Telefone> AddTelefone(Telefone telefone)
        {
            return await _telefoneRepository.AddTelefone(telefone);
        }

        public async Task<Telefone> UpdateTelefone(Telefone telefone)
        {
            return await _telefoneRepository.UpdateTelefone(telefone);
        }

        public async Task<bool> ActivateTelefone(int id)
        {
            return await _telefoneRepository.ActivateTelefone(id);
        }

        public async Task<bool> DeactivateTelefone(int id)
        {
            return await _telefoneRepository.DeactivateTelefone(id);
        }
    }
}
