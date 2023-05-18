using System.ComponentModel.DataAnnotations;

namespace Vendas.Models
{
    public class Produto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "A descrição do produto é obrigatória.")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O valor do produto é obrigatório.")]
        public double Valor { get; set; }
    }
}
