using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.BaseAlgorithm
{
    public class BucketAlgorithmDemo : IPXAlgorithm
    {
        protected int[] _arr;    //二分治法      (先找到最小值,最大值)     桶数量=(最大值-最小值)/桶大小+1               将数据放入桶中,(确定index)((array[1]-min)/桶大小),放完之后, 循环排序,
        public BucketAlgorithmDemo(int[] arr)
        {
            _arr = arr;
        }

        /// <summary>
        /// 桶装排序
        /// </summary>
        /// <param name="array">数据源</param>
        /// <param name="len">数组长度</param>
        /// <param name="bucketsize">桶大小</param>
        public void bucketSort(int len, int bucketsize = 4)
        {
            int[] array = _arr;
            // 获取数组最大值与最小值
            (int max, int min) = FindMaxAndMin(array, len);
            List<List<int>> buckets = new List<List<int>>();
            // 分配的桶数量
            int bucketnum = (max - min) / bucketsize + 1;
            // 初始化桶
            for (int i = 0; i < bucketnum; i++)
            {
                buckets.Add(new List<int>());
            }
            // 将数据放在对应的桶里
            for (int i = 0; i < len; i++)
            {
                // 寻桶位置
                int bucketIndex = (array[i] - min) / bucketsize;
                buckets[bucketIndex].Add(array[i]);
            }
            int index = 0;
            for (int i = 0; i < buckets.Count; i++)
            {
                // 对每个桶排序(可以使用其它排序，例如快排)
                buckets[i].Sort();
                for (int j = 0; j < buckets[i].Count; j++)
                {
                    array[index++] = buckets[i][j];
                }
            }
            foreach (var item in _arr)
            {
                Console.WriteLine(item);
            }
        }
        public (int, int) FindMaxAndMin(int[] array, int len)
        {
            (int min, int max) = (array[0], array[0]);
            for (int i = 1; i < len; i++)
            {
                min = Math.Min(min, array[i]);
                max = Math.Max(max, array[i]);
            }
            return (max, min);
        }

        public void PXSum()
        {
            bucketSort(8);
        }
    }
}
