using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepositApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client("John Doe", new DateTime(1990, 01, 15), Dictionary.Sex.Male, new Deposit(2000, Dictionary.DepositType.Premium));

            double[] profit = new double[36];
            profit = client.GetBallance(36);

            foreach (double item in profit)
            {
                Console.WriteLine(item-2000);
            }
        }
    }
}
