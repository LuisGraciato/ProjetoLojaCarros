using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;

namespace DevIoBusiness.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository)
        {
            _funcionarioRepository = funcionarioRepository;
        }

        public async Task<IEnumerable<Funcionario>> GetAllFuncionarios()
        {
            return await _funcionarioRepository.GetAllFuncionarios();
        }

        public async Task<Funcionario> GetFuncionarioById(int id)
        {
            return await _funcionarioRepository.GetFuncionarioById(id);
        }

        public async Task<Funcionario> AddFuncionario(Funcionario funcionario)
        {
            return await _funcionarioRepository.AddFuncionario(funcionario);
        }

        public async Task<Funcionario> UpdateFuncionario(Funcionario funcionario)
        {
            return await _funcionarioRepository.UpdateFuncionario(funcionario);
        }

        public async Task<bool> DeactivateFuncionario(int id)
        {
            return await _funcionarioRepository.DeactivateFuncionario(id);
        }

        public async Task<bool> ActivateFuncionario(int id)
        {
            return await _funcionarioRepository.ActivateFuncionario(id);
        }
    }
}
