using System;
using System.Text;

namespace StockMarket
{
    public class Stock
    {
        private string companyName;
        private string director;
        private decimal pricePerShare;
        private int totalNumberOfShares;
        private decimal marketCapitalization;

        public string CompanyName { get => companyName; set => companyName = value; }
        public string Director { get => director; set => director = value; }
        public decimal PricePerShare { get => pricePerShare; set => pricePerShare = value; }
        public int TotalNumberOfShares { get => totalNumberOfShares; set => totalNumberOfShares = value; }
        public decimal MarketCapitalization { get => marketCapitalization; set => marketCapitalization = value; }

        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            CompanyName = companyName;
            Director = director;
            PricePerShare = pricePerShare;
            TotalNumberOfShares = totalNumberOfShares;
            MarketCapitalization = pricePerShare * totalNumberOfShares;
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"Company: {CompanyName}" + Environment.NewLine)
            .Append($"Director: {Director}" + Environment.NewLine)
            .Append($"Price per share: ${PricePerShare}" + Environment.NewLine)
            .Append($"Market capitalization: ${MarketCapitalization}");
            return sb.ToString().TrimEnd();
        }
    }
}
