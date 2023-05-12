using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevIoBusiness.Models
{
    public class Modelo
    {
        [Key]
        public int IdModelo { get; private set; }

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
        public DateTime DataAlteracao { get; private set; }



        [ForeignKey("IdMarca")]
        public int IdMarca { get; private set; }
        public Marca Marca { get; private set; }

        public List<Carro> Carros { get; private set; }

        public Modelo(string nome, string tipoCombustivel, string tipoMotor, int numeroPortas, int numeroLugares, int anoFabricacao, int anoModelo, bool ativo)
        {
            Nome = nome;
            TipoCombustivel = tipoCombustivel;
            TipoMotor = tipoMotor;
            NumeroPortas = numeroPortas;
            NumeroLugares = numeroLugares;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
            Ativo = ativo;


        }
    }
}

