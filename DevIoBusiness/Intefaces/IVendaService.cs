using DevIoBusiness.Models;

namespace DevIoBusiness.Intefaces
{
    public interface IVendaService
    {
        Task<IEnumerable<Venda>> GetAllVendas();
        Task<Venda> GetVendaById(int id);
        Task AddVenda(Venda venda);
        Task UpdateVenda(Venda venda);
        Task DeleteVenda(int id);
    }
}
