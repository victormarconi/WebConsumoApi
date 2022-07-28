using System;
using System.Collections.Generic;

namespace WebConsumoApi.Models
{
    public partial class Produto
    {
        public int Sku { get; set; }
        public string? IdItem { get; set; }
        public string? NomeItem { get; set; }
        public string? QtdEstoque { get; set; }
        public string? PrecoPor { get; set; }
    }
}
