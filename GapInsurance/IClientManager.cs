using GapInsurance.Models;
using System.Collections.Generic;

namespace GapInsurance
{
    public interface IClientManager
    {
        ClientsDto GetClient(int id);
        IList<ClientsDto> GetClients();
        ClientsDto SaveClient(ClientsDto client);
        bool DeleteClient(int id);
        CustomersDto SaveCustomer(CustomersDto customer);
        IList<CustomersDto> GetCustomers();
        CustomersDto GetCustomer(int id);
    }
}
