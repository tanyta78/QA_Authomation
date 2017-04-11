using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAcount acc = new BankAcount(3333m);
            Console.WriteLine(acc.Amount);
        }
    }
}
