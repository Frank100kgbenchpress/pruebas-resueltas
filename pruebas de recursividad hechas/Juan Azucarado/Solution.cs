namespace JuanAzucarado
{
   public class Solution
    {
        public static long Solve(long capacity, long[] buy_prices, long[] buy_capacities, long[] sell_prices, long[] sell_capacities)
        {
            long maxCapacity = Math.Min(capacity,buy_capacities.Sum());
            (long,long)[] buy = new (long,long)[buy_capacities.Length];
            (long,long)[] sell = new (long,long)[sell_capacities.Length];
            for(int i=0;i<buy_capacities.Length;i++)
            {
                buy[i] = (buy_prices[i],buy_capacities[i]);
            }
            for(int i=0;i<sell_capacities.Length;i++)
            {
                sell[i] = (sell_prices[i],sell_capacities[i]);
            }
            buy = buy.OrderBy(x => x.Item1).ToArray();
            return Sell(maxCapacity,buy,sell,maxCapacity,0,0);
        }

        static long Buy( long maxCapacity, long actualCapacity, (long,long)[] buy)
        {
            long result = 0;
            int i = 0;
            long j = buy[i].Item2;
            if (actualCapacity == maxCapacity) return 0;
            while(actualCapacity != maxCapacity && i<buy.Length)
            {
                actualCapacity += 1;
                j -= 1;
                result += buy[i].Item1;
                if(j==0)
                {
                    if(i+1<buy.Length)
                    {
                    i++;
                    j = buy[i].Item2;
                    }
                }
            }
            return result;
        }

        static long Sell(long actualCapacity, (long,long)[] buy, (long,long)[] sell, long maxCapacity,long money, long index)
        {
            if(index == sell.Length || actualCapacity == 0)
            {
                long loss = Buy(maxCapacity,actualCapacity, buy);
                long profit = money - loss;
                return profit;
            }
            if (actualCapacity < sell[index].Item2)    return Sell(actualCapacity, buy, sell, maxCapacity, money, ++index);
            long bestProfit = Math.Max
            (
                // sell
                Sell(actualCapacity - sell[index].Item2, buy, sell, maxCapacity, money + (sell[index].Item1 * sell[index].Item2), ++index),
                // ignore
                Sell(actualCapacity ,buy , sell , maxCapacity , money, index)
            );
            return bestProfit;
        }

    }
 
    
}