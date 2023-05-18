namespace Vendas.Models
{
    public class Venda
    {

        public Venda()
        {
            Cliente = new Cliente();
            Produto = new Produto();
        }

        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public double ValorUnitario { get; set; }
        public DateTime DataVenda { get; set; }
        public double ValorTotal { get; set; }
    }
}
