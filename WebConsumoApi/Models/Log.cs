using System.ComponentModel.DataAnnotations;

namespace WebConsumoApi.Models
{
    public class Log
    {
        [Key]
        public string Sku { get; set; }
        public string Status { get; set; }
        public string Motivo { get; set; }
    }
}
