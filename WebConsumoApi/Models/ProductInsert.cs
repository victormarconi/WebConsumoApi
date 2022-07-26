namespace WebConsumoApi.Models
{

    public class RootobjectInsert
    {
        public Product product { get; set; }
    }


    public class ProductInsert
    {
        public string name { get; set; }
        public string sku { get; set; }
        public string active { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public int qty { get; set; }
        public string ean { get; set; }
        public string sku_manufacturer { get; set; }
        public float net_weight { get; set; }
        public float gross_weight { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int depth { get; set; }
        public int items_per_package { get; set; }
        public int guarantee { get; set; }
        public int origin { get; set; }
        public string unity { get; set; }
        public string ncm { get; set; }
        public string manufacturer { get; set; }
        public int extra_operating_time { get; set; }
        public string category { get; set; }
        public string[] images { get; set; }
    }

}

