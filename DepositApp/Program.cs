using System;

namespace DepositApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Поместить все потенциально опасные операции в try...catch
            
            Client client = new Client("John Doe", new DateTime(1990, 01, 15), Sex.Male);

            Deposit deposit = new Deposit(1000, DepositType.Premium, client);

            var expected = deposit.ExpectedBallance(24);

            for (int i = 0; i < expected.Length; i++)
            {
                Console.WriteLine($"{i + 1} -> {expected[i]} $");
            }
        }
    }
}
