namespace WebConsumoApi.Models
{
    public class Variation
    {
        public string sku { get; set; }
        public int qty { get; set; }
        public object EAN { get; set; }
        public float price { get; set; }
        public float list_price { get; set; }
        public object[] images { get; set; }
        public Variant[] variant { get; set; }
    }
}