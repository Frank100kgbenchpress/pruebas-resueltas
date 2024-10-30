

using System;
using System.Collections.Generic;

namespace Weboo.Examen
{
    public class CadenasBalanceadas
    {
        public static int MinOperacionesParaBalancear(string s)
        {
            if (s.Length % 2 != 0) return -1;  // Si tiene longitud impar, no se puede balancear

            Stack<char> stack = new Stack<char>();
            int replacements = 0;  // Contador de operaciones necesarias

            foreach (char c in s)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c);  // Apilamos cualquier apertura
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        // Si hay un cierre sin apertura correspondiente
                        replacements++;
                    }
                    else
                    {
                        char top = stack.Peek();
                        if ((c == ')' && top == '(') ||
                            (c == '}' && top == '{') ||
                            (c == ']' && top == '['))
                        {
                            stack.Pop();  // Desapilamos si es un par válido
                        }
                        else
                        {
                            // Reemplazamos porque hay un desajuste
                            replacements++;
                            stack.Pop();
                        }
                    }
                }
            }

            // Si quedan elementos en la pila, significa que son aperturas sin cerrar
            while (stack.Count > 0)
            {
                replacements++;
                stack.Pop();
            }

            return replacements;
        }
    }
}
