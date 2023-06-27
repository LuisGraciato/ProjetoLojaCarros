using System.ComponentModel.DataAnnotations;

namespace DevIOApi.ViewModels
{
    public class NotaFiscalViewModel
    {
        public int IdNotaFiscal { get; private set; }

        [Required(ErrorMessage = "O campo numero da nota é obrigatório.")]
        public int NumeroNota{ get; set; }
        public int IdVenda { get; set; }
    }
}
