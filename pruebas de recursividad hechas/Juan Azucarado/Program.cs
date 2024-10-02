namespace JuanAzucarado;

class Program
{
    static int amountCases = 0;

    static void TestChecker(long yourOutput, long expectedAnswer)
    {
        amountCases++;

        System.Console.WriteLine($"Case #{amountCases}");

        if (yourOutput == expectedAnswer)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Correct Answer!");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Wrong Answer :(");
            System.Console.WriteLine($"Expected Answer: {expectedAnswer}");
            System.Console.WriteLine($"Your Output: {yourOutput}");
        }
        Console.ForegroundColor = ConsoleColor.White;
        System.Console.WriteLine();
    }

    static void Main()
    {
        long n = 20;
        long[] buy_prices = new long[] { 4, 2, 1 };
        long[] buy_capacities = new long[] { 15, 6, 15 };
        long[] sell_prices = new long[] { 3, 3, 5 };
        long[] sell_capacities = new long[] { 10, 10, 11 };

        TestChecker(Solution.Solve(n, buy_prices, buy_capacities, sell_prices, sell_capacities), 44);

        n = 20;
        buy_prices = new long[] { 70, 80, 70 };
        buy_capacities = new long[] { 10, 20, 11 };
        sell_prices = new long[] { 5, 6, 5 };
        sell_capacities = new long[] { 20, 15, 5 };

        TestChecker(Solution.Solve(n, buy_prices, buy_capacities, sell_prices, sell_capacities), 0);

        n = 20;
        buy_prices = new long[] { 4, 1, 0 };
        buy_capacities = new long[] { 15, 6, 20 };
        sell_prices = new long[] { 3, 3, 5 };
        sell_capacities = new long[] { 10, 10, 11 };

        TestChecker(Solution.Solve(n, buy_prices, buy_capacities, sell_prices, sell_capacities), 60);

        n = 8608;
        buy_prices = new long[] { 56, 21, 56, 90, 44, 97, 28, 29, 47, 63, 47, 98, 4, 86, 99, 68, 32, 81, 84, 99, 4, 70 };
        buy_capacities = new long[] { 32, 56, 41, 33, 5, 12, 27, 18, 59, 38, 46, 2, 23, 21, 57, 30, 43, 8, 17, 54, 47, 20 };
        sell_prices = new long[] { 46, 15, 22, 41, 72, 62, 49, 20, 87, 82, 73, 85, 68, 62, 22, 89, 89, 9, 84, 17, 64, 82, 22, 99 };
        sell_capacities = new long[] { 68, 79, 83, 88, 46, 83, 83, 47, 94, 51, 68, 72, 59, 80, 68, 90, 88, 87, 85, 96, 57, 71, 79, 59 };

        TestChecker(Solution.Solve(n, buy_prices, buy_capacities, sell_prices, sell_capacities), 23691);
    }
}


