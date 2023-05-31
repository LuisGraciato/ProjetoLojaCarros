using DevIoBusiness.Models;

namespace DevIoBusiness.Interfaces
{
    public interface IEnderecoRepository
    {
        Task<IEnumerable<Endereco>> GetAllEnderecos();
        Task<Endereco> GetEnderecoById(int id);
        Task<Endereco> AddEndereco(Endereco endereco);
        Task<Endereco> UpdateEndereco(Endereco endereco);
        Task<bool> ActivateEndereco(int id);
        Task<bool> DeactivateEndereco(int id);
    }
}
