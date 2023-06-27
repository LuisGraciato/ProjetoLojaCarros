using System.ComponentModel.DataAnnotations;

namespace DevIOApi.ViewModels
{
    public class TelefoneViewModel
    {
        public int IdTelefone { get; private set; }

        [Required(ErrorMessage = "O campo Número é obrigatório.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "O campo DDD é obrigatório.")]
        public string DDD { get; set; }

        [Required(ErrorMessage = "O campo DDI é obrigatório.")]
        public string DDI { get; set; }

    }
}
