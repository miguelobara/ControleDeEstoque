using System;

namespace ControleDeEstoque.Models
{
    public class Venda
    {
        public int IdVenda { get; set; }
        public int IdProduto { get; set; }
        public int IdUsuario { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public DateTime DataVenda { get; set; }
    }
}