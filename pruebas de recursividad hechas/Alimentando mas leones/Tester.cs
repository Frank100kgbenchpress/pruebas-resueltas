namespace Leones
{
    public class Tester
    {
        public static void Main()
        {
            int[,] matrix = new int[,]{
                            {0, 1, 1, 3},
                            {1, 0, 3, 1},
                            {1, 3, 0, 1},
                            {3, 1, 1, 0}
                                        };

            int[] demand = new int[]{0, 2, 9, 2};
            int[] capacities = new int[]{10, 4};
            Map map = new Map(matrix, demand);
            //Esto debe tener costo 7
            Console.WriteLine(Solution.Solve(map, capacities));
            Console.WriteLine("Se esperaba 7");

        }
    }
}
