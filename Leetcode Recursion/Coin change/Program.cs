public class Solution //devuelve el mas optimo
{
    public int CoinChange(int[] coins, int amount) 
    {
        int[] memo = new int[amount + 1]; // array para guardar calculos
        Array.Fill(memo, -1);  // Inicializa el memo con -1 para indicar que no se ha calculado
        int res = Find(coins, amount, memo);
        return res == int.MaxValue ? -1 : res; // solucion
    }

    int Find(int[] coins, int amount, int[] memo) 
    {
        if (amount == 0) return 0;  // Si la cantidad es 0, no se necesitan más monedas
        if (amount < 0) return int.MaxValue;  // Si la cantidad es negativa, no es posible

        if (memo[amount] != -1) return memo[amount];  // Si ya se ha calculado, retornarlo

        int minCoins = int.MaxValue;
        foreach (var coin in coins) 
        {
            int res = Find(coins, amount - coin, memo); //ir probando recursivamente por cada moneda
            if (res != int.MaxValue)                    //si es solucion
            {
                minCoins = Math.Min(minCoins, res + 1); //chequea q sea mejor
            }
        }

        memo[amount] = minCoins;  // Guardar el resultado en memo
        return minCoins;
    }
}
class CoinChangeII // devuelve todos
{
    public int Change(int[] coins, int amount) 
    {
        int[,] memo = new int[coins.Length +1, amount +1];  // Inicializar un array para la memorización
        for (int i =0; i <= coins.Length; i++)              // Llenar el memo con -1, que significa que no se ha calculado
        {
            for (int j =0; j <= amount; j++)
            {
                memo[i, j] = -1;
            }
        }
    
        return CountCombinations(coins, coins.Length, amount, memo);    // Llamar a la función recursiva 
    }
    int CountCombinations(int[] coins, int n, int amount, int[,] memo)
    {
        if (amount ==0) return 1; // Si el monto es 0, hay una combinación (no usar ninguna moneda)
        if (amount <0 || n ==0) return 0;   // Si el monto es negativo o no hay más monedas para probar
        if (memo[n, amount] != -1)return memo[n, amount];   // Si el resultado ya fue calculado, retornarlo 
        int includeCurrentCoin = CountCombinations(coins, n, amount - coins[n -1], memo);   // Contar combinaciones incluyendo la moneda actual
        int excludeCurrentCoin = CountCombinations(coins, n -1, amount, memo);      // Contar combinaciones excluyendo la moneda actual
        memo[n, amount] = includeCurrentCoin + excludeCurrentCoin;  // Guardar el resultado en el memo
        return memo[n, amount];
    }
}

 
