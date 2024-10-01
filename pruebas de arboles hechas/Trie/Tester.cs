namespace Trie
{
    class Program
    {
        static void Main()
        {
            Trie t = new Trie(); //Se crea un nuevo trie

            int total = t.CantidadDePalabras; // total = 0
            Print("total", total);

            string mayorPrefijo1 = t.MayorPrefijoComun(); //El mayor prefijo hasta el momento es ""
            Print("mayorPrefijo1", mayorPrefijo1);

            t.AgregarPalabra("ABRIL");
            string mayorPrefijo2 = t.MayorPrefijoComun(); //mayorPrefijo2 = "ABRIL"
            Print("mayorPrefijo2", mayorPrefijo2);


            t.AgregarPalabra("ABRIR");
            string mayorPrefijo3 = t.MayorPrefijoComun(); //mayorPrefijo3 = "ABRI"
            Print("mayorPrefijo3", mayorPrefijo3);


            t.AgregarPalabra("ABACO");
            string mayorPrefijo4 = t.MayorPrefijoComun(); //mayorPrefijo4 = "AB"
            Print("mayorPrefijo4", mayorPrefijo4);


            NodoTrie nodoA = t['A']; //Único hijo de la raíz hasta el momento.
                                     //Valor: 'A', fin de palabra: false, Hijos: 1
            Print("nodoA", nodoA);

            NodoTrie nodoH = t['H']; //null, ninguna palabra empieza con 'H'
            Print("nodoH", nodoH);

            NodoTrie nodoAB = nodoA['B']; //Nodo hijo de la letra 'A'. Parte del prefijo "AB"
            Print("nodoAB", nodoAB);

            bool iguales = nodoAB == nodoA.Hijos[0]; //iguales = true.
                                                     //El nodo 'B' es el primer hijo del nodo 'A'.

            Print("nodoAB == nodoA.Hijos[0]", iguales);

            total = t.CantidadDePalabras; // total = 3
            Print("total", total);

            t.AgregarPalabra("HUMO");
            string mayorPrefijo5 = t.MayorPrefijoComun(); //mayorPrefijo5 = ""
            Print("mayorPrefijo5", mayorPrefijo5);

            t.AgregarPalabra("HORMIGA");
            t.AgregarPalabra("AZULEJO");
            t.AgregarPalabra("HORNOS");
            t.AgregarPalabra("AZUL");
            t.AgregarPalabra("HORNO");

            nodoH = t['H']; //Segundo hijo de la raíz hasta el momento.
                            //Valor 'H', fin de palabra: false, Hijos: 2

            Print("nodoH", nodoH);

            NodoTrie nodoHUMO = t['H']['U']['M']['O']; //Nodo con la letra 'O' de 'HUMO'.
                                                       //Valor: 'O', fin de palabra: true, Hijos: 0
            Print("nodoHUMO", nodoHUMO);

            NodoTrie nodoABACO = t['A']['B']['A']['C']['O']; //Nodo con la letra 'O' de 'ABACO'.
                                                             //Valor: 'O', fin de palabra: true, Hijos: 0
            Print("nodoABACO", nodoABACO);

            bool iguales2 = nodoHUMO == nodoABACO; //iguales2 = false.
                                                   //Mismo valor pero no la misma referencia.
            Print("nodoHUMO == nodoABACO", iguales2);

            var conPrefijoA = t.PalabrasConPrefijo("A");
            //conPrefijoA = {ABRIL, ABRIR, ABACO, AZUL, AZULEJO}
            Print("conPrefijoA", conPrefijoA);

            var conPrefijoH = t.PalabrasConPrefijo("H");
            //conPrefijoH = { HUMO, HORMIGA, HORNO, HORNOS}
            Print("conPrefijoH", conPrefijoH);

            var conPrefijoAZUL = t.PalabrasConPrefijo("AZUL");
            //conPrefijoAZUL = { AZUL, AZULEJO}
            Print("conPrefijoAZUL", conPrefijoAZUL);

            var conPrefijoAB = t.PalabrasConPrefijo("AB");
            //conPrefijoAB = { ABRIL, ABRIR, ABACO}
            Print("conPrefijoAB", conPrefijoAB);

            var conPrefijoHORN = t.PalabrasConPrefijo("HORN");
            //conPrefijoHORN = { HORNO, HORNOS}
            Print("conPrefijoHORN", conPrefijoHORN);

            var conPrefijoX = t.PalabrasConPrefijo("X");
            //conPrefijoX = { } (Iterador vacío)
            Print("conPrefijoX", conPrefijoX);

            var conPrefijoVacio = t.PalabrasConPrefijo("");
            //conPrefijoVacio = { ABRIL, ABRIR, ABACO, AZUL, AZULEJO, HUMO, HORMIGA, HORNO, HORNOS}
            //Todas las palabras en el trie
            Print("conPrefijoVacio", conPrefijoVacio);

            bool estaAZUL = t.Contiene("AZUL"); //estaAZUL = true
            Print("estaAZUL", estaAZUL);

            bool estaAZULES = t.Contiene("AZULES"); //estaAZULES = false (No existe secuencia de nodos)
            Print("estaAZULES", estaAZULES);

            bool estaAZULE = t.Contiene("AZULE"); //estaAZULE = false (La 'E' no es un fin de palabra)
            Print("estaAZULE", estaAZULE);

            total = t.CantidadDePalabras; // total = 9
            Print("total", total);

            //Para imprimir el trie en la Consola
            PrintTrie(t);

            t.Vaciar(); //El trie ha quedado vacío
            nodoA = t['A']; //null, ninguna palabra empieza con 'A'
            Print("nodoA", nodoA);

            total = t.CantidadDePalabras; // total = 0
            Print("total", total);
        }

        #region Utiles
        private static void Print(string title, int value)
        {
            Console.WriteLine("{0}: {1}\n", title, value);
        }

        private static void Print(string title, string value)
        {
            if (value == null)
                Console.WriteLine("{0}: null\n", title);
            else
                Console.WriteLine("{0}: \"{1}\"\n", title, value);
        }

        private static void Print(string title, bool value)
        {
            Console.WriteLine("{0}: {1}\n", title, value);
        }

        private static void Print(string title, IEnumerable<string> values)
        {
            if (values == null)
                Console.WriteLine("{0}: null\n", title);
            else
            {
                Console.Write("{0}: {1}", title, "{");
                var e = values.GetEnumerator();

                if (e.MoveNext())
                {
                    Console.Write("{0}", e.Current);

                    while (e.MoveNext())
                    {
                        Console.Write(", {0}", e.Current);
                    }
                }

                Console.WriteLine("}\n");
                e.Dispose();
            }
        }

        private static void Print(string title, NodoTrie value)
        {
            if (value == null)
                Console.WriteLine("{0}: null\n", title);
            else
                Console.WriteLine("{0}: Valor: '{1}' Fin de Palabra: {2} Hijos: {3}\n", title, value.Valor, value.FinDePalabra, value.Hijos.Count);
        }

        private static void PrintTrie(Trie trie)
        {
            Console.WriteLine("(\"\")");
            foreach (var node in trie.Raiz.Hijos)
                PrintNode(node, 1);
        }

        private static void PrintNode(NodoTrie node, int lvl)
        {
            for (int i = 0; i < 4 * (lvl - 1) + 2; i++) Console.Write(" ");
            for (int i = 0; i < 4; i++) Console.Write("+");
            if (node.FinDePalabra)
                Console.WriteLine("[{0}]", node.Valor);
            else
                Console.WriteLine("({0})", node.Valor);

            foreach (var child in node.Hijos)
                PrintNode(child, lvl + 1);

        }

        #endregion
    }   
}