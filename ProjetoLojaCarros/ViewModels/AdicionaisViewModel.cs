using System.ComponentModel.DataAnnotations;

namespace LojaCarrosApi.ViewModels
{
    public class AdicionaisViewModel
    {
        public int IdAdicionais { get; private set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O campo Preço deve ser um valor positivo.")]
        public double Preco { get; set; }
    }

}
