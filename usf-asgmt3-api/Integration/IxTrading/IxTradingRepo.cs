using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using usf_asgmt3_api.model;

namespace usf_asgmt3_api.Integration.IxTrading
{
    public class IxTradingRepo: IIxTradingRepo
    {
        private string apiUrl = @"https://api.iextrading.com/1.0";
        private static readonly HttpClient client = new HttpClient();


        public async Task<List<Symbol>> GetSymbolsAsync()
        {
            string symbolList = "";

            var retVal = new List<Symbol>();

            string endpoint = $"{apiUrl}/ref-data/symbols";
            client.DefaultRequestHeaders.Accept.Clear();
            
            HttpResponseMessage response = client.GetAsync(endpoint).GetAwaiter().GetResult();

            // read the Json objects in the API response
            if (response.IsSuccessStatusCode)
            {
                symbolList =await response.Content.ReadAsStringAsync();
            }

            // now, parse the Json strings as C# objects
            if (!symbolList.Equals(""))
            {
                // https://stackoverflow.com/a/46280739
                //JObject result = JsonConvert.DeserializeObject<JObject>(companyList);
                retVal = JsonConvert.DeserializeObject<List<Symbol>>(symbolList);
            }


            return retVal;
        }

        public async Task<List<Company_Detail>> GetCompanyDetailAsync(List<string> symbolNames)
        {
            string resultString = "";

            var retVal = new List<Company_Detail>();

           
            client.DefaultRequestHeaders.Accept.Clear();

            foreach (var symbol in symbolNames)
            {
                string endpoint = $"{apiUrl}/stock/{symbol}/company";
                HttpResponseMessage response = client.GetAsync(endpoint).GetAwaiter().GetResult();

                // read the Json objects in the API response
                if (response.IsSuccessStatusCode)
                {
                    resultString = await response.Content.ReadAsStringAsync();
                }

                // now, parse the Json strings as C# objects
                if (!resultString.Equals(""))
                {
                    // https://stackoverflow.com/a/46280739
                    //JObject result = JsonConvert.DeserializeObject<JObject>(companyList);
                    var data = JsonConvert.DeserializeObject<Company_Detail>(resultString);
                    data.symbol = symbol;
                    retVal.Add(data);
                }
            }


            return retVal;
        }

        public async Task<List<Company_Dividend>> GetCompanyDividendAsync(List<string> symbolNames)
        {
            string resultString = "";

            var retVal = new List<Company_Dividend>();


            client.DefaultRequestHeaders.Accept.Clear();

            foreach (var symbol in symbolNames)
            {
                string endpoint = $"{apiUrl}/stock/{symbol}/dividends/5y"; // get 5 yrs dividend
                HttpResponseMessage response = client.GetAsync(endpoint).GetAwaiter().GetResult();

                // read the Json objects in the API response
                if (response.IsSuccessStatusCode)
                {
                    resultString = await response.Content.ReadAsStringAsync();
                }

                // now, parse the Json strings as C# objects
                if (!resultString.Equals(""))
                {
                    // https://stackoverflow.com/a/46280739
                    //JObject result = JsonConvert.DeserializeObject<JObject>(companyList);
                    var data = JsonConvert.DeserializeObject<List<Company_Dividend>>(resultString);
                    data.ForEach(a => a.symbol = symbol);
                    retVal.AddRange(data);
                }
            }


            return retVal;
        }

        public async Task<List<Company_Financial>> GetCompanyFinancialAsync(List<string> symbolNames)
        {
            string resultString = "";

            var retVal = new List<Company_Financial>();


            client.DefaultRequestHeaders.Accept.Clear();

            foreach (var symbol in symbolNames)
            {
                string endpoint = $"{apiUrl}/stock/{symbol}/financials?period=quarter"; // get quarterly financial report
                HttpResponseMessage response = client.GetAsync(endpoint).GetAwaiter().GetResult();

                // read the Json objects in the API response
                if (response.IsSuccessStatusCode)
                {
                    resultString = await response.Content.ReadAsStringAsync();
                }

                // now, parse the Json strings as C# objects
                if (!resultString.Equals(""))
                {
                    // https://stackoverflow.com/a/46280739
                    //JObject result = JsonConvert.DeserializeObject<JObject>(companyList);
                    var data = JsonConvert.DeserializeObject<Company_FinancialResponse>(resultString);
                    data.financials.ToList().ForEach(a => a.symbol = symbol);
                    retVal.AddRange(data.financials);
                }
            }


            return retVal;
        }

        public async Task<List<Company_Price>> GetCompanyPricesAsync(List<string> symbolNames)
        {
            string resultString = "";

            var retVal = new List<Company_Price>();


            client.DefaultRequestHeaders.Accept.Clear();

            foreach (var symbol in symbolNames)
            {
                string endpoint = $"{apiUrl}/stock/{symbol}/chart/2y"; // get 2 yrs prices
                HttpResponseMessage response = client.GetAsync(endpoint).GetAwaiter().GetResult();

                // read the Json objects in the API response
                if (response.IsSuccessStatusCode)
                {
                    resultString = await response.Content.ReadAsStringAsync();
                }

                //now, parse the Json strings as C# objects
                if (!resultString.Equals(""))
                {
                    // https://stackoverflow.com/a/46280739
                    //JObject result = JsonConvert.DeserializeObject<JObject>(companyList);
                    var data = JsonConvert.DeserializeObject<List<Company_Price>>(resultString);
                    data.ForEach(a => a.symbol = symbol);
                    retVal.AddRange(data);
                }
            }


            return retVal;
        }
    }
}
