using System.ComponentModel.DataAnnotations;

namespace DevIoBusiness.Models
{
    public class Marca
    {
        [Key]
        public int IdMarca { get; private set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; private set; }
        public bool Ativo { get; private set; }
        public DateTime DataAlteracao { get; private set; }

        public List<Modelo> Modelos { get; private set; }

        public Marca(string nome, bool ativo)
        {
            Nome = nome;
            Ativo = ativo;
            
        }
    }
}
