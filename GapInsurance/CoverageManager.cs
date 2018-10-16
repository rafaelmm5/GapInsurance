using System.Collections.Generic;
using System.Linq;
using GapInsurance.Models;
using GapInsurance.Data;
using AutoMapper;

namespace GapInsurance
{
    public class CoverageManager : ICoverageManager
    {
        public bool DeleteCoverage(int id)
        {
            using (var db = new GapInsuranceDBModel())
            {
                var c = db.Coverages.FirstOrDefault(x => x.Id == id);
                int deleted = 0;

                if (c != null)
                {
                    db.Coverages.Remove(c);

                    deleted = db.SaveChanges();
                }

                return deleted > 0;
            }
        }

        public CoveragesDto GetCoverage(int id)
        {
            using (var db = new GapInsuranceDBModel())
            {
                var client = db.Coverages.FirstOrDefault(x => x.Id == id);

                if (client != null)
                {
                    return Mapper.Map<Coverages, CoveragesDto>(client);
                }
            }

            return null;
        }

        public IList<CoveragesDto> GetCoverages()
        {
            using (var db = new GapInsuranceDBModel())
            {
                var c = db.Coverages.ToList();

                if (c?.Any() == true)
                {
                    return c.Select(x => Mapper.Map<Coverages, CoveragesDto>(x)).ToList();
                }
            }

            return null;
        }

        public CoveragesDto SaveCoverage(CoveragesDto coverage)
        {
            using (var db = new GapInsuranceDBModel())
            {
                Coverages dbCoverage;

                if (coverage.Id > 0)
                {
                    dbCoverage = db.Coverages.FirstOrDefault(x => x.Id == coverage.Id);

                    if (dbCoverage == null)
                    {
                        throw new KeyNotFoundException("Coverage doesn't exists");
                    }
                }
                else
                {
                    dbCoverage = new Coverages();
                    db.Coverages.Add(dbCoverage);
                }

                dbCoverage.Name = coverage.Name;

                db.SaveChanges();

                return Mapper.Map<Coverages, CoveragesDto>(dbCoverage);
            }
        }
    }
}
