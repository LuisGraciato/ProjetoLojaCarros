using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevIoBusiness.Models
{
    public class CarroAdicionais
    {
        [Key]
        public int IdAdicionais { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public double Preco { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataAlteracao { get; private set; }


        [ForeignKey("Carro")]
        public int IdCarro { get; private set; }
        public Carro Carro { get; private set; }

        public CarroAdicionais(string nome, string descricao, double preco, bool ativo)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Ativo = ativo;
        }
    }
}
