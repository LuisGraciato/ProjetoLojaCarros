using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using DevIoData.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIoData.Repository
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly MyDbContext _dbContext;

        public FuncionarioRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Funcionario>> GetAllFuncionarios()
        {
            return await _dbContext.Funcionarios.ToListAsync();
        }

        public async Task<Funcionario> GetFuncionarioById(int id)
        {
            return await _dbContext.Funcionarios.FindAsync(id);
        }

        public async Task<Funcionario> AddFuncionario(Funcionario funcionario)
        {
            _dbContext.Funcionarios.Add(funcionario);
            await _dbContext.SaveChangesAsync();
            return funcionario;
        }

        public async Task<Funcionario> UpdateFuncionario(Funcionario funcionario)
        {
            _dbContext.Entry(funcionario).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return funcionario;
        }

        public async Task<bool> DeactivateFuncionario(int id)
        {
            var funcionario = await _dbContext.Funcionarios.FindAsync(id);
            if (funcionario == null)
                return false;

            funcionario.Ativo = false;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ActivateFuncionario(int id)
        {
            var funcionario = await _dbContext.Funcionarios.FindAsync(id);
            if (funcionario == null)
                return false;

            funcionario.Ativo = true;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
