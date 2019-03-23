using usf_asgmt3_api.model;

namespace usf_asgmt3_api.Integration
{
    public class CompanyResponse
    {
        public Company[] companies { get; set; }

        public string next_page { get; set; }
    }
}
