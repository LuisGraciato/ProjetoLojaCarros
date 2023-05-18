using System.ComponentModel.DataAnnotations;

namespace LojaCarrosApi.ViewModels
{
    // CarroAdicionaisDTO
    public class CarroAdicionaisViewModel
    {

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Descricao { get; private set; }

        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O campo Preço deve ser um valor positivo.")]
        public double Preco { get; private set; }

        public bool Ativo { get; private set; }
        public int IdCarro { get; set; }
    }

}
