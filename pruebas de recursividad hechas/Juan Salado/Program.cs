namespace JuanSalado;

class Program
{
    static int amountCases = 0;

    static void TestChecker(long yourOutput, long expectedAnswer)
    {
        amountCases++;

        System.Console.WriteLine($"Case #{amountCases}");

        if (yourOutput == expectedAnswer) {
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("Correct Answer!");
        }
        else {
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
        long[] buy_prices = new long[]{4, 2, 1};
        long[] buy_capacities = new long[]{15, 6, 15};
        long[] sell_prices = new long[]{3, 3, 5, 50};
        long[] sell_capacities = new long[]{10, 10, 11, 21};

        TestChecker(Solution.Solve(n, buy_prices, buy_capacities, sell_prices, sell_capacities), 35);

        n = 20;
        buy_prices = new long[]{40, 20, 10};
        buy_capacities = new long[]{15, 6, 15};
        sell_prices = new long[]{3, 3, 5, 50};
        sell_capacities = new long[]{10, 10, 11, 21};

        TestChecker(Solution.Solve(n, buy_prices, buy_capacities, sell_prices, sell_capacities), -190);

        n = 20;
        buy_prices = new long[]{4, 2, 1};
        buy_capacities = new long[]{15, 6, 15};
        sell_prices = new long[]{3, 3, 5, 50};
        sell_capacities = new long[]{2, 2, 11, 21};

        TestChecker(Solution.Solve(n, buy_prices, buy_capacities, sell_prices, sell_capacities), 52);

        n = 20;
        buy_prices = new long[]{4, 1, 1};
        buy_capacities = new long[]{11, 6, 20};
        sell_prices = new long[]{3, 3, 5, 4};
        sell_capacities = new long[]{10, 10, 15, 13};

        TestChecker(Solution.Solve(n, buy_prices, buy_capacities, sell_prices, sell_capacities), 55);
    }    
}
