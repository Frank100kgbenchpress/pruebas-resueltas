using System;
using Paracaidas;
public class Program
{
    public static void Main()
    {
        // Caso de prueba 1
        int[,] terreno1 = {
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        };
        int delta1 = 2;
        int esperado1 = 3; // Número de casillas esperadas en la mayor área explorable
        EjecutarPrueba(terreno1, delta1, esperado1);

        // Caso de prueba 2: Terreno plano
        int[,] terreno2 = {
            { 5, 5, 5 },
            { 5, 5, 5 },
            { 5, 5, 5 }
        };
        int delta2 = 0;
        int esperado2 = 9; // Todo el terreno es explorable
        EjecutarPrueba(terreno2, delta2, esperado2);

        // Caso de prueba 3: Diferencia alta permite explorar todo el terreno
        int[,] terreno3 = {
            { 10, 20, 10 },
            { 20, 30, 20 },
            { 10, 20, 10 }
        };
        int delta3 = 20;
        int esperado3 = 9;
        EjecutarPrueba(terreno3, delta3, esperado3);

        // Caso de prueba 4: Terreno con mayores variaciones
        int[,] terreno4 = {
            { 1, 10, 1 },
            { 1, 1, 10 },
            { 10, 1, 1 }
        };
        int delta4 = 1;
        int esperado4 = 5; // Solo ciertas casillas son explorables
        EjecutarPrueba(terreno4, delta4, esperado4);

        int[,] terreno = {
            { 5, 3, 4, 5 },
            { 6, 1, 1, 7 },
            { 5, 2, 2, 8 },
            { 9, 3, 4, 5 }
        };
        int delta = 2;
        int esperado = 12; // El documento especifica que el resultado esperado es 12

        EjecutarPrueba(terreno, delta, esperado);
    }

    static void EjecutarPrueba(int[,] terreno, int delta, int esperado)
    {
        int resultado = Paracaidista.EscogeMayorArea(terreno, delta);
        Console.WriteLine(resultado == esperado ? "Prueba exitosa!" : $"Prueba fallida. Esperado: {esperado}, pero se obtuvo: {resultado}");    
    }
}

