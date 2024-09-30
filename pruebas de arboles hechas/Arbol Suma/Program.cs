using System;
using System.Collections.Generic;
using System.Linq;
namespace ArbolSuma
{
    public interface IArbol<T>
    {
        T Valor { get; } // Valor del nodo
        IEnumerable<IArbol<T>> Hijos { get; } // Hijos
        IEnumerable<T> PostOrden(); // Recorrido PostOrden
        IEnumerable<T> PreOrden(); // Recorrido PreOrden
    }
    public interface IArbolSuma : IArbol<int>
    {
        void InsertarPreOrden(int k, IArbolSuma nuevo);
        void InsertarPostOrden(int k, IArbolSuma nuevo);
        void InsertarKHoja(int k, IArbolSuma nuevo);
    }



    public class ArbolSuma : IArbolSuma
{
    private List<IArbolSuma> hijos;
    private int valor;

    public ArbolSuma(params int[] values)
    {
        if (values.Length == 1)
        {
            this.valor = values[0];
            this.hijos = new List<IArbolSuma>();
        }
        else
        {
            this.valor = values.Sum();
            this.hijos = values.Select(v => new ArbolSuma(v)).Cast<IArbolSuma>().ToList();
        }
    }

    public int Valor => valor;

    public IEnumerable<IArbol<int>> Hijos => hijos.Cast<IArbol<int>>();

    public IEnumerable<int> PreOrden()
    {
        yield return this.valor;
        foreach (var hijo in hijos)
        {
            foreach (var val in hijo.PreOrden())
            {
                yield return val;
            }
        }
    }

    public IEnumerable<int> PostOrden()
    {
        foreach (var hijo in hijos)
        {
            foreach (var val in hijo.PostOrden())
            {
                yield return val;
            }
        }
        yield return this.valor;
    }

    public void InsertarPreOrden(int k, IArbolSuma nuevo)
    {
        var nodos = ObtenerNodosPreOrden().ToList();
        if (k >= 0 && k < nodos.Count)
        {
            var nodoPadre = nodos[k];
            (nodoPadre as ArbolSuma).InsertarHijo(nuevo);
            ActualizarValores();
        }
    }

    public void InsertarPostOrden(int k, IArbolSuma nuevo)
    {
        var nodos = ObtenerNodosPostOrden().ToList();
        if (k >= 0 && k < nodos.Count)
        {
            var nodoPadre = nodos[k];
            (nodoPadre as ArbolSuma).InsertarHijo(nuevo);
            ActualizarValores();
        }
    }

    public void InsertarKHoja(int k, IArbolSuma nuevo)
    {
        var hojas = ObtenerHojas().ToList();
        if (k >= 0 && k < hojas.Count)
        {
            var hoja = hojas[k];
            var nuevaHoja = new ArbolSuma(hoja.Valor);  // Convertimos la hoja en nodo y creamos una nueva hoja con el valor anterior.
            (hoja as ArbolSuma).InsertarHijo(nuevaHoja);
            (hoja as ArbolSuma).InsertarHijo(nuevo);
            ActualizarValores();
        }
    }

    // Método auxiliar para obtener nodos en PreOrden
    private IEnumerable<IArbolSuma> ObtenerNodosPreOrden()
    {
        yield return this;
        foreach (var hijo in hijos)
        {
            foreach (var nodo in (hijo as ArbolSuma).ObtenerNodosPreOrden())
            {
                yield return nodo;
            }
        }
    }

    // Método auxiliar para obtener nodos en PostOrden
    private IEnumerable<IArbolSuma> ObtenerNodosPostOrden()
    {
        foreach (var hijo in hijos)
        {
            foreach (var nodo in (hijo as ArbolSuma).ObtenerNodosPostOrden())
            {
                yield return nodo;
            }
        }
        yield return this;
    }

    // Método auxiliar para obtener todas las hojas
    private IEnumerable<IArbolSuma> ObtenerHojas()
    {
        if (!hijos.Any())  // Si no tiene hijos, es una hoja.
        {
            yield return this;
        }
        else
        {
            foreach (var hijo in hijos)
            {
                foreach (var hoja in (hijo as ArbolSuma).ObtenerHojas())
                {
                    yield return hoja;
                }
            }
        }
    }

    // Método para insertar un nuevo hijo
    private void InsertarHijo(IArbolSuma nuevo)=>    hijos.Add(nuevo);
    

    // Método para actualizar los valores del árbol después de una inserción
    private void ActualizarValores()
    {
        if (hijos.Any())
        {
            valor = hijos.Sum(h => h.Valor);
        }
    }
    public void Imprimir(string indent = "", bool last = false)
        {
            Console.Write(indent);
            Console.Write("| ");
            indent += "  ";

            Console.WriteLine(Valor);

            for (int i = 0; i < Hijos.Count(); i++)
            {
                (Hijos.ElementAt(i) as ArbolSuma).Imprimir(indent, i == Hijos.Count() - 1);
            }
        }
}

}


