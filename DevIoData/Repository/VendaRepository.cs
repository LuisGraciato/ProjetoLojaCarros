using DevIoBusiness.Intefaces;
using DevIoBusiness.Models;
using DevIoData.Context;
using Microsoft.EntityFrameworkCore;

namespace DevIoData.Repository
{
    public class VendaRepository : IVendaRepository
    {
        private readonly MyDbContext _dbContext;

        public VendaRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Venda>> GetAllVendas()
        {
            return await _dbContext.Vendas.ToListAsync();
        }

        public async Task<Venda> GetVendaById(int id)
        {
            return await _dbContext.Vendas.FindAsync(id);
        }

        public async Task AddVenda(Venda venda)
        {
            _dbContext.Vendas.Add(venda);

            foreach (var CarroVenda in venda.CarrosVendidos)
            {
                var carro = await _dbContext.Carros.FindAsync(CarroVenda.IdCarro);

                if (carro == null || !carro.Ativo)
                {
                    throw new Exception("Carro já vendido ou fora de estoque para venda.");
                }
                else
                {
                    carro.Ativo = false;
                    var vendaCarro = new VendaCarro
                    {
                        IdVenda = venda.IdVenda,
                        IdCarro = CarroVenda.IdCarro,
                        Valor = CarroVenda.Valor
                     nm
                    };

                    _dbContext.VendaCarros.Add(vendaCarro);
                }
            }

            await _dbContext.SaveChangesAsync();
           
        }


        public async Task UpdateVenda(Venda venda)
        {
            _dbContext.Vendas.Update(venda);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteVenda(int id)
        {
            var venda = await _dbContext.Vendas.FindAsync(id);
            if (venda == null)
                return;

            _dbContext.Vendas.Remove(venda);
            await _dbContext.SaveChangesAsync();
        }
    }

}
