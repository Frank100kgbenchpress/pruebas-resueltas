using System;  
using System.Collections.Generic;  

namespace Weboo.Examen  
{  
    public class CadenasBalanceadas  
    {  
        public static int MinOperacionesParaBalancear(string s)  
        {  
            Stack<char> stack = new Stack<char>();  
            int operaciones = 0;  

            // Mapa de correspondencia de caracteres  
            Dictionary<char, char> pares = new Dictionary<char, char>  
            {  
                { '(', ')' },  
                { '{', '}' },  
                { '[', ']' }  
            };  

            // Mapa para verificar si un carácter es de apertura  
            HashSet<char> apertura = new HashSet<char>(pares.Keys);  
            // Mapa para verificar si un carácter es de cierre  
            HashSet<char> cierre = new HashSet<char>(pares.Values);  

            foreach (char c in s)  
            {  
                if (apertura.Contains(c))  
                {  
                    stack.Push(c);  
                }  
                else if (cierre.Contains(c))  
                {  
                    if (stack.Count > 0 && pares[stack.Peek()] == c)  
                    {  
                        stack.Pop(); // Se encuentra un par balanceado  
                    }  
                    else  
                    {  
                        operaciones++; // Se necesita una operación para balancear  
                    }  
                }  
            }  

            // Al final, los elementos restantes en la pila son los que no se han balanceado  
            operaciones += stack.Count;  

            // Si hay más operaciones que caracteres, no se puede balancear  
            return operaciones % 2 == 0 ? operaciones / 2 : -1;  
        }  
    }  
}
