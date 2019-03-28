using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace usf_asgmt3_api.model
{ 
    public class Company_Price
    {
        public string symbol { get; set; }
        public string date { get; set; }
        public float open { get; set; }
        public float high { get; set; }
        public float low { get; set; }
        public float close { get; set; }
        public int volume { get; set; }

    }
}
