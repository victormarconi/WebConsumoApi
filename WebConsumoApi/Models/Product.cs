using System.ComponentModel.DataAnnotations;

namespace WebConsumoApi.Models
{

    public class Product
    {

        [Display(Name = "Produto")]
        public string name { get; set; }

        [Display(Name = "SKU")]
        public string sku { get; set; }

        [Display(Name = "SKU do Fabricante")]
        public string sku_manufacturer { get; set; }

        [Display(Name = "Descrição")]
        public string description { get; set; }

        [Display(Name = "Status")]
        public string status { get; set; }

        [Display(Name = "Estoque")]
        public int qty { get; set; }

        [Display(Name = "Preço por")]
        public float price { get; set; }

        [Display(Name = "Preço de")]
        public float? list_price { get; set; }

        [Display(Name = "Peso Bruto")]
        public float weight_gross { get; set; }

        [Display(Name = "Peso Líquido")]
        public float weight_liquid { get; set; }

        [Display(Name = "Altura")]
        public int height { get; set; }

        [Display(Name = "Largura")]
        public int width { get; set; }

        [Display(Name = "Comprimento")]
        public int length { get; set; }

        [Display(Name = "Itens por pacote")]
        public string items_per_package { get; set; }

        [Display(Name = "Marca")]
        public string brand { get; set; }

        [Display(Name = "EAN")]
        public string ean { get; set; }

        [Display(Name = "NCM")]
        public string ncm { get; set; }

        [Display(Name = "Categoria")]
        public Category[] categories { get; set; }

        [Display(Name = "Variação de Atributos")]
        public string[] variation_attributes { get; set; }

        [Display(Name = "Variações")]
        public Variation[] variations { get; set; }

        [Display(Name = "Imagens")]
        public List<string> images { get; set; }
        public Published_Marketplace published_marketplace { get; set; }
        public Marketplace_Offer_Links[] marketplace_offer_links { get; set; }

    }
}