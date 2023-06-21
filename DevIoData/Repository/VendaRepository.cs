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
            var vendas = await _dbContext.Vendas.Include(v => v.CarrosVendidos).ToListAsync();

            foreach (var venda in vendas)
            {
                venda.CarrosVendidos = venda.CarrosVendidos.Select(cv => new VendaCarro
                {
                    IdCarro = cv.IdCarro,
                    Valor = cv.Valor
                }).ToList();
            }

            return vendas;
        }




        public async Task<Venda> GetVendaById(int id)
        {
            return await _dbContext.Vendas.FindAsync(id);
        }

        public async Task AddVenda(Venda venda)
        {
            _dbContext.Vendas.Add(venda);

            await _dbContext.SaveChangesAsync();

            var novosCarrosVendidos = new List<VendaCarro>(); 

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
                    };

                    novosCarrosVendidos.Add(vendaCarro); 
                }
            }

            venda.CarrosVendidos = novosCarrosVendidos;

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
