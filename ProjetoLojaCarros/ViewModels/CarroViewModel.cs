using System.ComponentModel.DataAnnotations;

namespace LojaCarrosApi.ViewModels
{
    public class CarroViewModel
    {
        public int IdCarro { get; private set; }

        [Required(ErrorMessage = "O campo placa é obrigatório.")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "A placa deve ter 7 caracteres.")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O campo quilometragem é obrigatório.")]
        public int Quilometragem { get; set; }

        [Required(ErrorMessage = "O campo cor é obrigatório.")]
        public string Cor { get; set; }

        [Required(ErrorMessage = "O campo preço é obrigatório.")]
        public double Preco { get; set; }

        [Required(ErrorMessage = "O campo estado de conservação é obrigatório.")]
        public string EstadoConservacao { get; set; }
        public int IdModelo { get; set; }

        public List<CarroAdicionaisViewModel> CarroAdicionais { get; set; }

    }
    public class CarroAdicionaisViewModel
    {
        public int IdAdicionais { get; set; }
        public double Valor { get; set; }

    }

}
