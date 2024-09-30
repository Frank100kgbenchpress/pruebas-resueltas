using System.Reflection.PortableExecutable;

namespace Solution;

public static class Solution
{
    public static int CostoDeEscape(INodo root)
    {
        int best = int.MaxValue;
        int actualCost = 0;
        var rootNode = root;

        void MinCost(INodo root, int character)
        {
            if (actualCost > best)
                return;

            var children = root.Hijos(character);
            var connectedChildren = root.HijosConectados(character);

            // leaf node
            if (children is null)
            {
                // Javi reached a leaf node and is time for Frank now
                if (character is 0) { MinCost(rootNode, 1); }

                // Frank reached a leaf node so is time to compare journey results
                else { best = Math.Min(best, actualCost); }

                return;
            }


            for (int i = 0; i < children.Length; i++)
            {
                if (children[i].Item3)
                {
                    // explore all the connected islands
                    actualCost += children[i].Item2;
                    MinCost(children[i].Item1, character);
                    // backtrack
                    actualCost -= children[i].Item2;
                }

                // if this island is not connected to the actual one we can move a bridge so we can cross
                // (in case that bridge exists)

                else
                {
                    // explore all the connected islands
                    for (int j = 0; j < children.Length; j++)
                    {
                        if (children[j].Item3)
                        {
                            // change bridge with disconnected island
                            root.IntercambiarConexion(j, i);
                            actualCost += 2 * children[i].Item2;
                            MinCost(children[i].Item1, character);

                            // backtrack
                            actualCost -= 2 * children[i].Item2;
                            root.IntercambiarConexion(i, j);
                        }
                    }
                }
            }
        }
        MinCost(root, 0);

        return best;
    }
    
}
class Nodo : INodo
{
    Hijo[]? hijos;

    public Nodo() { }

    public Nodo(INodo nodo, (int, int) costo, bool conectado)
    {
        this.hijos = new Hijo[]
        {
            new Hijo
            {
                Nodo = nodo,
                Costo = new int[] { costo.Item1, costo.Item2 },
                Conectado = conectado
            }
        };
    }

    public Nodo((INodo nodo, (int, int) costo, bool conectado)[] hijos)
    {
        this.hijos = (
            from val in hijos
            select new Hijo
            {
                Nodo = val.nodo,
                Costo = new int[] { val.costo.Item1, val.costo.Item2 },
                Conectado = val.conectado
            }
        ).ToArray();
    }

    public (INodo, int, bool)[]? Hijos(int personaje)
    {
        return this.hijos is null
            ? null
            : (
                from hijo in hijos
                select (hijo.Nodo, hijo.Costo[personaje], hijo.Conectado)
            ).ToArray();
    }

    public (INodo, int, int)[]? HijosConectados(int personaje)
    {
        return this.hijos is null
            ? null
            : (
                from data in hijos.Select((hijo, index) => (hijo, index))
                where data.hijo.Conectado
                select (data.hijo.Nodo, data.index, data.hijo.Costo[personaje])
            ).ToArray();
    }

    public void IntercambiarConexion(int conectado, int desconectado)
    {
        hijos?[conectado].Desconectar();
        hijos?[desconectado].Conectar();
    }
}

struct Hijo
{
    public INodo Nodo;
    public bool Conectado;
    public int[] Costo;

    public void Conectar()
    {
        if (this.Conectado)
            throw new ArgumentException("Reconectando nodo ya conectado");
        this.Conectado = true;
    }

    public void Desconectar()
    {
        if (!this.Conectado)
            throw new ArgumentException("Desconectando nodo ya desconectado");
        this.Conectado = false;
    }

    public override string ToString()
    {
        return $"Nodo{{{this.Conectado},  ({this.Costo[0]}, {this.Costo[1]})}}";
    }
}