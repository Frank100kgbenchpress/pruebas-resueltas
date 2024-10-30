using LaNocheDeCelebracion;

public static class Program
{
    public static void Main(string[] args)
    {
        // Test #1
        bool [,] map = new bool[,] {
            {false, false, false, true},
            {true, false, false, false},
            {false, false, false, false},
            {false, false, false, false}};
        (int, int) home = (2, 2);
    
        Console.WriteLine((Solution.MinStepHome(map, home) == 2) ? "ok" : "wrong");

        // Test #2
        map = new bool[,] {
            {false, false, false, false},
            {false, false, false, false},
            {false, false, false, false},
            {false, false, false, false}};
        home = (1, 1);
        Console.WriteLine((Solution.MinStepHome(map, home) == 1) ? "ok" : "wrong");

        // Test #3  
        map = new bool[,] {
            {false, false, false},
            {false, true, false},
            {true, false, false}};
        home = (2, 1);

        Console.WriteLine((Solution.MinStepHome(map, home) == 2) ? "ok" : "wrong");
    
    }
}

