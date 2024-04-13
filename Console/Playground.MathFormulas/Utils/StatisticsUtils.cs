using System.Numerics;

namespace Playground.MathFormulas.Utils;

public static class StatisticsUtils
{
    public static decimal GetMean<T>(List<T> data) where T : INumberBase<T>
    {
        data.Sort();

        // even count
        if (data.Count % 2 == 0)
        {
            // in a dataset that has an a event count, mean is 
            // the average of (n / 2) and (n / 2) + 1

            var n1 = data.Count / 2;
            var n2 = (data.Count / 2) + 1;

            decimal n1InData = Convert.ToDecimal(data[n1 - 1]);
            decimal n2InData = Convert.ToDecimal(data[n2 - 1]);

            return Convert.ToDecimal((n1InData + n2InData) / 2);
        } 
        // odd count
        else
        {
            // in a dataset that has an a odd count, mean is at the (n + 1) / 2 index 
            int n = (data.Count + 1) / 2;

            // obvious that index of n, is n -1
            return Convert.ToDecimal(data[n - 1]);
        }
    }
}
