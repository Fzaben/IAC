using System.Collections.Generic;

namespace MyCompanyName.AbpZeroTemplate.MultiTenancy.HostDashboard.Dto
{
    public class GetIncomeStatisticsDataOutput
    {
        public GetIncomeStatisticsDataOutput(List<IncomeStastistic> incomeStatistics)
        {
            IncomeStatistics = incomeStatistics;
        }

        public List<IncomeStastistic> IncomeStatistics { get; set; }
    }
}