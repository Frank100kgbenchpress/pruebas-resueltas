using Balanzas;
namespace Weboo.Examen
{
    public class ExamenMundial
    {
        public static bool Equilibrar(IBalanza balanza, int bolas, int pesoBola)
        {
            int pesoTotal = bolas * pesoBola;   //el peso total de las bolas para balancear
            return EquilibrarRecursivo(balanza, pesoTotal); //funcion recursiva que balancea las bolas con logica divide y venceras
        }

        static bool EquilibrarRecursivo(IBalanza balanza, int pesoTotal)
        {
            int largoIzquierdo = balanza.LargoIzquierdo;    // guardamos el largo de la balanza izquierda
            int largoDerecho = balanza.LargoDerecho;        // guardamos el largo de la balanza derecha

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
