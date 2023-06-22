using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using DevIoData.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIoData.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly MyDbContext _context;

        public EnderecoRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Endereco>> GetAllEnderecos()
        {
            return await _context.Enderecos.ToListAsync();
        }

        public async Task<Endereco> GetEnderecoById(int id)
        {
            return await _context.Enderecos.FindAsync(id);
        }

        public async Task<Endereco> AddEndereco(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task<Endereco> UpdateEndereco(Endereco endereco)
        {
            _context.Entry(endereco).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return endereco;
        }

        public async Task<bool> ActivateEndereco(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null)
                return false;

            endereco.Ativo = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeactivateEndereco(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null)
                return false;

            endereco.Ativo = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
