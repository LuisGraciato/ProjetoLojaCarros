using System.ComponentModel.DataAnnotations;

namespace LojaCarrosApi.ViewModels
{
    // CarroDTO
    public class CarroViewModel
    {
        [Required(ErrorMessage = "O campo placa é obrigatório.")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "A placa deve ter 7 caracteres.")]
        public string Placa { get; private set; }

        [Required(ErrorMessage = "O campo quilometragem é obrigatório.")]
        public int Quilometragem { get; private set; }

        [Required(ErrorMessage = "O campo cor é obrigatório.")]
        public string Cor { get; private set; }

        [Required(ErrorMessage = "O campo preço é obrigatório.")]
        public double Preco { get; private set; }

        [Required(ErrorMessage = "O campo estado de conservação é obrigatório.")]
        public string EstadoConservacao { get; private set; }
        public bool Ativo { get; private set; }
        public int IdModelo { get; set; }

    }

}
