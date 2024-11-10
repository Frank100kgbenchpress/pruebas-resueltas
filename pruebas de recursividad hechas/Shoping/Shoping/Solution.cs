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
        if(desired.Length == 0) return 0;   //si no quieren comprar nada no gastamos
        (IProduct,int)[] compra = PrePreparCompra(desired); //array para guardar los productos que queremos comprar
        int min = CompraDirecto(compra, desired);   //variable para guardar el precio de la compra directa(que seria el peor caso)
        int actual = min;   //variable para guardar el precio de la compra actual
        return Compra(compra,desired,min,actual,combos,0);  //metodo recusrivo
    }
    static int Compra((IProduct, int)[] producto,IProductQuantity[]desired, int min, int gastoCompraDirecta, ICombo[] combos, int actual)
    {
        if(actual >= gastoCompraDirecta) return int.MaxValue;   //si cuesta mas retornamos maxvalue para que no se tome en cuenta como compra valida
        if(AllBuyed(producto, desired)) return 0;      //si se compra todo retornamos 0 porque ya no hay que gastar mas dinero
        for(int i = 0; i < combos.Length; i++)          // recorremos los combos
        {
            if(ValidCombo(combos[i],desired))       //si el combo contiene algo de lo que buscamos
            {
                (IProduct, int)[] aux = ((IProduct, int)[])producto.Clone();    //copiamos el array de compra para que el original no se altere en el metodo
                int gastoAux = min; //guardamos nuestro minimo actual(que seria comprar directo)
                ComprarCombo(aux,combos[i]);    //actualizamos el array de compra coon el combo
                int nextBuy = Compra(aux,desired,CompraDirecto(aux,desired),gastoCompraDirecta,combos,actual + combos[i].Price);    //guardamos cuanto dio el llamado recursivo
                int compareBuy = (nextBuy == int.MaxValue) ? int.MaxValue : combos[i].Price + nextBuy;  //si fue valido el llamado recursivo guardamos el precio de la compra y si no devolvemos max value para no tomarlo en cuenta
                min = Math.Min(gastoAux, compareBuy);    // nos quedamos con el minimo entre el actual y el que obtuvimos(que seria entre haber comprado combo o comprar directo)
            }
        }
        return min;

    }
    static void ComprarCombo((IProduct, int)[] producto, ICombo combo)  //actualizamos nuestro array de compra si compramos un combo
    {
        for(int i = 0; i < combo.Products.Length; i++)
        {
            for(int j = 0; j < producto.Length; j++)
            {
                if(combo.Products[i].Product.Name == producto[j].Item1.Name)
                {
                    producto[j].Item2 += combo.Products[i].Quantity;
                }
            }
        }
    }
    static bool ValidCombo(ICombo combo, IProductQuantity[] desired)    //revisamos que el combo tenga algun producto de los que se querian
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
    static bool AllBuyed((IProduct, int)[] producto, IProductQuantity[] desired)    //caso base, que todo este comprado
    {
        for (int i = 0; i < desired.Length; i++)
        {
            if(producto[i].Item2 < desired[i].Quantity) return false;
        }
        return true;
    }
    static (IProduct,int)[] PrePreparCompra(IProductQuantity[] desired)     //guardamos en un array de tuplas los productos que queremos comprar 
    {
        (IProduct,int)[] compra = new (IProduct,int)[desired.Length];
        for (int i = 0; i < desired.Length; i++)
        {
            compra[i] = (desired[i].Product,0);
        }
        return compra;
    }
    static int CompraDirecto((IProduct, int)[] producto, IProductQuantity[] desired)    //calculamos el precio de la compra directa para compararrlo con los llamados recursivos
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
}