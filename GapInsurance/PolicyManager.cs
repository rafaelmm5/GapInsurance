using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using GapInsurance.Models;
using GapInsurance.Data;
using AutoMapper;

namespace GapInsurance
{
    public class PolicyManager : IPolicyManager
    {
        public bool DeletePolicy(int id)
        {
            using (var db = new GapInsuranceDBModel())
            {
                var policy = db.Policies
                            .Include(p => p.Coverages)
                            .FirstOrDefault(x => x.Id == id);
                int deleted = 0;

                if (policy != null)
                {
                    policy.Coverages.Clear();
                    db.Policies.Remove(policy);

                    deleted = db.SaveChanges();
                }

                return deleted > 0;
            }
        }

        public IList<PoliciesDto> GetPolicies()
        {
            using (var db = new GapInsuranceDBModel())
            {
                var policies = db.Policies.ToList();

                if (policies?.Any() == true)
                {
                    return policies.Select(x => Mapper.Map<Policies, PoliciesDto>(x)).ToList();
                }
            }

            return null;
        }

        public PoliciesDto GetPolicy(int id)
        {
            using (var db = new GapInsuranceDBModel())
            {
                var policy = db.Policies.FirstOrDefault(x => x.Id == id);

                if (policy != null)
                {
                    return Mapper.Map<Policies, PoliciesDto>(policy);
                }
            }

            return null;
        }

        public PoliciesDto SavePolicy(PoliciesDto policy)
        {
            using (var db = new GapInsuranceDBModel())
            {
                Policies dbPolicy = null;

                if (policy.Id > 0)
                {
                    dbPolicy = db.Policies.FirstOrDefault(o => o.Id == policy.Id);
                }

                if (dbPolicy == null)
                {
                    dbPolicy = new Policies();
                    db.Policies.Add(dbPolicy);
                }

                dbPolicy.Name = policy.Name;
                dbPolicy.Description = policy.Description;

                var dbCoverages = policy.Coverages.Select(od => Mapper.Map<CoveragesDto, Coverages>(od));
                var deletedCoverages = dbPolicy.Coverages.Where(c => !dbCoverages.Select(dbC => dbC.Id).Contains(c.Id)).ToList();
                var addedCoverages = dbCoverages.Where(x => !dbPolicy.Coverages.Select(n => n.Id).Contains(x.Id)).ToList();

                deletedCoverages.ForEach(d => dbPolicy.Coverages.Remove(d));

                addedCoverages.ForEach(nc =>
                {
                    dbPolicy.Coverages.Add(db.Coverages.FirstOrDefault(x => x.Id == nc.Id));
                });

                db.SaveChanges();

                return Mapper.Map<Policies, PoliciesDto>(dbPolicy);
            }
        }

        public Customer_PoliciesDto SaveCustomerPolicy(Customer_PoliciesDto custPolicy)
        {
            using (var db = new GapInsuranceDBModel())
            {
                Customer_Policies dbCustPolicy = null;

                if (custPolicy.CoverPercentage > 100)
                {
                    throw new InvalidOperationException("Cover percentage can't be higher than 100%");
                }

                if (!db.Customers.Any(x => x.Id == custPolicy.CustomerId))
                {
                    throw new KeyNotFoundException("Customer not found");
                }

                if (!db.Policies.Any(x => x.Id == custPolicy.PolicyId))
                {
                    throw new KeyNotFoundException("Policy not found");
                }

                if (custPolicy.RiskType == RiskType.High && custPolicy.CoverPercentage > 50)
                {
                    throw new InvalidOperationException("Cover percentage can't be higher than 50% when risk is high");
                }

                if (custPolicy.Id > 0)
                {
                    dbCustPolicy = db.Customer_Policies.FirstOrDefault(o => o.Id == custPolicy.Id);
                }

                if (dbCustPolicy == null)
                {
                    dbCustPolicy = new Customer_Policies();
                    db.Customer_Policies.Add(dbCustPolicy);
                }

                dbCustPolicy.PolicyId = db.Policies.FirstOrDefault(x => x.Id == custPolicy.PolicyId).Id;
                dbCustPolicy.StartDate = custPolicy.StartDate;
                dbCustPolicy.EndDate = custPolicy.EndDate;
                dbCustPolicy.Price = custPolicy.Price;
                dbCustPolicy.RiskType = custPolicy.RiskType.ToString();
                dbCustPolicy.CustomerId = db.Customers.FirstOrDefault(x=> x.Id==custPolicy.CustomerId).Id;
                dbCustPolicy.Active = custPolicy.Active;
                dbCustPolicy.CoverPercentage = custPolicy.CoverPercentage;

                db.SaveChanges();

                return Mapper.Map<Customer_Policies, Customer_PoliciesDto>(dbCustPolicy);
            }
        }
    }
}
