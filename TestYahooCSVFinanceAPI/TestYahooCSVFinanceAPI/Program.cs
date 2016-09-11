using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestYahooCSVFinanceAPI.Models;

namespace TestYahooCSVFinanceAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<Quote> quotes = new ObservableCollection<Quote>(){
                new Quote("AAPL"),
                new Quote("GOOG"),
            };

            YahooStockEngine.FetchData(quotes);

            foreach (Quote quote in quotes)
            {
                Console.WriteLine("Quote Data for {0}{1}:", quote.Name, quote.Symbol);
                Console.WriteLine("Last Trade Price is {0} at Exchange {1}:", quote.LastTradePrice, quote.StockExchange);
                Console.WriteLine("Trade Volumn is {0}.", quote.Volume);
                Console.WriteLine("Change(%):{0}({1}%)", quote.Change, quote.ChangeInPercent);
                Console.WriteLine();
            }
        }
    }
}
