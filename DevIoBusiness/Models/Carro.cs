using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevIoBusiness.Models
{

    public class Carro
    {
        [Key]
        public int IdCarro { get; private set; }

        [Required(ErrorMessage = "O campo placa é obrigatório.")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "A placa deve ter 7 caracteres.")]
        public string Placa { get; private set; }

        [Required(ErrorMessage = "O campo quilometragem é obrigatório.")]
        public int Quilometragem { get; private set; }

        [Required(ErrorMessage = "O campo cor é obrigatório.")]
        public string Cor { get; private set; }

        [Required(ErrorMessage = "O campo preço é obrigatório.")]
        public double Preco { get; private set; }

        [Required(ErrorMessage = "O campo estado de uso é obrigatório.")]
        public string EstadoConservacao { get; private set; }

        public bool Ativo { get; private set; }

        public DateTime DataAlteracao { get; private set; }

        [ForeignKey("Modelo")]
        public int IdModelo { get; private set; }
        public Modelo Modelo { get; set; }

        public ICollection<Adicionais> Adicionais { get; set; }


        public Carro(string placa, int quilometragem, string cor, decimal preco, string estadoConservacao, bool ativo)
        {
                Placa = placa;
                Quilometragem = quilometragem;
                Cor = cor;
                Preco = (double)preco;
                EstadoConservacao = estadoConservacao;
                Ativo = ativo;
        }


    }
}

