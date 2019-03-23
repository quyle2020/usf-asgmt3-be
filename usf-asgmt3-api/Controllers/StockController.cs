using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using usf_asgmt3_api.Integration;
using usf_asgmt3_api.model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace usf_asgmt3_api.Controllers
{
    //[Route("api/[controller]")]
    public class StockController : Controller
    {
        [HttpGet("/stock/getSymbols/")]
        public List<Company> GetSymbols()
        {

            var intrinio = new IntrinioRepo();
            var result = intrinio.GetCompaniesAsync().Result;
            
            return result;

        }

        
        [HttpPut("/stock/syncSymbols/")]
        public bool SyncSymbols(List<string> symbols)
        {

            var intrinio = new IntrinioRepo();
            //var list = new List<string> { symbol };

            DateTime now = DateTime.Now.Date;
            DateTime start = now.AddYears(-1);
            string frequency = "daily";

            var result = intrinio.GetCompanyPriceAsync(symbols, frequency, start, now).Result;
            //todo add repo for db


            return true;
        }
    }
}
