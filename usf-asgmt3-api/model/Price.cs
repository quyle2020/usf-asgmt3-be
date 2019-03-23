using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace usf_asgmt3_api.model
{
    public class Price
    {
        public string date { get; set; }
        public bool intraperiod { get; set; }
        public string frequency { get; set; }
        public float open { get; set; }
        public float high { get; set; }
        public float low { get; set; }
        public float close { get; set; }
        public int volume { get; set; }
        public float adj_open { get; set; }
        public float adj_high { get; set; }
        public float adj_low { get; set; }
        public float adj_close { get; set; }
        public int adj_volume { get; set; }

    }


    
}
