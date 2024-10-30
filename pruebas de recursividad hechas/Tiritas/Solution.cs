namespace Tiritas
{
    public class Tira
    {
        public int StartRow { get; set; }
        public int StartCol { get; set; }
        public int EndRow { get; set; }
        public int EndCol { get; set; }

        public Tira(int startRow, int startCol, int endRow, int endCol) => (StartRow,StartCol,EndRow,EndCol) = (startRow,startCol,endRow,endCol);
    }

    public class Solution
    {
        public static int Resolver(bool[,] patron)
        {
            int filas = patron.GetLength(0);
            int columnas = patron.GetLength(1);
            List<Tira> tiras = CrearTiras(patron, filas, columnas);

            int min = int.MaxValue;
            bool[] used = new bool[tiras.Count];
            min = Backtrack(0);
            return min;

            int Backtrack(int counter)
            {
                bool[,] mask = new bool[filas, columnas];
                for (int i = 0; i < tiras.Count; i++)
                {
                    if (used[i])
                    {
                        var tira = tiras[i];
                        for (int j = tira.StartRow; j <= tira.EndRow; j++)
                        {
                            for (int k = tira.StartCol; k <= tira.EndCol; k++)
                            {
                                mask[j, k] = true;
                            }
                        }
                    }
                }

                bool todoCubierto = true;
                for (int i = 0; i < filas; i++)
                {
                    for (int j = 0; j < columnas; j++)
                    {
                        if (patron[i, j] && !mask[i, j])
                        {
                            todoCubierto = false;
                            break;
                        }
                    }
                    if (!todoCubierto) break;
                }

                if (todoCubierto) return counter;

                int min = int.MaxValue;
                for (int i = 0; i < tiras.Count; i++)
                {
                    if (!used[i])
                    {
                        used[i] = true;
                        min = Math.Min(min, Backtrack(counter + 1));
                        used[i] = false;
                    }
                }
                return min;
            }
        }

        static List<Tira> CrearTiras(bool[,] patron, int filas, int columnas)
        {
            List<Tira> tiras = new List<Tira>();

            for (int i = 0; i < filas; i++)
            {
                int start = -1;
                for (int j = 0; j < columnas; j++)
                {
                    if (patron[i, j])
                    {
                        if (start == -1) start = j;
                    }
                    else
                    {
                        if (start != -1)
                        {
                            tiras.Add(new Tira(i, start, i, j - 1));
                            start = -1;
                        }
                    }
                }
                if (start != -1)
                {
                    tiras.Add(new Tira(i, start, i, columnas - 1));
                }
            }

            for (int j = 0; j < columnas; j++)
            {
                int start = -1;
                for (int i = 0; i < filas; i++)
                {
                    if (patron[i, j])
                    {
                        if (start == -1) start = i;
                    }
                    else
                    {
                        if (start != -1)
                        {
                            tiras.Add(new Tira(start, j, i - 1, j));
                            start = -1;
                        }
                    }
                }
                if (start != -1)
                {
                    tiras.Add(new Tira(start, j, filas - 1, j));
                }
            }

            return tiras;
        }
    }

}
