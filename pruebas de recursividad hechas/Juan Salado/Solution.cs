namespace JuanSalado
{
    public class Solution
    {
        public static long Solve(long capacity, long[] buy_prices, long[] buy_capacities, long[] sell_prices, long[] sell_capacities)
        {
            long sum = sell_capacities.Where(x => x <= capacity).Sum(); // para saber el total que se puede vender
            long maxCapacity = capacity > sum ? sum : capacity; // para saber si la capacidad es mayor a la capacidad de venta para no comprar por gusto
            long actualCapacity = 0;
            var buyPrices = new (long, long)[buy_prices.Length];
            var sellPrices = new (long, long)[sell_capacities.Length];
            for (int i = 0; i < buyPrices.Length; i++)
            {
                buyPrices[i] = (buy_prices[i], buy_capacities[i]); // tener guardados los precios y capacidades de compra
            }
            for (int i = 0; i < sellPrices.Length; i++)
            {
                sellPrices[i] = (sell_prices[i], sell_capacities[i]);   // tener guardados los precios y capacidades de venta
            }
            buyPrices = buyPrices.OrderBy(x => x.Item1).ToArray();      //los ordenamos de menor a mayor para comprar primero los mas baratos
            sellPrices = sellPrices.OrderBy(x => x.Item1).ToArray();    //los ordenamos de mayor a menor para vender los mas caros
            var tuple = Buy(actualCapacity, maxCapacity, buyPrices);
            return Sell(tuple.Item2, sellPrices, 0, tuple.Item1, 0);
        }   
        static(long,long) Buy(long actualCapacity, long maxCapacity, (long, long)[] buyPrices)
        {
            if(actualCapacity == maxCapacity) { return (0,actualCapacity); } // quiere decir que no se va a comprar mas
            long loss = 0;      // variable para perdida
            long index = 0;     //varaiable para ganancia
            while (actualCapacity != maxCapacity)
            {
                if (buyPrices[index].Item2 == 0)
                {
                    index++;
                }
                else
                {
                    actualCapacity += 1;
                    buyPrices[index].Item2 -= 1;
                    loss += buyPrices[index].Item1;
                }
            }
            return (loss, actualCapacity);
        }
        static long Sell(long actualCapacity, (long, long)[] sellPrices, long win, long loss, long index)
        {
            if (index == sellPrices.Length || actualCapacity == 0)    return win - loss;
            if (sellPrices[index].Item2 > actualCapacity)     return Sell(actualCapacity, sellPrices, win, loss, ++index); 
            long bestProfit = Math.Max
            (
                Sell(actualCapacity - sellPrices[index].Item2, sellPrices, win + (sellPrices[index].Item1 * sellPrices[index].Item2), loss, ++index),
			    Sell(actualCapacity, sellPrices, win, loss, index)
            );
            return bestProfit;
        }
    }
}