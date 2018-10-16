using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GapInsurance.Manager;
using GapInsurance.Models;
using AutoMapper;
using GapInsurance.Data;
using GapInsurance;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            AutoMapperConfiguration.Configure();
            var p = new Program();

            p.createCustomerPolicy();


            Console.ReadKey();
          
        }

        public void createPolicy()
        {
            var pman = new PolicyManager();
            var p = new PoliciesDto();

            p.Name = "Natural Disasters";
            p.Description = "Policy againts natural disasters";
            p.Coverages.Add(new CoveragesDto() { Id = 9 });
            p.Coverages.Add(new CoveragesDto() { Id = 10 });

            pman.SavePolicy(p);
        }

        public void createCustomerPolicy()
        {
            var pman = new PolicyManager();

            var custPolicy = new Customer_PoliciesDto();
            custPolicy.Id = 100000;
            custPolicy.PolicyId = 1004;
            custPolicy.StartDate = DateTime.Now;
            custPolicy.EndDate = DateTime.Now.AddYears(1);
            custPolicy.Price = 1000;
            custPolicy.RiskType = RiskType.Medium;
            custPolicy.CustomerId = 1000;
            custPolicy.CoverPercentage = 98;
            custPolicy.Active = false;

            pman.SaveCustomerPolicy(custPolicy);

           // custPolicy.
        }

        public void createCustomer()
        {
            var cman = new ClientManager();

            var customer = new CustomersDto();
            customer.FirstName = "Rafael";
            customer.LastName = "Mercado";
            customer.ClientId = 1001;

            cman.SaveCustomer(customer);
        }

        public class AutoMapperConfiguration
        {
            public static void Configure()
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Clients, ClientsDto>();
                });
            }
        }
    }
}
