namespace ArbolSuma
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new ArbolSuma(1, 2, 3, 4);
            var pre = a.PreOrden();
            a.Imprimir();
            // | 10
            //   | 1
            //   | 2
            //   | 3
            //   | 4
            Console.WriteLine();

            a.InsertarPreOrden(0, new ArbolSuma(10));
            a.Imprimir();
            //| 20
            //  | 1
            //  | 2
            //  | 3
            //  | 4
            //  | 10
            Console.WriteLine();

            a.InsertarPostOrden(1, new ArbolSuma(10));
            a.Imprimir();
            // | 30
            //   | 1
            //   | 12
            //     | 10
            //     | 2
            //   | 3
            //   | 4
            //   | 10
            Console.WriteLine();

            a.InsertarKHoja(1, new ArbolSuma(-10));
            a.Imprimir();
            // | 20
            //   | 1
            //   | 2
            //     | 2
            //   | 3
            //   | 4
            //   | 10
            Console.WriteLine();

            a.InsertarKHoja(4, new ArbolSuma(-20));
            a.Imprimir();
            // | 0
            Console.WriteLine();
        }
    }   
}