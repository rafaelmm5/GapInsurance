using System.Collections.Generic;
using System.Linq;
using GapInsurance.Models;
using GapInsurance.Data;
using AutoMapper;

namespace GapInsurance.Manager
{
    public class ClientManager : IClientManager
    {
        public ClientsDto GetClient(int id)
        {
            using (var db = new GapInsuranceDBModel())
            {
                var client = db.Clients.FirstOrDefault(x => x.Id == id);

                if (client != null)
                {
                    return Mapper.Map<Clients, ClientsDto>(client);
                }
            }

            return null;
        }

        public IList<ClientsDto> GetClients()
        {
            using (var db = new GapInsuranceDBModel())
            {
                var clients = db.Clients.ToList();

                if (clients?.Any() == true)
                {
                    return clients.Select(x=> Mapper.Map<Clients, ClientsDto>(x)).ToList();
                }
            }

            return null;
        }

        public ClientsDto SaveClient(ClientsDto client)
        {
            using (var db = new GapInsuranceDBModel())
            {
                Clients dbClient;

                if (client.Id > 0)
                {
                    dbClient = db.Clients.FirstOrDefault(x => x.Id == client.Id);

                    if (dbClient == null)
                    {
                        throw new KeyNotFoundException("Client doesn't exists");
                    }
                }
                else
                {
                    dbClient = new Clients();
                    db.Clients.Add(dbClient);
                }

                dbClient.Name = client.Name;

                db.SaveChanges();

                return Mapper.Map<Clients, ClientsDto>(dbClient);
            }
        }

        public bool DeleteClient(int id)
        {
            using (var db = new GapInsuranceDBModel())
            {
                var client = db.Clients.FirstOrDefault(x => x.Id == id);
                int deleted = 0;

                if (client != null)
                {
                    db.Clients.Remove(client);

                    deleted = db.SaveChanges();
                }

                return deleted > 0;
            }
        }

        public CustomersDto SaveCustomer(CustomersDto customer)
        {
            using (var db = new GapInsuranceDBModel())
            {
                if (!db.Clients.Any(x => x.Id == customer.ClientId))
                {
                    throw new KeyNotFoundException("Client not found");
                }

                Customers dbCustomer = null;

                if (customer.Id > 0)
                {
                    dbCustomer = db.Customers.FirstOrDefault(x => x.Id == customer.Id);
                }
                
                if (dbCustomer == null)
                {
                    dbCustomer = new Customers();
                    db.Customers.Add(dbCustomer);
                }

                dbCustomer.FirstName= customer.FirstName;
                dbCustomer.LastName= customer.LastName;
                dbCustomer.ClientId = db.Clients.FirstOrDefault(x => x.Id == customer.ClientId).Id;


                db.SaveChanges();

                return Mapper.Map<Customers, CustomersDto>(dbCustomer);
            }
        }
    }
}
