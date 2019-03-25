﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace usf_asgmt3_api.model
{
    public class Company_Financial
    {
        public string symbol { get; set; }
        public string reportDate { get; set; }
        public long? grossProfit { get; set; }
        public long? costOfRevenue { get; set; }
        public long? operatingRevenue { get; set; }
        public long? totalRevenue { get; set; }
        public long? operatingIncome { get; set; }
        public long? netIncome { get; set; }
        public long? researchAndDevelopment { get; set; }
        public long? operatingExpense { get; set; }
        public long? currentAssets { get; set; }
        public long? totalAssets { get; set; }
        public long? totalLiabilities { get; set; }
        public long? currentCash { get; set; }
        public long? currentDebt { get; set; }
        public long? totalCash { get; set; }
        public long? totalDebt { get; set; }
        public long? shareholderEquity { get; set; }
        public long? cashChange { get; set; }
        public long? cashFlow { get; set; }

    }
}
