using System.ComponentModel.DataAnnotations;

namespace Vendas.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A cidade do cliente é obrigatória.")]
        public string Cidade { get; set; }
    }
}
