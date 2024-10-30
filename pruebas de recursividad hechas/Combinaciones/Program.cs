using System.Diagnostics;
using System.Diagnostics.Metrics;

static int CountSequences(int N, int[] factors)
{
    int counter = 0;
    for (int i = 1; i <= N; i++)
    {
        for (int j = i + 1; j <= N; j++)
        {
            for (int k = j + 1; k <= N; k++)
            {
                int solution = factors[i] + factors(2*j) + (3*k);
                if (solution <= N)
                {
                    counter ++;
                }
            }
        }
    }
    return counter;
}



 int result = CountSequences(11, new int[] {1, 2, 3});
 Debug.Assert(result == 4);

