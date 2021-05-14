using System;

namespace MyCompanyName.AbpZeroTemplate.MultiTenancy.HostDashboard.Dto
{
    public class IncomeStastistic
    {
        public IncomeStastistic()
        {
        }

        public IncomeStastistic(DateTime date)
        {
            Date = date;
        }

        public IncomeStastistic(DateTime date, decimal amount)
        {
            Date = date;
            Amount = amount;
        }

        public string Label { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}