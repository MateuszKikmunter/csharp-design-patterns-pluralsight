﻿using StrategyPattern.Business.Models;
using StrategyPattern.Business.Models.Enums;
using StrategyPattern.Business.Models.Strategies.Concrete;
using System;

namespace StrategyPattern
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var order = new Order
            {
                ShippingDetails = new ShippingDetails
                {
                    OriginCountry = "Sweden",
                    DestinationCountry = "Sweden"
                }
            };

            order.LineItems.Add(new Item("CSHARP_SMORGASBORD", "C# Smorgasbord", 100m, ItemType.Literature), 1);
            order.LineItems.Add(new Item("CONSULTING", "Building a website", 100m, ItemType.Service), 1);

            order.SalesTaxStrategy = new SwedenSalesTaxStrategy();
            Console.WriteLine(order.GetTax());
        }
    }
}
