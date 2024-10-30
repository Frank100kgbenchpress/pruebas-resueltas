using Balanzas;
namespace Weboo.Examen
{
    public class ExamenMundial
    {
        public static bool Equilibrar(IBalanza balanza, int bolas, int pesoBola)
        {
            int pesoTotal = bolas * pesoBola;
            return EquilibrarRecursivo(balanza, pesoTotal);
        }

        static bool EquilibrarRecursivo(IBalanza balanza, int pesoTotal)
        {
            int largoIzquierdo = balanza.LargoIzquierdo;
            int largoDerecho = balanza.LargoDerecho;

            // Calculamos la proporción de pesos necesaria para el equilibrio
            int pesoIzquierdoNecesario = (pesoTotal * largoDerecho) / (largoIzquierdo + largoDerecho);
            int pesoDerechoNecesario = pesoTotal - pesoIzquierdoNecesario;

            // Verificamos si el peso se puede dividir sin decimales
            if ((pesoIzquierdoNecesario * largoIzquierdo) != (pesoDerechoNecesario * largoDerecho))
                return false;

            // Verificamos si las sub-balanzas pueden balancearse recursivamente
            return BalancearLado(balanza.PesoIzquierdo, pesoIzquierdoNecesario) &&
                   BalancearLado(balanza.PesoDerecho, pesoDerechoNecesario);
        }

        static bool BalancearLado(IPesable lado, int pesoNecesario)
        {
            if (lado is IPlatillo)
            {
                lado.Peso = pesoNecesario;
                return true;
            }
            else if (lado is IBalanza subBalanza)
            {
                // Intentamos balancear recursivamente esta sub-balanza
                return EquilibrarRecursivo(subBalanza, pesoNecesario);
            }
            return false;
        }
    }
}
