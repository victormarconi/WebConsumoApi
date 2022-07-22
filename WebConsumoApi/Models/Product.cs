namespace WebConsumoApi.Models
{

    public class Product
    {
        public string sku { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string status { get; set; }
        public int qty { get; set; }
        public float price { get; set; }
        public float? list_price { get; set; }
        public float weight_gross { get; set; }
        public float weight_liquid { get; set; }
        public int height { get; set; }
        public int width { get; set; }
        public int length { get; set; }
        public string items_per_package { get; set; }
        public string brand { get; set; }
        public string ean { get; set; }
        public object ncm { get; set; }
        public Category[] categories { get; set; }
        public string[] variation_attributes { get; set; }
        public Variation[] variations { get; set; }
        public string[] images { get; set; }
        public Published_Marketplace published_marketplace { get; set; }
        public Marketplace_Offer_Links[] marketplace_offer_links { get; set; }
    }
}