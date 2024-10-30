class HanoiSolution
{
    static void Hanoi(int n, char from, char to, char aux)
    {
        if (n == 1)
        {
            Console.WriteLine("Move disk 1 from " + from + " to " + to);
            return;
        }
        Hanoi(n - 1, from, aux, to);
        Hanoi(1,from,to,aux); 
        Hanoi(n - 1, aux, to, from);
    }
}