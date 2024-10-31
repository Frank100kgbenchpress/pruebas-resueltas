using System;
using System.Collections.Generic;

namespace Weboo.Examen
{
    public class CadenasBalanceadas
    {
        public static int MinOperacionesParaBalancear(string s)
        {
            var stack = new Stack<char>();
            int operations = 0;
            if(s.Length % 2 != 0) return -1;
            foreach (char c in s)
            {
                if (c == '(' || c == '{' || c == '[')
                {
                    stack.Push(c); // Almacenar aperturas
                }
                else
                {
                    if (stack.Count == 0)
                    {
                        // Si no hay apertura correspondiente, necesitamos una operación de reemplazo
                        operations++;
                    }
                    else
                    {
                        char top = stack.Peek();
                        if ((c == ')' && top == '(') ||
                            (c == '}' && top == '{') ||
                            (c == ']' && top == '['))
                        {
                            stack.Pop(); // Par correcto, no se requiere operación adicional
                        }
                        else
                        {
                            // Desemparejado; incrementar el conteo de operaciones
                            operations++;
                            stack.Pop(); // Remover el tope para no causar un desbalance posterior
                        }
                    }
                }
            }

            // Cualquier apertura sin cerrar en la pila requiere una operación de cierre
            operations += stack.Count;

            return operations;
        }
    }
}

