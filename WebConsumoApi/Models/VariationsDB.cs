using System.ComponentModel.DataAnnotations;

namespace WebConsumoApi.Models
{
    public class VariationsDB
    {  
        public class Product_Variations
        {
            [Key]
            public string sku { get; set; }
            public string sku_pai { get; set; }
            public string qty { get; set; }
            public string? color { get; set; }
            public string? voltagem { get; set; }
            public string? sabor { get; set; }
            public string? size { get; set; }
            public string? EAN { get; set; }
            public string images { get; set; }
        }
    }
}
