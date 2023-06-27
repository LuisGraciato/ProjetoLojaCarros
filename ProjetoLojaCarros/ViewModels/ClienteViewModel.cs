using System.ComponentModel.DataAnnotations;

namespace DevIOApi.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo Email não possui um formato válido.")]
        public string Email { get; set; }

        public int IdEndereco { get; set; }
        public int IdTelefone { get; set; }
    }
}

