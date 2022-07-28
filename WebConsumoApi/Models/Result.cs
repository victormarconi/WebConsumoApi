namespace WebConsumoApi.Models
{
    public class Result
    {
        public bool error { get; set; }
        public int registers_count { get; set; }
        public int pages_count { get; set; }
        public int page { get; set; }
        public Datum[] data { get; set; }

        public Products product { get; set; }
    }
}