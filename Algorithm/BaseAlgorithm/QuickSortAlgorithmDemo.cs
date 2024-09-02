using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.BaseAlgorithm
{
    //https://blog.csdn.net/enternalstar/article/details/106932822
    //6 1 2 7 9 3 4 5 10 8
    public class QuickSortAlgorithmDemo
    {
        //protected int[] _arr;    //快速排序
        //public QuickSortAlgorithmDemo(int[] arr)
        //{
        //    _arr = arr;
        //}

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="array"></param>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void QuickAlgor(int[] array, int min, int max)
        {
            int key = array[min]; //数组的首位作为基数
            int start = min;      //从前往后遍历标识位
            int end = max;        //从后往前遍历标识位
            //两个标识位还未相遇，即基数的左边还未全小于基数，右边还未全大于基数
            while (end > start)
            {
                //从后往前遍历没有遇到比基数大的
                while (end > start && array[end] >= key)
                {
                    end--;
                }
                //当遇到比基数大时，互相交换位置
                if (key > array[end])
                {
                    int temp = array[end];
                    array[end] = array[start];
                    array[start] = temp;
                }
                //从前往后遍历，没有比新基数小的数
                while (end > start && array[start] <= key)
                {
                    start++;
                }
                //当遇到比新基数小时，互相交换位置
                if (key < array[start])
                {
                    int temp = array[start];
                    array[start] = array[end];
                    array[end] = temp;
                }
            }
            //此时基数的左边全小于基数，右边全大于基数，利用递归思路
            //排序左边部分
            if (start > min)
            {
                QuickAlgor(array, min, start - 1);
            }
            //排序右边部分
            if (end < max)
            {
                QuickAlgor(array, end + 1, max);
            }   

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
    }
}
