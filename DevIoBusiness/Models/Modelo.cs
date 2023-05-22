using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevIoBusiness.Models
{
    public class Modelo
    {
        [Key]
        public int IdModelo { get; private set; }
        public string Nome { get; set; }
        public string TipoCombustivel { get; set; }  
        public string TipoMotor { get;  set; }
        public int NumeroPortas { get; set; }
        public int NumeroLugares { get; set; }
        public int AnoFabricacao { get; set; }
        public int AnoModelo { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAlteracao { get; set; }


        [ForeignKey("IdMarca")]
        public int IdMarca { get; private set; }
        public Marca Marca { get; set; }

        public ICollection<Carro> Carros{ get; set; }

        public Modelo()
        {

        }
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

