using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevIoBusiness.Models
{
    public class Adicionais
    {
        [Key]
        public int IdAdicionais { get; private set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataAlteracao { get; set; }



        public List<CarroAdicionais> Carros { get; set; }


        public Adicionais()
        {

        }
    }
}
