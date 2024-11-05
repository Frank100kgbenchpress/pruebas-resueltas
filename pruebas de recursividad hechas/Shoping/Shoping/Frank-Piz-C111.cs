using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

public interface IProduct
{
    int Price { get; }
    string Name { get; }
}

public interface IProductQuantity
{
    IProduct Product { get; }
    int Quantity { get; }
}

public interface ICombo
{
    int Price { get; }
    IProductQuantity[] Products { get; }
}
 public static class Exam
{
    public static int Solve(IProduct[] products, ICombo[] combos, IProductQuantity[] desired)
    {
        if (desired.Length == 0) return 0;
        List<(IProduct, int)> cantActualXProducto = new();
        RellenarLista(cantActualXProducto, products);
        return Comprar(CompraDirecto(cantActualXProducto, desired), CompraDirecto(cantActualXProducto, desired), cantActualXProducto, desired, combos, 0);
    }

    static int Comprar(int gastoCompraDirecta, int gastoMinimo, List<(IProduct, int)> cantActualXProducto, IProductQuantity[] desired, ICombo[] combos, int gastoActual)
    {
        if (Finish(cantActualXProducto, desired))    return 0; // al realizar una compra valida guardamos el gasto como estaba
        if (gastoActual >= gastoMinimo)    return int.MaxValue; // si se pasa del minimo que se puede gastar, no es una solucion valida por tanto maxvalue para que no se compare con validas
        for (int i = 0; i < combos.Length; i++)                 //comprobar combinaciones de combos
        {
            if (ValidCombo(combos[i], desired))                 //si posee algun elemento de los deseados
            {
                List<(IProduct, int)> listAux = CopiarLista(cantActualXProducto);   //hacemos una auxiliar de la compra actual
                int aux = gastoCompraDirecta;                   //otro auxiliar para no modificar el gasto de la compra directa
                ComprarCombo(listAux, combos[i]);               //guardamos en la lista auxiliar la compra del combo
                int sigGasto = Comprar(CompraDirecto(listAux, desired), gastoMinimo, listAux, desired, combos, gastoActual + combos[i].Price);  //seguimos chequeando que pasa con ese combo
                int gastoAComparar = (sigGasto == int.MaxValue) ? int.MaxValue : combos[i].Price + sigGasto;   // guardamos el precio del combo 
                gastoCompraDirecta = Math.Min(aux, gastoAComparar); //chequeamos si fue minimo
            }
        }
        return gastoCompraDirecta;  // retornamos el gasto minimo
    }

    static int CompraDirecto(List<(IProduct, int)> producto, IProductQuantity[] desired)    // guarda el precio de comprar todo directamente
    {
        int result = 0;
        int necesario = 0;
        for (int i = 0; i < desired.Length; i++)
        {
            necesario = Math.Max(0, desired[i].Quantity - producto[i].Item2);
            result += producto[i].Item1.Price * necesario;
        }
        return result;
    }

    static void RellenarLista(List<(IProduct, int)> list, IProduct[] products)  //hacemos una lista auxiliar para guardar el avance de las compras
    {
        foreach (var product in products)
        {
            list.Add((product, 0));
        }
    }

    static bool Finish(List<(IProduct, int)> list, IProductQuantity[] desired)  //chequeamos que todo este comprado
    {
        for (int i = 0; i < desired.Length; i++)
        {
            if ((desired[i].Quantity - list[i].Item2) > 0)
            {
                return false;
            }
        }
        return true;
    }

    static bool ValidCombo(ICombo combo, IProductQuantity[] desired)        //revisamos que el combo tenga algun producto de los que se querian 
    {
        for (int i = 0; i < combo.Products.Length; i++)
        {
            for (int j = 0; j < desired.Length; j++)
            {
                if (combo.Products[i].Product.Name == desired[j].Product.Name)
                {
                    return true;
                }
            }
        }
        return false;
    }

    static List<(IProduct, int)> CopiarLista(List<(IProduct, int)> list)    //hacemos una copia de la lista manualmente para que sea por valor y no se cambien los enteros juntos
    {
        List<(IProduct, int)> result = [.. list];
        return result;
    }

    static void ComprarCombo(List<(IProduct, int)> list, ICombo combo)      //actualizamos nuestra lista con la compra del combo
    {
        for (int i = 0; i < combo.Products.Length; i++)
        {
            for (int j = 0; j < list.Count; j++)
            {
                if (list[j].Item1.Name == combo.Products[i].Product.Name)
                {
                    list[j] = (list[j].Item1, list[j].Item2 + combo.Products[i].Quantity);
                }
            }
        }
    }
}

            

