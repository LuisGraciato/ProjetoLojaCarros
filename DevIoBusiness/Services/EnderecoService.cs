using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;

namespace DevIoBusiness.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<IEnumerable<Endereco>> GetAllEnderecos()
        {
            return await _enderecoRepository.GetAllEnderecos();
        }

        public async Task<Endereco> GetEnderecoById(int id)
        {
            return await _enderecoRepository.GetEnderecoById(id);
        }

        public async Task<Endereco> AddEndereco(Endereco endereco)
        {
            return await _enderecoRepository.AddEndereco(endereco);
        }

        public async Task<Endereco> UpdateEndereco(Endereco endereco)
        {
            return await _enderecoRepository.UpdateEndereco(endereco);
        }

        public async Task<bool> ActivateEndereco(int id)
        {
            return await _enderecoRepository.ActivateEndereco(id);
        }

        public async Task<bool> DeactivateEndereco(int id)
        {
            return await _enderecoRepository.DeactivateEndereco(id);
        }
    }
}
