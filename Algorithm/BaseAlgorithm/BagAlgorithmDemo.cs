using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.BaseAlgorithm
{
    //01背包问题
    public class BagAlgorithmDemo
    {
        private int[] _weight;
        private int[] _value;
        private int _bag;

        public BagAlgorithmDemo(int[] weight, int[] value, int bag)
        {
            _weight = weight;
            _value = value;
            _bag = bag;
        }

        //每个物品只有一个
        public void printDP()
        {
            int[] weight = _weight; int[] value = _value; int bag = _bag;
            // dp[i][j]: 选择前ｉ个物品装入背包重量为ｊ的最大价值
            //int[][] dp = new int[weight.Length][bag+1];
            int[,] dp = new int[weight.Length, bag + 1];
            // 初始化dp数组 需要初始化第一行和第一列
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i, 0] = 0;
            }
            for (int j = 1; j <= bag; j++)
            {
                if (weight[0] <= j)
                    dp[0, j] = value[0];
                else dp[0, j] = 0;
            }
            // 完善dp数组
            for (int i = 1; i < dp.Length; i++)
            {
                for (int j = 1; j <= bag; j++)
                {
                    if (weight[i] > j)
                    {
                        dp[i, j] = dp[i - 1, j];
                    }
                    else
                    {
                        dp[i, j] = Math.Max(value[i] + dp[i - 1, j - weight[i]], dp[i - 1, j]);
                    }
                }
            }
            for (int i = 0; i < dp.Length; i++)
            {
                for (int j = 0; j <= bag; j++)
                {
                    Console.WriteLine((dp[i, j] + " "));
                }
            }
        }
    }
}
