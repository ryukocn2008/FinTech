using NBitcoin;
using ProgrammingBlockchain.Chapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingBlockchain
{
    class Program
    {
        static void Main(string[] args)
        {
            var chapter = new Chapter1();
            chapter.Lesson4();

            BitcoinSecret paymentSecret = chapter.paymentSecret;

            Console.WriteLine("\n\n\nPress enter to continue.");
            Console.ReadLine();

        }
    }
}
