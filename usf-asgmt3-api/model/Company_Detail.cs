using System.ComponentModel.DataAnnotations;

namespace usf_asgmt3_api.model
{
    public class Company_Detail
    {
        [Key]
        public string symbol { get; set; }
        public string companyName { get; set; }
        public string exchange { get; set; }
        public string industry { get; set; }
        public string website { get; set; }
        public string description { get; set; }
        public string CEO { get; set; }
        public string issueType { get; set; }
        public string sector { get; set; }
    }
    
}
