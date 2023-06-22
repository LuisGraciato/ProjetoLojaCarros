using System.ComponentModel.DataAnnotations;

namespace DevIOApi.ViewModels
{
    public class FormaPagamentoViewModel
    {
        public int IdFormaPagamento { get; private set; }

        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório.")]
        public string Descricao { get; set; }

    }

}

