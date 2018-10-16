using GapInsurance.Models;
using System.Collections.Generic;

namespace GapInsurance
{
    public interface ICoverageManager
    {
        CoveragesDto GetCoverage(int id);
        IList<CoveragesDto> GetCoverages();
        CoveragesDto SaveCoverage(CoveragesDto client);
        bool DeleteCoverage(int id);
    }
}
