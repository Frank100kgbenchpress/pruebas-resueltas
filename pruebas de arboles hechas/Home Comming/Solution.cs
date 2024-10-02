namespace HomeComming
{
    public static class Solution
    {
        public static double MinDanger(CityNode RootCity)
        {
            if(RootCity.Roads().Length == 0) return 0;              // si mandan una hoja
            return Backtrack(RootCity, 0, double.MaxValue,1,false); //llamado recursivo
        }
        static double Backtrack(CityNode node, double actualDanger,  double best,double counter,bool road)
        {
            if(actualDanger >= best) return actualDanger;   // si el peligro actual es mayor que el que mejor que teniamos lo devolvemos para podar recursivo
            var children = node.Roads();                    //variable auxiliar para no escribir tanto
            var tp = node.HasTeleport();                    // otra auxiliar
            if(children.Length == 0 && !tp.Item1) return actualDanger;  //quiere decir que llegamos a una hoja y que no tiene portal de regreso
            if(tp.Item1 && road)    return best = Math.Min(best,Backtrack(tp.Item2!,actualDanger, best,counter+1,false));   //si tiene transportador y vinimos por tierra llamamamos recursivo aumentando y falso porque venimos de un portal
            for(int i = 0; i < children.Length;i++) // recorrer todos los hijos
            {
                best = Math.Min(best,Backtrack(children[i].Item2,actualDanger + (counter * children[i].Item1),best,counter+1,true)); // actualizar la variable de retorno con el llamado recursivo de por tierra o como estaba
            }
            return best; // su retorno
        }
    }
}