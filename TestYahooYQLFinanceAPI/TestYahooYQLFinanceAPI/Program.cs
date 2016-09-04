using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestYahooYQLFinanceAPI.Models;

namespace TestYahooYQLFinanceAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<Quote> quotes = new ObservableCollection<Quote> (){
                new Quote("AAPL"),
                new Quote("GOOG"),
            };

            YahooStockEngine.FetchData(quotes);

            foreach (Quote quote in quotes) {
                Console.WriteLine("Quote Data for {0}:", quote.Symbol);
                Console.WriteLine("Book Value:{0}", quote.BookValue);
                Console.WriteLine("Change(%):{0}{1}", quote.Change, quote.ChangePercent);
            }
        }
    }
}
