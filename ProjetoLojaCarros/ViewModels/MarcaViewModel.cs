using System.ComponentModel.DataAnnotations;

namespace LojaCarrosApi.ViewModels
{
    // MarcaDTO
    public class MarcaViewModel
    {
        public int IdMarca { get; private set; }
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }
        public bool Ativo { get; set; }
    }

}
