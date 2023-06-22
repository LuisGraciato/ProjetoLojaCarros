using System.ComponentModel.DataAnnotations;

namespace LojaCarrosApi.ViewModels
{
    public class MarcaViewModel
    {
        public int IdMarca { get; private set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
    }

}
