using System.ComponentModel.DataAnnotations;

namespace LojaCarrosApi.ViewModels
{
    public class ModeloViewModel
    {
        public int IdModelo { get; private set; }

        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo tipo de combustível é obrigatório.")]
        public string TipoCombustivel { get; set; }

        [Required(ErrorMessage = "O campo tipo de motor é obrigatório.")]
        public string TipoMotor { get; set; }

        [Required(ErrorMessage = "O campo número de portas é obrigatório.")]
        public int NumeroPortas { get; set; }

        [Required(ErrorMessage = "O campo número de lugares é obrigatório.")]
        public int NumeroLugares { get; set; }

        [Required(ErrorMessage = "O campo ano de fabricação é obrigatório.")]
        public int AnoFabricacao { get; set; }

        [Required(ErrorMessage = "O campo ano do modelo é obrigatório.")]
        public int AnoModelo { get; set; }
        public int IdMarca { get; set; }
    }

}
