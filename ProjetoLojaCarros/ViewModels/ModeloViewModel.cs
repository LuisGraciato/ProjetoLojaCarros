using System.ComponentModel.DataAnnotations;

namespace LojaCarrosApi.ViewModels
{
    // ModeloDTO
    public class ModeloViewModel
    {

        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "O campo tipo de combustível é obrigatório.")]
        public string TipoCombustivel { get; private set; }

        [Required(ErrorMessage = "O campo tipo de motor é obrigatório.")]
        public string TipoMotor { get; private set; }

        [Required(ErrorMessage = "O campo número de portas é obrigatório.")]
        public int NumeroPortas { get; private set; }

        [Required(ErrorMessage = "O campo número de lugares é obrigatório.")]
        public int NumeroLugares { get; private set; }

        [Required(ErrorMessage = "O campo ano de fabricação é obrigatório.")]
        public int AnoFabricacao { get; private set; }

        [Required(ErrorMessage = "O campo ano do modelo é obrigatório.")]
        public int AnoModelo { get; private set; }
        public bool Ativo { get; private set; }
        public int IdMarca { get; set; }
    }

}
