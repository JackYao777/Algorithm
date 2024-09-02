using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.BaseAlgorithm
{
    public class MPDemo : IPXAlgorithm
    {
        protected int[] _arr;
        public MPDemo(int[] arr)
        {
            _arr = arr;
        }

        /// <summary>
        /// 冒泡算法  (故名思意,最小的放前面,最大的放后面)    时间复杂度分析：O(N^2)；   算法的稳定性：   算法适用的场合：

        //它适用于元素数量不多，并且基本有序的场合。（如果数量过多，冒泡排序速度比较慢）
        /// </summary>
        public void Bubble()
        {
            var flag = false;
            for (int i = 0; i < _arr.Length && flag; i++) // 这不是冒泡排序
            {
                flag = false;
                for (int j = i + 1; j < _arr.Length; j++)
                {
                    int teamValue = 0;
                    if (_arr[i] > _arr[j])
                    {
                        teamValue = _arr[i];
                        _arr[i] = _arr[j];
                        _arr[j] = teamValue;
                        flag = true;
                    }
                }
            }
            foreach (var item in _arr)
            {
                Console.WriteLine(item);
            }
        }

        public void PXSum()
        {
            Bubble();
        }


        /// <summary>
        /// 这个才是正在冒泡排序
        /// </summary>
        /// <param name="array"></param>
        public void BubbleSort(int[] array)
        {
            var flag = false;
            //int n = array.Length;

            // 遍历数组元素
            for (int i = 0; i < array.Length - 1 && flag; i++)
            {
                flag = false;
                // 在每次遍历中，通过比较相邻元素并交换位置，将最大元素“冒泡”到末尾
                for (int j = 1; j < array.Length - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        // 交换相邻元素的位置
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        flag = true;
                    }
                }
            }
        }

        /// <summary>
        /// 选择排序
        /// 在要排序的一组数中，选出最小的一个数与第i个位置的数交换，之后依次类推(i=0,1,2,3...)
        /// 测试用例：49 38 65 32
        /// i = 0，min = 3, 32 38 65 49
        /// i = 1, min = 1, 32 38 65 49
        /// i = 2, min = 3, 32 38 49 65
        /// </summary>
        private static void SelectSort(int[] arr, int length)
        {
            for (int i = 0; i < length - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < length; j++)
                {
                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                //当在此次遍历中，如果没有比arr[i]更小的值，则不用交换
                if (min != i)
                {
                    int temp = arr[i];
                    arr[i] = arr[min];
                    arr[min] = temp;
                    //Swap(ref arr[i], ref arr[min]);
                }
            }
        }
    }
}
