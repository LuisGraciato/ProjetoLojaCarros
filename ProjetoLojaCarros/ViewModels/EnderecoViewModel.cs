using System.ComponentModel.DataAnnotations;

namespace DevIOApi.ViewModels
{
    public class EnderecoViewModel
    {
        public int IdEndereco { get; private set; }

        [Required(ErrorMessage = "O campo Rua é obrigatório.")]
        public string Rua { get; set; }

        [Required(ErrorMessage = "O campo Bairro é obrigatório.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O campo CEP é obrigatório.")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O campo Número é obrigatório.")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O campo Complemento é obrigatório.")]
        public string Complemento { get; set; }
        
    }
}
