namespace usf_asgmt3_api.model
{
    public class Company
    {
        public string id { get; set; }
        public string ticker { get; set; }
        public string name { get; set; }
        public string lei { get; set; }
        public string cik { get; set; }
        public string industry_category { get; set; }
        public long? market_cap { get; set; }
    }
}
