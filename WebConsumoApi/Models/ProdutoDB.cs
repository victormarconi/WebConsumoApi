using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebConsumoApi.Models
{
    public partial class ProdutoDB
    {
        [Display(Name = "Nome")]
        public string Name { get; set; } = " ";
        [Key]
        public string Sku { get; set; } = " ";
        [Display(Name = "Ativo")]
        public string Active { get; set; } = " ";
        public string Description { get; set; } = " ";
        [Display(Name = "Preço")]
        public string Price { get; set; } = " ";
        [Display(Name = "Estoque")]
        public string Qty { get; set; } = " ";
        public string Ean { get; set; } = " ";
        public string SkuManufacturer { get; set; } = " ";
        public string NetWeight { get; set; } = " ";
        public string GrossWeight { get; set; } = " ";
        public string Width { get; set; } = " ";
        public string Height { get; set; } = " ";
        public string Depth { get; set; } = " ";
        public string Guarantee { get; set; } = " ";
        public string Origin { get; set; } = " ";
        public string Unity { get; set; } = " ";
        public string Ncm { get; set; } = " ";
        public string Manufacturer { get; set; } = " ";
        public string ExtraOperatingTime { get; set; } = " ";
        public string Category { get; set; } = " ";
        public string Images { get; set; } = " ";
        public string? Status { get; set; } = " ";
        public string? Motivo { get; set; } = " ";
    }
}
