using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Balanzas;
using Weboo.Examen;

namespace TestApp
{
    #region útiles

    public class Balanza : IBalanza
    {
        public Balanza(int largoIzquierdo, IPesable pesoIzquierdo, int largoDerecho, IPesable pesoDerecho)
        {
            this.LargoIzquierdo = largoIzquierdo;
            this.LargoDerecho = largoDerecho;
            this.PesoIzquierdo = pesoIzquierdo;
            this.PesoDerecho = pesoDerecho;
        }
        public int Peso { get; set; }

        public int LargoIzquierdo { get; set; }

        public int LargoDerecho { get; set; }

        public IPesable PesoIzquierdo { get; set; }

        public IPesable PesoDerecho { get; set; }
    }

    public class Platillo : IPlatillo
    {
        public int Peso { get; set; }
    }

    #endregion

    class Program
    {
        static void Main()
        {
            #region ejemplo 1

            //--------------- EJEMPLO 1 ------------------//
            /*
                            |
                   +---+---[.]---+---+---+---+
                   |                         |
                 \___/                     \___/
             */
            Balanza balanza1 = new Balanza(2, new Platillo(), 4, new Platillo());
            var existe1 = ExamenMundial.Equilibrar(balanza1, 9, 1); //true
            Console.WriteLine("Ejemplo {0}: Se espera {1} y su solución devuelve {2}", 1, true, existe1);
            /*
                            |
                   +---+---[9]---+---+---+---+
                   |                         |
                   6                         3
                 \___/                     \___/
             */

            #endregion

            #region ejemplo 2

            //--------------- EJEMPLO 2 ------------------//
            /*
                            |
                   +---+---[.]---+---+---+---+
                   |                         |
                 \___/                     \___/
             */
            Balanza balanza2 = new Balanza(2, new Platillo(), 4, new Platillo());
            var existe2 = ExamenMundial.Equilibrar(balanza2, 10, 1);
            Console.WriteLine("Ejemplo {0}: Se espera {1} y su solución devuelve {2}", 2, false, existe2);

            #endregion

            #region ejemplo 3

            //--------------- EJEMPLO 3 ------------------//
            /*
                                  |
                         +---+---[.]---+---+---+---+
                         |                         |
                +---+---[.]---+---+              \___/
                |                 |
              \___/      +---+---[.]---+---+
                         |                 |
                       \___/             \___/
             */
            Balanza balanza3 = new Balanza(2, new Balanza(2, new Platillo(), 2, new Balanza(2, new Platillo(), 2, new Platillo())), 4, new Platillo());
            var existe3 = ExamenMundial.Equilibrar(balanza3, 6, 3);
            Console.WriteLine("Ejemplo {0}: Se espera {1} y su solución devuelve {2}", 3, true, existe3);
            /*
                                    |
                          +---+---[18]---+---+---+---+
                          |                          |
                          |                          6
                +---+---[12]---+---+               \___/
                |                  |
                6                  |
              \___/       +---+---[6]---+---+
                          |                 |
                          3                 3
                        \___/             \___/
             */

            #endregion

            #region ejemplo 4

            //--------------- EJEMPLO 4 ------------------//
            /*
                                                                                |
                                                           +---+---+---+---+---[.]---+---+---+---+---+
                                                           |                                         |
                                         +--------+-------[.]--------+              +---+---+---+---[.]---+---+---+
                                         |                           |              |                             |
                                    +---[.]---+---+             +---[.]---+---+   \___/                         \___/
                                    |             |             |             |
                               +---[.]---+      \___/         \___/         \___/
                  		       |         |
                  +---+---+---[.]---+  \___/
                  |                 |
                \___/             \___/
             */
            Balanza balanza4 = new Balanza(5, new Balanza(2, new Balanza(1, new Balanza(1, new Balanza(3, new Platillo(), 1, new Platillo()), 1, new Platillo()), 2, new Platillo()), 1, new Balanza(1, new Platillo(), 2, new Platillo())), 5, new Balanza(4, new Platillo(), 3, new Platillo()));
            var existe4 = ExamenMundial.Equilibrar(balanza4, 504, 1);
            Console.WriteLine("Ejemplo {0}: Se espera {1} y su solución devuelve {2}", 4, true, existe4);
            /*
                                                                                   |
                                                             +---+---+---+---+---[504]---+---+---+---+---+
                                                             |                                           |
                                          +--------+-------[252]--------+              +---+---+---+---[252]---+---+---+
                                          |                             |              |                               |
   	            					      |                             |              108                            144
                                     +---[84]---+---+             +---[168]---+---+   \___/                          \___/
                                     |              |             |               |
   	            				     |              28           112             56
                                +---[56]---+       \___/        \___/           \___/
                   		        |          |
   	            	    	    |          28
                   +---+---+---[28]---+   \___/
                   |                  |
   	               7                  21
                 \___/               \___/
             */

            #endregion

        }
    }
}

