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
    }
}
