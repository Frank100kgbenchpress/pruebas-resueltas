using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using MatCom.Examen;

class Program {

    public static Func<int> GetSampler()
    {
        Random random = new Random(2024);
        return () => random.Next();
    }

    public static Func<int> FixedSampler() {
        int cursor = 0;
        int[] results = new int[] {
            247130676,
            1495952918,
            1116080357,
            1216877399,
            28283303,
            704472390,
            1659538823,
            1828387271,
            816368896,
            1344166033,
        };
        return () => {
            try {
                return results[cursor++];
            }
            catch (IndexOutOfRangeException) {
                Console.WriteLine("WARNING: Llamado innecesario al sampler. Devolviendo 0 por defecto.");
                return 0;
            }
                
        };
    }

    public static void Main() {
        Production[] productions = new Production[] {
            new Production("S", "AS".ToCharArray()),
            new Production("S", "BS".ToCharArray()),
            new Production("A", "aA".ToCharArray()),
            new Production("A", "a".ToCharArray()),
            new Production("B", "bB".ToCharArray()),
            new Production("B", "b".ToCharArray()),
            new Production("SS", "c".ToCharArray()),
            new Production("SSSS", "d".ToCharArray()),
            new Production("AA", "e".ToCharArray()),
        };

        Func<int> sampler;
        Tree start;
        Tree final;
        string expected;

        // Example 1
        sampler = FixedSampler();
        start = new Tree("S");
        final = Solution.DeriveFromGrammar(start, 1, productions, sampler);
        expected = "TREE\n|__ SS\n    |__ A\n    |__ S";
        Console.WriteLine($"""
            ============================================
            [Árbol Obtenido] -> ¿Correcto? R.\ {expected == final.ToString()}
            {final}
            """
        );
        Console.WriteLine($"""
            [Árbol Esperado]
            {expected}
            ============================================
            """
        );

        // Example 2
        sampler = FixedSampler();
        start = new Tree("S");
        final = Solution.DeriveFromGrammar(start, 2, productions, sampler);
        expected = "TREE\n|__ SSSS\n    |__ AA\n        |__ a\n        |__ A\n    |__ SS\n        |__ B\n        |__ S\n    |__ c";
        Console.WriteLine($"""
            ============================================
            [Árbol Obtenido]  -> ¿Correcto? R.\ {expected == final.ToString()}
            {final}
            """
        );
        Console.WriteLine($"""
            [Árbol Esperado]
            {expected}
            ============================================
            """
        );


        // Example 3
        sampler = FixedSampler();
        start = new Tree("S");
        final = Solution.DeriveFromGrammar(start, 3, productions, sampler);
        expected = "TREE\n|__ SSSSSSSS\n    |__ AAAA\n        |__ aa\n        |__ AA\n            |__ a\n        |__ e\n    |__ SSSS\n        |__ BB\n            |__ b\n        |__ SS\n            |__ B\n            |__ S\n        |__ c\n    |__ cc\n    |__ d";
        Console.WriteLine($"""
            ============================================
            [Árbol Obtenido]  -> ¿Correcto? R.\ {expected == final.ToString()}
            {final}
            """
        );
       Console.WriteLine($"""
            [Árbol Esperado]
            {expected}
            ============================================
            """
        );
    }
}
