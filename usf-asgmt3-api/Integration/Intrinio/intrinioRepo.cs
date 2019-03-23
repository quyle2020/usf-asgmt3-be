using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading;
using System.Threading.Tasks;
using usf_asgmt3_api.model;

namespace usf_asgmt3_api.Integration
{
    public class IntrinioRepo
    {
        private string apiUrlV2 = @"https://api-v2.intrinio.com";
        private string apiKey = "";
        private static readonly HttpClient client = new HttpClient();
        

        public async Task<List<Company>> GetCompaniesAsync()
        {
            int pageNumber = 1;
            int pageSize = 100;

            string nextPage = string.Empty;

            var retVal = new List<Company>();

            string endpoint = $"{apiUrlV2}/companies?api_key={apiKey}&page_size={pageSize}";
            client.DefaultRequestHeaders.Accept.Clear();
            var serializer = new DataContractJsonSerializer(typeof(CompanyResponse));

            do
            {
                try
                {
                    if (pageNumber % 100 == 1) // throttle limits: Users enjoying free data feed subscriptions only are limited to 100 requests per second.
                        Thread.Sleep(1000);

                    var streamTask = client.GetStreamAsync($"{endpoint}&next_page={nextPage}");
                    var resp = serializer.ReadObject(await streamTask) as CompanyResponse;
                    
                    nextPage = resp.next_page;

                    var data = resp.companies.Where(a => !string.IsNullOrEmpty(a.ticker));

                    foreach (var p in data)
                    {
                        retVal.Add(p);
                    }
                    pageNumber++;

                    if (pageNumber > 2) break; // break out here for first 200 records -- remove this in production plz
                }
                catch (Exception ex)
                {
                    break;
                }
            }
            while (nextPage != null);
            

            return retVal;
        }

        public async Task<List<Price>> GetCompanyPriceAsync(List<string> symbols, string frequency, DateTime start, DateTime end)
        {
            
            var retVal = new List<Price>();
            int pageNumber = 1;
            int pageSize = 100;

            string nextPage = string.Empty;

            client.DefaultRequestHeaders.Accept.Clear();
            var serializer = new DataContractJsonSerializer(typeof(CompanyPriceResponse));


            foreach(var symbol in symbols)
            {
                string endpoint = $"{apiUrlV2}/securities/{symbol}/prices?api_key={apiKey}&page_size={pageSize}&frequency={frequency}&start_date={start.ToString("yyyy-MM-dd")}&end_date={end.ToString("yyyy-MM-dd")}";
                do
                {
                    try
                    {
                        if (pageNumber % 100 == 1) // throttle limits: Users enjoying free data feed subscriptions only are limited to 100 requests per second.
                            Thread.Sleep(1000);
                        
                        var streamTask = client.GetStreamAsync($"{endpoint}&next_page={nextPage}");
                        var resp = serializer.ReadObject(await streamTask) as CompanyPriceResponse;

                        nextPage = resp.next_page;

                        var data = resp.stock_prices;

                        foreach (var p in data)
                        {
                            retVal.Add(p);
                        }
                        pageNumber++;

                        
                    }
                    catch (Exception ex)
                    {
                        break;
                    }
                }
                while (nextPage != null);
            }


            return retVal;
        }
    }
}
