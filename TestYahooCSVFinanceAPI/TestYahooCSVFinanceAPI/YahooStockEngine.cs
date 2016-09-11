using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestYahooCSVFinanceAPI.Models;

namespace TestYahooCSVFinanceAPI
{
    class YahooStockEngine
    {
        // The YQL is below.
        // q=select * from yahoo.finance.quotes where symbol in ({0})
        // env = store://datatables.org/alltablewithkeys
        //private const string SERVICE_URL = "http://finance.yahoo.com/d/quotes.csv?s={0}&f=snbaopl1";
        private const string SERVICE_URL = "http://download.finance.yahoo.com/d/quotes.csv?s={0}&f=snbaopl1";

        public static bool FetchData(ObservableCollection<Quote> quotes)
        {
            string csv;
            string symbolList = String.Join("+", quotes.Select(w => w.Symbol).ToArray());
            try
            {
                string url = string.Format(SERVICE_URL, symbolList);
                using (WebClient client = new WebClient()) {
                    csv = client.DownloadString(url);
                    ParseData(quotes, csv);
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
                return false;
            }


        }

        private static void ParseData(ObservableCollection<Quote> quotes, string csv)
        {

            string[] rows = csv.Replace("\r", "").Split('\n');
            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row)) continue;
                string[] cols = row.Split(',');
                foreach (Quote quote in quotes)
                {
                    // search for symbol
                    if (quote.Symbol.Equals(cols[0])) {
                        quote.Name = cols[1];
                        quote.Bid = Convert.ToDecimal(cols[2]);
                        quote.Ask = Convert.ToDecimal(cols[3]);
                        quote.Open = Convert.ToDecimal(cols[4]);
                        quote.PreviousClose = Convert.ToDecimal(cols[5]);
                        quote.LastTradePrice = Convert.ToDecimal(cols[6]);
                        /*
                        quote.Ask = GetDecimal(q.Element("Ask").Value);
                        quote.Bid = GetDecimal(q.Element("Bid").Value);
                        quote.AverageDailyVolume = GetDecimal(q.Element("AverageDailyVolume").Value);
                        quote.BookValue = GetDecimal(q.Element("BookValue").Value);
                        quote.Change = GetDecimal(q.Element("Change").Value);
                        quote.DividendShare = GetDecimal(q.Element("DividendShare").Value);
                        quote.LastTradeDate = GetDateTime(q.Element("LastTradeDate").Value + " " + q.Element("LastTradeTime").Value);
                        quote.EarningsShare = GetDecimal(q.Element("EarningsShare").Value);
                        quote.EpsEstimateCurrentYear = GetDecimal(q.Element("EPSEstimateCurrentYear").Value);
                        quote.EpsEstimateNextYear = GetDecimal(q.Element("EPSEstimateNextYear").Value);
                        quote.EpsEstimateNextQuarter = GetDecimal(q.Element("EPSEstimateNextQuarter").Value);
                        quote.DailyLow = GetDecimal(q.Element("DaysLow").Value);
                        quote.DailyHigh = GetDecimal(q.Element("DaysHigh").Value);
                        quote.YearlyLow = GetDecimal(q.Element("YearLow").Value);
                        quote.YearlyHigh = GetDecimal(q.Element("YearHigh").Value);
                        quote.MarketCapitalization = GetDecimal(q.Element("MarketCapitalization").Value);
                        quote.Ebitda = GetDecimal(q.Element("EBITDA").Value);
                        quote.ChangeFromYearLow = GetDecimal(q.Element("ChangeFromYearLow").Value);
                        quote.PercentChangeFromYearLow = GetDecimal(q.Element("PercentChangeFromYearLow").Value);
                        quote.ChangeFromYearHigh = GetDecimal(q.Element("ChangeFromYearHigh").Value);
                        quote.LastTradePrice = GetDecimal(q.Element("LastTradePriceOnly").Value);
                        quote.PercentChangeFromYearHigh = GetDecimal(q.Element("PercebtChangeFromYearHigh").Value); //missspelling in yahoo for field name
                        quote.FiftyDayMovingAverage = GetDecimal(q.Element("FiftydayMovingAverage").Value);
                        quote.TwoHunderedDayMovingAverage = GetDecimal(q.Element("TwoHundreddayMovingAverage").Value);
                        quote.ChangeFromTwoHundredDayMovingAverage = GetDecimal(q.Element("ChangeFromTwoHundreddayMovingAverage").Value);
                        quote.PercentChangeFromTwoHundredDayMovingAverage = GetDecimal(q.Element("PercentChangeFromTwoHundreddayMovingAverage").Value);
                        quote.PercentChangeFromFiftyDayMovingAverage = GetDecimal(q.Element("PercentChangeFromFiftydayMovingAverage").Value);
                        quote.Name = q.Element("Name").Value;
                        quote.Open = GetDecimal(q.Element("Open").Value);
                        quote.PreviousClose = GetDecimal(q.Element("PreviousClose").Value);
                        quote.ChangeInPercent = GetDecimal(q.Element("ChangeinPercent").Value);
                        quote.PriceSales = GetDecimal(q.Element("PriceSales").Value);
                        quote.PriceBook = GetDecimal(q.Element("PriceBook").Value);
                        quote.ExDividendDate = GetDateTime(q.Element("ExDividendDate").Value);
                        quote.PeRatio = GetDecimal(q.Element("PERatio").Value);
                        quote.DividendPayDate = GetDateTime(q.Element("DividendPayDate").Value);
                        quote.PegRatio = GetDecimal(q.Element("PEGRatio").Value);
                        quote.PriceEpsEstimateCurrentYear = GetDecimal(q.Element("PriceEPSEstimateCurrentYear").Value);
                        quote.PriceEpsEstimateNextYear = GetDecimal(q.Element("PriceEPSEstimateNextYear").Value);
                        quote.ShortRatio = GetDecimal(q.Element("ShortRatio").Value);
                        quote.OneYearPriceTarget = GetDecimal(q.Element("OneyrTargetPrice").Value);
                        quote.Volume = GetDecimal(q.Element("Volume").Value);
                        quote.StockExchange = q.Element("StockExchange").Value;
                        */
                        quote.LastUpdate = DateTime.Now;
                    }

                }
            }
        }


        private static decimal? GetDecimal(string input)
        {
            if (input == null) return null;

            input = input.Replace("%", "");

            decimal value;

            if (Decimal.TryParse(input, out value)) return value;
            return null;
        }

        private static DateTime? GetDateTime(string input)
        {
            if (input == null) return null;

            DateTime value;

            if (DateTime.TryParse(input, out value)) return value;
            return null;
        }
    }
}
