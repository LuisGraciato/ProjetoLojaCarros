using DevIoBusiness.Models;

namespace DevIoBusiness.Interfaces
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<Funcionario>> GetAllFuncionarios();
        Task<Funcionario> GetFuncionarioById(int id);
        Task<Funcionario> AddFuncionario(Funcionario funcionario);
        Task<Funcionario> UpdateFuncionario(Funcionario funcionario);
        Task<bool> DeactivateFuncionario(int id);
        Task<bool> ActivateFuncionario(int id);
    }

}