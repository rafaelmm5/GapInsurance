using GapInsurance.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GapInsurance
{
    public interface IPolicyManager
    {
        PoliciesDto SavePolicy(PoliciesDto policy);
        PoliciesDto GetPolicy(int id);
        IList<PoliciesDto> GetPolicies();
        bool DeletePolicy(int id);
        IList<Customer_PoliciesDto> GetCustomerPolices();
        Customer_PoliciesDto GetCustomerPolicy(int id);
        Customer_PoliciesDto SaveCustomerPolicy(Customer_PoliciesDto policy);
    }
}
