using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevIoBusiness.Models
{
    public class Carro
    {
        [Key]
        public int IdCarro { get; private set; }
        public string Placa { get; set; }
        public int Quilometragem { get; set; }
        public string Cor { get; set; }
        public double Preco { get; set; }
        public string EstadoConservacao { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAlteracao { get; set; }

        [ForeignKey("Modelo")]
        public int IdModelo { get; set; }
        public Modelo Modelo { get; set; }

        public ICollection<CarroAdicionais> CarroAdicionais { get; set; }
        public ICollection<VendaCarro> VendaCarros { get; set; }

        public Carro()
        {

        }
    }
}

