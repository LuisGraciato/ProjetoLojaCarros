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


        [ForeignKey("Marca")]
        public int IdMarca { get; set; }
        public Marca Marca { get; set; }

        public ICollection<Carro> Carros{ get; set; }

        public Modelo()
        {

        }
      
    }
}

