using System.Collections.Generic;

namespace Tests.BroadbandDeals.Core.Entites
{
    public class Deal
    {
        public string Title { get; set; }
        public List<Price> Prices { get; set; }
        public int Id { get; set; }
        public int ContractLength { get; set; }
        public string TvProduct { get; set; }
        public StandardChannels StandardChannels { get; set; }
        public TotalChannels TotalChannels { get; set; }
        public HdChannels HdChannels { get; set; }
        public Speed Speed { get; set; }
        public UploadSpeed UploadSpeed { get; set; }
        public Usage Usage { get; set; }
        public Mobile Mobile { get; set; }
        public Offer Offer { get; set; }
        public Provider Provider { get; set; }
        public int NewLineCost { get; set; }
        public List<UpfrontCost> UpfrontCosts { get; set; }
        public List<string> ProductTypes { get; set; }
        public PremiumFeatures PremiumFeatures { get; set; }
        public List<object> PopularChannels { get; set; }
        public string TelephoneNumber { get; set; }
        public Extras Extras { get; set; }
        public string BroadbandType { get; set; }
    }
}