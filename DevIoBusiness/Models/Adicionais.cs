using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevIoBusiness.Models
{

    public class Adicionais
    {
        public int Id { get; private set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        public string Descricao { get; private set; }

        [Required(ErrorMessage = "O campo Preço é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O campo Preço deve ser um valor positivo.")]
        public decimal Preco { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataAlteracao { get; private set; }

        [ForeignKey("IdCarro")]
        public int IdCarro { get; private set; }
        public Carro Carro { get; private set; }


        public Adicionais(string nome, string descricao, decimal preco, bool ativo)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            Ativo = ativo;
        }



    }

}

