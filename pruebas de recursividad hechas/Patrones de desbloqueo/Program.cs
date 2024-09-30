public class Patrones
{
    public static int CantidadValidos(int k, int filas, int columnas)=>   CantidadValidos(k, filas, columnas, 0, new int[(k+1)*2]); 
    public static int CantidadValidos(int k, int filas, int columnas, int pos, int[] combinaciones)
        {
            int cantidad = 0;
            if (k == 0) return 0;
           if(pos== combinaciones.Length)
            {
                if (EsValida(combinaciones,filas,columnas))
                {
                    bool[,] mascara = new bool[filas, columnas];
                    if (Aristas(combinaciones, mascara, k))
                    {
                        return 1;
                    }
                }
                return 0;
            }
           for(int i=0; i< Math.Max(filas, columnas); i++)
            {
                combinaciones[pos] = i;
                cantidad += CantidadValidos(k, filas, columnas, pos + 1, combinaciones);
            }
            return cantidad;
        }
        public static bool EsValida(int[] combinaciones, int filas, int columnas)
        {
            if (combinaciones[0] == combinaciones[combinaciones.Length / 2 - 1] && combinaciones[combinaciones.Length / 2] == combinaciones[combinaciones.Length - 1]) return false;
            if (filas < columnas)
            {
                for (int i = 0, j = combinaciones.Length / 2; i < combinaciones.Length / 2 && j < combinaciones.Length; i++, j++)
                {
                    if (i + 1 < combinaciones.Length / 2 && j + 1 < combinaciones.Length)
                    {
                        if (combinaciones[i] >= filas) return false;
                        if (combinaciones[i + 1] >= filas) return false;
                        if (combinaciones[i] == combinaciones[i + 1] && combinaciones[j] == combinaciones[j + 1]) return false;
                    }

                }
            }
            else if(columnas< filas)
            {
                for (int i = 0, j = combinaciones.Length / 2; i < combinaciones.Length / 2 && j < combinaciones.Length; i++, j++)
                {
                    if (i + 1 < combinaciones.Length / 2 && j + 1 < combinaciones.Length)
                    {
                        if (combinaciones[j] >= columnas) return false;
                        if (combinaciones[j + 1] >= columnas) return false;
                        if (combinaciones[i] == combinaciones[i + 1] && combinaciones[j] == combinaciones[j + 1]) return false;
                    }

                }
            }
            else
            {
                for (int i = 0, j = combinaciones.Length / 2; i < combinaciones.Length / 2 && j < combinaciones.Length; i++, j++)
                {
                    if (i + 1 < combinaciones.Length / 2 && j + 1 < combinaciones.Length)
                    {
                        if (combinaciones[i] == combinaciones[i + 1] && combinaciones[j] == combinaciones[j + 1]) return false;
                    }

                }
            }
            return true;
        }
        public static bool Aristas(int [] combinaciones,bool [,] Mascara, int k )
        {
            int cantidad=0;
            for(int i=0, j=combinaciones.Length/2;i< combinaciones.Length/2 && j< combinaciones.Length; i++, j++)
            {
                
                if(i+ 1< combinaciones.Length/2 && j+1< combinaciones.Length)
                {
                        Mascara[combinaciones[i], combinaciones[j]] = true;   
                    if (Math.Abs(combinaciones[i]- combinaciones[i+1])== Math.Abs(combinaciones[j]- combinaciones[j + 1]))
                    {
                        if(combinaciones[i]< combinaciones[i+1])
                        {
                            if(combinaciones[j]< combinaciones[j + 1])
                            {
                             for(int s= combinaciones[i], h= combinaciones[j]; s< combinaciones[i+1] && h< combinaciones[j+1]; s++, h++)
                                {
                                    if (!Mascara[s, h]) return false;
                                }
                            }
                            else
                            {
                             for(int s= combinaciones[i], h= combinaciones[j]; s< combinaciones[i+1] && h> combinaciones[j + 1]; s++, h--)
                                {
                                    if (!Mascara[s, h]) return false;
                                }
                            }

                        }
                        else
                        {
                            if(combinaciones[j]< combinaciones[j+1])
                            {
                                for (int s = combinaciones[i], h = combinaciones[j]; s > combinaciones[i + 1] && h < combinaciones[j + 1]; s--, h++)
                                {
                                    if (!Mascara[s, h]) return false;
                                }
                            }
                            else
                            {
                                for (int s = combinaciones[i], h = combinaciones[j]; s > combinaciones[i + 1] && h > combinaciones[j + 1]; s--, h--)
                                {
                                    if (!Mascara[s, h]) return false;
                                }
                            }
                        }
                        if (!Mascara[combinaciones[i + 1], combinaciones[j + 1]])
                            cantidad += 1;
                    }
                  else if(combinaciones[i]== combinaciones[i + 1])
                    {
                        if (combinaciones[j] < combinaciones[j + 1])
                        {
                            for (int s = combinaciones[j]; s < combinaciones[j + 1]; s++)
                            {
                                if (!Mascara[combinaciones[i], s]) return false;
                            }
                        }
                        else
                        {
                            for (int s = combinaciones[j]; s > combinaciones[j + 1]; s--)
                            {
                                if (!Mascara[combinaciones[i], s]) return false;
                            }

                        }
                        if(!Mascara[combinaciones[i+1],combinaciones[j+1]])
                        cantidad += 1;

                    }
                  else if( combinaciones[j]== combinaciones[j + 1])
                    {
                        if (combinaciones[i] < combinaciones[i + 1])
                        {
                            for (int s = combinaciones[i]; s < combinaciones[i + 1]; s++)
                            {
                                if (!Mascara[s,combinaciones[j]]) return false;
                            }
                        }
                        else
                        {
                            for (int s = combinaciones[i]; s > combinaciones[i + 1]; s--)
                            {
                                if (!Mascara[s, combinaciones[j]]) return false;
                            }

                        }
                        if(!Mascara[combinaciones[i+1], combinaciones[j+1]])
                        cantidad += 1;
                    }
                  else  if (Math.Abs(combinaciones[i] - combinaciones[i + 1]) != Math.Abs(combinaciones[j] - combinaciones[j + 1]))
                    {
                        if (!Mascara[combinaciones[i + 1], combinaciones[j + 1]])
                        {
                            cantidad += 1;
                        }
                    }
                }
            }
            if (Mascara[combinaciones[combinaciones.Length / 2 - 1], combinaciones[combinaciones.Length-1]])
                return false;
            if (cantidad == k)
            {
                return true;
            }
            return false;
        }
        class Program
    {
        static void Main(string[] args)
        {
            int k, f, c, s, n;

            k = 1; f = 2; c = 2; s = 12;
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine("| K:{0} --> Filas: {1}, Columnas: {2}", k, f, c);
            n = Patrones.CantidadValidos(k, f, c);
            Console.WriteLine("| >> Su solución fue {0} (y se esperaba {1})", n, s);
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine();

            k = 2; f = 2; c = 2; s = 24;
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine("| K:{0} --> Filas: {1}, Columnas: {2}", k, f, c);
            n = Patrones.CantidadValidos(k, f, c);
            Console.WriteLine("| >> Su solución fue {0} (y se esperaba {1})", n, s);
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine();

            k = 1; f = 2; c = 3; s = 26;
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine("| K:{0} --> Filas: {1}, Columnas: {2}", k, f, c);
            n = Patrones.CantidadValidos(k, f, c);
            Console.WriteLine("| >> Su solución fue {0} (y se esperaba {1})", n, s);
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine();

            k = 1; f = 4; c = 4; s = 172;
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine("| K:{0} --> Filas: {1}, Columnas: {2}", k, f, c);
            n = Patrones.CantidadValidos(k, f, c);
            Console.WriteLine("| >> Su solución fue {0} (y se esperaba {1})", n, s);
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine();

            k = 2; f = 4; c = 4; s = 1744;
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine("| K:{0} --> Filas: {1}, Columnas: {2}", k, f, c);
            n = Patrones.CantidadValidos(k, f, c);
            Console.WriteLine("| >> Su solución fue {0} (y se esperaba {1})", n, s);
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine();

            k = 3; f = 4; c = 4; s = 16880;
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine("| K:{0} --> Filas: {1}, Columnas: {2}", k, f, c);
            n = Patrones.CantidadValidos(k, f, c);
            Console.WriteLine("| >> Su solución fue {0} (y se esperaba {1})", n, s);
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine();

            k = 4; f = 4; c = 4; s = 154680;
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine("| K:{0} --> Filas: {1}, Columnas: {2}", k, f, c);
            n = Patrones.CantidadValidos(k, f, c);
            Console.WriteLine("| >> Su solución fue {0} (y se esperaba {1})", n, s);
            Console.WriteLine("+------------------------------------------");
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Iniciando exploración...");
            Explore(interactive: true);
        }

        static void Explore(int maxFilas = 4, int maxColumnas = 4, int maxK = 4, bool interactive = true)
        {
            for(int filas = 2; filas <= maxFilas; filas++) {
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine();
                for(int columnas = 2; columnas <= maxColumnas; columnas++) {
                    for(int k = 0; k <= filas * columnas && k <= maxK; k++) {
                        Console.WriteLine("K:{0} --> Filas: {1}, Columnas: {2}", k, filas, columnas);
                        int n = Patrones.CantidadValidos(k, filas, columnas);
                        Console.WriteLine("Patrones válidos: {0}", n);
                        if(interactive) {
                            Console.WriteLine("...");
                            Console.ReadLine();
                        }
                        else {
                            Console.WriteLine();
                        }
                    }
                }

            }
            Console.WriteLine("Done!!!");
        }
    }
}
