using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using usf_asgmt3_api.Integration;
using usf_asgmt3_api.Integration.LocalDataRepo;
using usf_asgmt3_api.model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace usf_asgmt3_api.Controllers
{
    
    //[Route("api/[controller]")]
    public class StockController : Controller
    {
        public LocalDBContext dbContext;


        public StockController(LocalDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("/stock/syncSymbols/")]
        public List<Company> SyncSymbols()
        {

            var intrinio = new IntrinioRepo();
            var list = intrinio.GetCompaniesAsync().Result;
            int i = 0;

            foreach (var item in list)
            {
                if (item.ticker != null)
                {
                    var exist = dbContext.Companies.Any(a => a.ticker == item.ticker);

                    if (!exist)
                    {
                        try{
                            dbContext.Companies.Add(item);
                        }
                        catch (Exception ex) { 
                            dbContext.Entry(item).State = EntityState.Detached;
                        }
                    }
                }
                i++;
                
                if(i%100 == 0)
                    dbContext.SaveChanges(); // lets save this hundred batch
            }

            dbContext.SaveChanges(); // get the last un saved records
            
            return list;

        }

        
        [HttpPut("/stock/syncSymbolPrices/")]
        public bool SyncSymbolPrices(List<string> symbols)
        {

            var intrinio = new IntrinioRepo();
            //var list = new List<string> { symbol };

            DateTime now = DateTime.Now.Date;
            DateTime start = now.AddYears(-1);
            string frequency = "daily";
            foreach (var symbol in symbols)
            {
                var cleanedSymbol = symbol?.ToUpper();

                var list = intrinio.GetCompanyPriceAsync(cleanedSymbol, frequency, start, now).Result;

                // clean old data
                dbContext.Prices.FromSql($"Delete from dbo.Prices where ticket = '{cleanedSymbol}'");

                //todo add repo for db
                foreach (var item in list)
                {
                    item.ticker = cleanedSymbol;
                    dbContext.Prices.Attach(item);
                }
                dbContext.SaveChanges();
            }
            return true;
        }
    }
}