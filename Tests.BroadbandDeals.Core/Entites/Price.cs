using System.Collections.Generic;

namespace Tests.BroadbandDeals.Core.Entites
{
    public class Price
    {
        public List<Period> Periods { get; set; }
        public double FirstYear { get; set; }
        public double TotalContractCost { get; set; }
        public double UpFrontCost { get; set; }
        public object Upsell { get; set; }
        public List<object> SelectedOptions { get; set; }
    }
}
