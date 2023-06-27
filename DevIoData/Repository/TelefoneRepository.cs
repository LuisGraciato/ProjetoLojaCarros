using DevIoBusiness.Interfaces;
using DevIoBusiness.Models;
using DevIoData.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIoData.Repository
{
    public class TelefoneRepository : ITelefoneRepository
    {
        private readonly MyDbContext _context;

        public TelefoneRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Telefone>> GetAllTelefones()
        {
            return await _context.Telefones.ToListAsync();
        }

        public async Task<Telefone> GetTelefoneById(int id)
        {
            return await _context.Telefones.FindAsync(id);
        }

        public async Task<Telefone> AddTelefone(Telefone telefone)
        {
            _context.Telefones.Add(telefone);
            await _context.SaveChangesAsync();
            return telefone;
        }

        public async Task<Telefone> UpdateTelefone(Telefone telefone)
        {
            _context.Telefones.Update(telefone);
            await _context.SaveChangesAsync();
            return telefone;
        }

        public async Task<bool> ActivateTelefone(int id)
        {
            var telefone = await _context.Telefones.FindAsync(id);
            if (telefone == null)
                return false;

            telefone.Ativo = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeactivateTelefone(int id)
        {
            var telefone = await _context.Telefones.FindAsync(id);
            if (telefone == null)
                return false;

            telefone.Ativo = false;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
