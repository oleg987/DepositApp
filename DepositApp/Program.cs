using System;

namespace DepositApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Поместить все потенциально опасные операции в try...catch

            Client client = new Client("John Doe", new DateTime(1990, 01, 15), Sex.Male);

            client.AddDeposit(1000, DepositType.Capital);

            var expectedBallance = client.GetBallance(24);

            for (int i = 0; i < expectedBallance.Length; i++)
            {
                Console.WriteLine($"{i + 1} -> {expectedBallance[i]}");
            }
        }
    }
}
