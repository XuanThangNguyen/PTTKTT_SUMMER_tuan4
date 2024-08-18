using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Knapsack
    {
        static int Knapsack1(int W, int[] wt, int[] val, int n, out List<int> items)
        {
            int i, w;
            int[,] K = new int[n + 1, W + 1];
            items = new List<int>();

            for (i = 0; i <= n; i++)
            {
                for (w = 0; w <= W; w++)
                {
                    if (i == 0 || w == 0)
                        K[i, w] = 0;
                    else if (wt[i - 1] <= w)
                        K[i, w] = Math.Max(val[i - 1] + K[i - 1, w - wt[i - 1]], K[i - 1, w]);
                    else
                        K[i, w] = K[i - 1, w];
                }
            }

            int res = K[n, W];
            w = W;
            for (i = n; i > 0 && res > 0; i--)
            {
                if (res != K[i - 1, w])
                {
                    items.Add(i);
                    res -= val[i - 1];
                    w -= wt[i - 1];
                }
            }

            return K[n, W];
        }

        public static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int[] val = { 60, 100, 120 };
            int[] wt = { 10, 20, 30 };
            int W = 50;
            int n = val.Length;
            List<int> items;

            int maxValue = Knapsack1(W, wt, val, n, out items);

            Console.WriteLine("Giá trị tối đa ba lô có thể mang : " + maxValue);
            Console.WriteLine("Đồ được mang :");
            foreach (int item in items)
            {
                Console.WriteLine("Item " + item + ": Giá trị = " + val[item - 1] + ", Cân nặng = " + wt[item - 1]);
            }
        }
    }
}
