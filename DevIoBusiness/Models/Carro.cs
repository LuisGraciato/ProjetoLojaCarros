using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevIoBusiness.Models
{

    public class Carro
    {
        [Key]
        public int IdCarro { get; private set; }
        public string Placa { get; private set; }
        public int Quilometragem { get; private set; }
        public string Cor { get; private set; }
        public double Preco { get; private set; }
        public string EstadoConservacao { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataAlteracao { get; private set; }


        [ForeignKey("Modelo")]
        public int IdModelo { get; private set; }
        public Modelo Modelo { get; private set; }

        public ICollection<CarroAdicionais> CarroAdicionais { get; set; }


        public Carro(string placa, int quilometragem, string cor, double preco, string estadoConservacao, bool ativo)
        {
            Placa = placa;
            Quilometragem = quilometragem;
            Cor = cor;
            Preco = preco;
            EstadoConservacao = estadoConservacao;
            Ativo = ativo;
        }
    }
}

