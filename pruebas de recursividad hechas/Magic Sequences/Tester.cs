using MagicSequences;


        // Evaluar correctitud
    
    Assert(new int[] { 1,2,3,4,6,7 }, 0);

    Assert(new int[] { 1, 2, 4, 5, 2, 6, 10, 25, 35, 6, 1, 2, 3, 4, 5, 6, 12, 1, 3, 4, }, 3);


    Assert(new int[] { 3, 3, 4, 5, 2, 6, 1 }, 0);

    Assert(new int[] { 5, 6, 3, 2, }, 4);

    Assert(new int[] { 3, 4, 1, 6, 7, 7 }, 1);

    Assert(new int[] { 1, 2, 3, 1, 2 }, 1);

    // Evaluar eficiencia
    foreach 
    (
        (int tam, int semilla, int esperado) in new (int, int, int)[]
        {
            (15, 0, 2),
            (25, 0, 2),
            (50, 0, 4),
            (100, 0, 2),
            (400, 0, 8),
        }
    )
    {
        int[] seq = GenerarSecuenciaAleatoria(tam, semilla);
        Assert(seq, esperado);
    }

    void Assert(int[] secuencia, int esperado)
    {
        var cts = new CancellationTokenSource();
        Task task = Task.Run(
            () =>
            {
                int res = Solution.CantidadMinimaEliminaciones(secuencia);
                PrettyPrint(
                    $"Resultado obtenido: {res}, esperado: {esperado}",
                    res == esperado ? ConsoleColor.Green : ConsoleColor.Red
                );
            },
            cts.Token
        );

        if (!(task.Wait(int.MaxValue)))
        {
            cts.Cancel();
            PrettyPrint("Tiempo límite excedido", ConsoleColor.Yellow);
        }
    }

    int[] GenerarSecuenciaAleatoria(int length, int seed)
    {
        Random r = new Random(seed);

        int[] sequence = new int[length];
        for (int i = 0; i < sequence.Length; i++)
        {
            sequence[i] = r.Next(1, sequence.Length);
        }
        return sequence;
    }

    static void PrettyPrint(string s, ConsoleColor color)
    {
        var normalColor = Console.ForegroundColor;
        Console.ForegroundColor = color;
        Console.WriteLine(s);
        Console.ForegroundColor = normalColor;
    }

