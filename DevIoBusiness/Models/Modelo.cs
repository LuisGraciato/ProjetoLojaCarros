using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevIoBusiness.Models
{
    public class Modelo
    {
        [Key]
        public int IdModelo { get; private set; }
        public string Nome { get; private set; }
        public string TipoCombustivel { get; private set; }  
        public string TipoMotor { get; private set; }
        public int NumeroPortas { get; private set; }
        public int NumeroLugares { get; private set; }
        public int AnoFabricacao { get; private set; }
        public int AnoModelo { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataAlteracao { get; private set; }


        [ForeignKey("IdMarca")]
        public int IdMarca { get; private set; }
        public Marca Marca { get; private set; }

        public ICollection<Carro> Carros{ get; set; }


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

