using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevIoBusiness.Models
{
    public class FormaPagamento
    {
        [Key]
        public int IdFormaPagamento { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }

}
