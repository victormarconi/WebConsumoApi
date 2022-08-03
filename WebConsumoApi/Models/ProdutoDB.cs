using System;
using System.Collections.Generic;

namespace WebConsumoApi.Models
{
    public partial class ProdutoDB
    {
        public string Name { get; set; } = null!;
        public string Sku { get; set; } = null!;
        public string Active { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Price { get; set; } = null!;
        public string Qty { get; set; } = null!;
        public string Ean { get; set; } = null!;
        public string SkuManufacturer { get; set; } = null!;
        public string NetWeight { get; set; } = null!;
        public string GrossWeight { get; set; } = null!;
        public string Width { get; set; } = null!;
        public string Height { get; set; } = null!;
        public string Depth { get; set; } = null!;
        public string Guarantee { get; set; } = null!;
        public string Origin { get; set; } = null!;
        public string Unity { get; set; } = null!;
        public string Ncm { get; set; } = null!;
        public string Manufacturer { get; set; } = null!;
        public string ExtraOperatingTime { get; set; } = null!;
        public string Category { get; set; } = null!;
        public string Images { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
