bool[,] Amigos =
{
    { false, true,  true,  false, false, false, false, false, false, },
    { true,  false, false, true,  false, true,  false, true,  false, },
    { true,  false, false, false, true,  false, true,  false, true, },
    { false, true,  false, false, false, false, false, false, false, },
    { false, false, true,  false, false, false, false, false, false, },
    { false, true,  false, false, false, false, false, false, false, },
    { false, false, true,  false, false, false, false, false, false, },
    { false, true,  false, false, false, false, false, false, false, },
    { false, false, true,  false, false, false, false, false, false, },
};
        /*bool[,] Amigos =
        {//     0      1      2      3      4      5      6      7      8
            { false, true, false, false, false, true, false, false, false, }, // 0
            { true, false, true, true, true, true, false, false, false, }, // 1
            { false, true, false, true, false, false, false, false, false, }, // 2
            { false, true, true, false, false, false, false, false, false, }, // 3
            { false, true, false, false, false, false, false, false, false, }, // 4
            { true, true, false, false, false, false, true, false, false, }, // 5 
            { false, false, false, false, false, true, false, true, true, }, // 6
            { false, false, false, false, false, false, true, false, false, }, // 7
            { false, false, false, false, false, false, true, false, false, }, // 8
        };*/

        /*bool[,] Amigos = new bool[8, 8];

        Amigos[0, 1] = true;
        Amigos[0, 7] = true;
        Amigos[1, 2] = true;
        Amigos[2, 3] = true;
        Amigos[3, 4] = true;
        Amigos[4, 5] = true;
        Amigos[5, 6] = true;
        Amigos[6, 7] = true;*/


        /*for (int i = 0; i < 8; i++)
            for (int j = 0; j < 8; j++)
                if (Amigos[i, j])Amigos[j, i] = true;

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(Examen.MinEstudiantesAvisar(Amigos, i));
            Console.WriteLine();
        }*/
int[] Expected = { 9, 2, 1, 1, 1, 1, 1, 1, 1, 1 };

for(int k = 0; k < 10; k++)
{
    var result = Examen.MinEstudiantesAvisar(Amigos, k);
    if (result != Expected[k]) Console.WriteLine($"Test #{k + 1}: Se esperaba {Expected[k]}, se obtuvo {result}");
    else Console.WriteLine($"Test #{k + 1}: S={result}. Correcto!");
}
