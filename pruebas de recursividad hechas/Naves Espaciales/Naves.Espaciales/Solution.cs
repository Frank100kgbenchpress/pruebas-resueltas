using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatCom.Examen;

public class Juego
{
    //chequea posiciones invalidas
    public static bool Check(bool[,] battleField, int i, int j) =>i >= 0 && j >= 0 && i < battleField.GetLength(0) && j < battleField.GetLength(1);
    public static int MaximoRescate(bool[,] battleField)
    {
        int max = 0;                                    // variable a devolver
        for (int i = 0; i < battleField.GetLength(0); i++)
            for (int j = 0; j < battleField.GetLength(1); j++)
                if (battleField[i, j])
                { battleField[i, j] = false; MaxRescue(battleField, i, j, ref max); battleField[i, j] = true; } // ir desde cada posicion probando

        return max;
    }
    public static void MaxRescue(bool[,] battleField, int i, int j, ref int max, int counter = 0, int index = 0, bool first = true, bool last = false, bool displace = false)
    {
        if ((counter > max) && !last)
            max = counter;

        int[] di = { 1, 0, -1, 0  };
        int[] dj = { 0, 1,  0, -1 };
        for (int x = index; x < (4 + index); x++)
        {
            int next_i = i + di[x % 4];
            int next_j = j + dj[x % 4];

            if (Check(battleField, next_i, next_j)) 
            {
                if (x == index || (!last && displace) || first)
                {
                    if (battleField[next_i, next_j])
                    {
                        if (!last)
                        {
                            battleField[next_i, next_j] = false;
                            MaxRescue(battleField, next_i, next_j, ref max, counter + 1, x % 4, false, true, true);
                            battleField[next_i, next_j] = true;
                        }
                        else break;
                    }
                    else if (x == index || first)
                        MaxRescue(battleField, next_i, next_j, ref max, counter, x % 4, false, false, displace);

                    else if(displace)
                        MaxRescue(battleField, next_i, next_j, ref max, counter, x % 4, false, false, false);
                }
                else break;
            }
        }
    }
    