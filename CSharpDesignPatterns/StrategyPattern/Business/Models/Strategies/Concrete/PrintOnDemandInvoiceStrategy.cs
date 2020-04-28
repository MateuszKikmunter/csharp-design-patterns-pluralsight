using Newtonsoft.Json;
using StrategyPattern.Business.Models.Strategies.Abstract;
using System;
using System.Net.Http;

namespace StrategyPattern.Business.Models.Strategies.Concrete
{
    public class PrintOnDemandInvoiceStrategy : IInvoiceStrategy
    {
        public void Generate(Order order)
        {
            using (var client = new HttpClient())
            {
                var content = JsonConvert.SerializeObject(order);
                client.BaseAddress = new Uri("https://pluralsight.com");
                client.PostAsync("/print-on-demand", new StringContent(content));
            }
        }
    }
}
