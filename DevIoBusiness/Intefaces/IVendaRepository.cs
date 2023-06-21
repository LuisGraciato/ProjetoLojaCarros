using DevIoBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIoBusiness.Intefaces
{
    public interface IVendaRepository
    {
        Task<IEnumerable<Venda>> GetAllVendas();
        Task<Venda> GetVendaById(int id);
        Task AddVenda(Venda venda);
        Task UpdateVenda(Venda venda);
        Task DeleteVenda(int id);
    }
}
