namespace Balanzas
{
    public interface IPesable
    {
        int Peso {get;set;}
    }
    public interface IBalanza : IPesable
    {
        int LargoIzquierdo {get;set;}
        int LargoDerecho {get;set;}
        IPesable PesoIzquierdo {get;set;}
        IPesable PesoDerecho {get;set;}
    }
    public interface IPlatillo : IPesable
    {

    }
}