using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.BaseAlgorithm
{
    public class InsertAlgorithmDemo: IPXAlgorithm
    {
        private int[] _arr;
        public InsertAlgorithmDemo(int[] arr)
        {
            _arr = arr;
        }

        /// <summary>
        /// 冒泡算法  (故名思意,最小的放前面,最大的放后面)    时间复杂度分析：O(N^2)；   算法的稳定性：   算法适用的场合：

        //它适用于元素数量不多，并且基本有序的场合。（如果数量过多，冒泡排序速度比较慢）
        /// </summary>
        public void InsertAlgor()
        {
            for (int i = 1; i < _arr.Length; i++)
            {
                //if (_arr[i - 1] > _arr[i])
                //{
                    for (int j = i; j > 0; j--)
                    {
                        if (_arr[j - 1] > _arr[j])
                        {
                            Swap(_arr, j - 1, j);
                        }
                        else break;
                    }
                //}
            }
            foreach (var item in _arr)
            {
                Console.WriteLine(item);
            }
        }

        public void PXSum()
        {
            InsertAlgor();
        }

        public void Swap(int[] arr, int i, int j)
        {
            int team = arr[j];
            arr[j] = arr[i];
            arr[i] = team;
        }
    }
}
