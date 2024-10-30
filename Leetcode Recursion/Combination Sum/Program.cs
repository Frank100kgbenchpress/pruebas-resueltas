class CombinationSumRepitiendo
{
    public IList<IList<int>> CombinationSum(int[] candidates, int target) 
    {
        IList<IList<int>> result = [];
        List<int> currentCombination = [];
        Array.Sort(candidates);
        Backtrack(candidates,target,0,currentCombination,result);
        return result;
    }
    void Backtrack(int[]candidates,int target,int start,List<int> currentCombination,IList<IList<int>> result)
    {
        if(target == 0)
        {
            result.Add(new List<int>(currentCombination));
            return;
        }
        for(int i = start;i<candidates.Length;i++)
        {
            if(candidates[i]> target) break;
            currentCombination.Add(candidates[i]);
            Backtrack(candidates,target-candidates[i],i,currentCombination,result);
            currentCombination.RemoveAt(currentCombination.Count - 1);
        }
    }

}
class CombinationSumSinRepetir
{
    public IList<IList<int>> CombinationSum2(int[] candidates, int target) 
    {
        IList<IList<int>> result = [];
        Array.Sort(candidates);  // Ordenar para evitar duplicados
        Backtrack(candidates, target, 0, new List<int>(), result);
        return result;
    }
    private void Backtrack(int[] candidates, int target, int start, List<int> currentCombination, IList<IList<int>> result) 
    {
        if (target == 0) 
        {
            // Si el target es 0, se encontró una combinación válida
            result.Add(new List<int>(currentCombination));
            return;
        }
        
        for (int i = start; i < candidates.Length; i++) {
            // Si el número actual es mayor que el target, no hay necesidad de continuar
            if (candidates[i] > target) break;
            // Evitar duplicados: si el número actual es el mismo que el anterior, saltéalo
            if (i > start && candidates[i] == candidates[i - 1])     continue;
            // Añadir el número actual a la combinación
            currentCombination.Add(candidates[i]);

            // Llamada recursiva con el siguiente índice (i + 1) para no repetir el mismo número
            Backtrack(candidates, target - candidates[i], i + 1, currentCombination, result);

            // Hacer backtrack: eliminar el último número añadido
            currentCombination.RemoveAt(currentCombination.Count - 1);
        }
    }
}
// te dan el tamano el array y el numero y tienes que devolver las posibles soluciones de array de ese tamano
public class CombinationSum3sol
{
    public IList<IList<int>> CombinationSum3(int k, int n) 
    {
        List<IList<int>> results = new();
        Stack<int> stack = new();
        Backtrack(1,k,n);
        return results;
        void Backtrack(int start,int count,int target)
        {
            if(target == 0 && count == 0) results.Add(stack.ToArray());
            if(target == 0 || count == 0) return;
            for(int i = start; i < 10;i++)
            {
                stack.Push(i);
                Backtrack(i+1,count-1,target-i);
                stack.Pop();
            }
        }
    }
    
}
class CombinationSumQueDevuelveLaCantidadDeCombinacionesQUeTeDanElNumeroDeUnArrayAunqueRepita
{
    public int CombinationSum4(int[] nums, int target) 
    {  
        int[] dp = new int[target +1];  // Crear un array para almacenar el número de combinaciones para cada valor hasta el target  
        dp[0] =1;                       // Hay una forma de hacer la suma0 (no usar nada)  
        for (int i =1; i <= target; i++) // Iterar sobre cada número desde1 hasta el target 
        {  
            foreach (int num in nums)   // Iterar sobre cada número en nums   
            {  
                // Si el número es menor o igual al objetivo actual 
                if (i >= num)  dp[i] += dp[i - num]; // Sumar las combinaciones posibles   
            }
        }        
        return dp[target]; // Devolver el número de combinaciones para el target }  
    }
}