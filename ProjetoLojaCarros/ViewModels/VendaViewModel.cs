using System.ComponentModel.DataAnnotations;

namespace DevIOApi.ViewModels
{
    public class VendaViewModel
    {
        public int IdVenda { get; private set; }
        public int IdFuncionario { get; set; }
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "O campo Valor Total é obrigatório.")]
        public double ValorTotal { get; set; }

        public List<CarroVendaViewModel> CarrosVendidos { get; set; }
        public List<VendaFormaPagamentoViewModel> VendaFormasPagamento { get; set; }

    }

    public class CarroVendaViewModel
    {
        public int IdCarro { get; set; }
        public double Valor { get; set; }

    }
    public class VendaFormaPagamentoViewModel
    {
        public int IdFormaPagamento { get; set; }
        public double Valor { get; set; }

    }
}