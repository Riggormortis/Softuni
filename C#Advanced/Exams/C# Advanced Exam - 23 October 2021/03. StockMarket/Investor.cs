using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;
        private string fullName;
        private string emailAddress;
        private decimal moneyToInvest;
        private string brokerName;

        public List<Stock> Portfolio { get => portfolio; set => portfolio = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public string EmailAddress { get => emailAddress; set => emailAddress = value; }
        public decimal MoneyToInvest { get => moneyToInvest; set => moneyToInvest = value; }
        public string BrokerName { get => brokerName; set => brokerName = value; }

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }
        public int Count
        {
            get => this.portfolio.Count;
        }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && this.moneyToInvest >= stock.PricePerShare)
            {
                this.portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            foreach (var item in Portfolio)
            {
                if (item.CompanyName == companyName)
                {
                    if (sellPrice >= item.PricePerShare)
                    {
                        portfolio.Remove(item);
                        this.moneyToInvest += item.PricePerShare;
                        return $"{companyName} was sold.";
                    }
                    else
                    {
                        return $"Cannot sell {companyName}.";
                    }

                }
            }
            return $"{companyName} does not exist.";
        }
        public Stock FindStock(string companyName)
        {
            foreach (var item in portfolio)
            {
                if (item.CompanyName == companyName)
                {
                    return item;
                }
            }
            return null;
        }
        public Stock FindBiggestCompany()
        {
            if (portfolio.Count == 0) return null;
            return portfolio.OrderBy(x => x.MarketCapitalization).Last();

            //вариант 2:
            /*Stock maxStock = null;
            decimal maxValue = 0; //най-големия market capitalization
            foreach(Stock stock in this.portfolio)
            {
                if (stock.MarketCapitalization > maxValue)
                {
                    maxValue = stock.MarketCapitalization;
                    maxStock = stock;
                }
            }
 
            return maxStock;*/

        }
        public string InvestorInformation()
        {
            var sb = new StringBuilder();
            sb.Append($"The investor {fullName} with a broker {brokerName} has stocks:");
            foreach (var item in portfolio)
            {
                sb.Append(Environment.NewLine).Append(item);
            }
            return sb.ToString();
        }
    }
}