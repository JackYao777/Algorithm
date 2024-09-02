using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sorting.Core
{
    public static class QuickSort
    {
        // 交换两个数的值
        private static void Swap(int x, int y) => (x, y) = (y, x);

        public static void SortIterator(List<int> list)
        {
            int start = 0;
            var end = list.Count - 1;
            if (start >= end)
            {
                return;
            }

            var stack = new Stack<int>();
            stack.Push(start);
            stack.Push(end);

            while (stack.Count > 0)
            {
                var max = stack.Pop();
                var min = stack.Pop();
                if (min >= max)
                {
                    continue;
                }


                var i = min;
                var j = max;
                var pivot = list[i];
                while (i < j)
                {
                    while (j > i && list[j] >= pivot)
                    {
                        j--;
                    }

                    list[i] = list[j];

                    while (i < j && list[i] <= pivot)
                    {
                        i++;
                    }

                    list[j] = list[i];
                }

                list[i] = pivot;

                stack.Push(j + 1);
                stack.Push(max);
                stack.Push(min);
                stack.Push(i - 1);
            }
        }

        public static int[] SortIterator2(int[] nums)
        {
            var start = 0;
            var end = nums.Length - 1;
            if (start >= end)
            {
                return nums;
            }
            var stack = new Stack<int>();
            stack.Push(start);
            stack.Push(end);
            while (stack.Count > 0)
            {
                var maxIndex = stack.Pop();
                var minIndex = stack.Pop();
                // 如果开始指针和结束指针重合或者偏移超过预期（大指针小于小指针） 就跳过本次的执行
                if (minIndex >= maxIndex) continue;
                var startIndex = minIndex;
                var endIndex = maxIndex;
                var poleValue = nums[startIndex];

                while (startIndex < endIndex)
                {
                    // 将大的值往后排
                    while (startIndex < endIndex && nums[endIndex] >= poleValue)
                    {
                        endIndex--;
                    }

                    nums[startIndex] = nums[endIndex];

                    // 将小的值往前排
                    while (startIndex < endIndex && nums[startIndex] <= poleValue)
                    {
                        startIndex++;
                    }

                    nums[endIndex] = nums[startIndex];
                }

                nums[startIndex] = poleValue;

                stack.Push(endIndex + 1);
                stack.Push(maxIndex);
                stack.Push(minIndex);
                stack.Push(startIndex - 1);
            }
            return nums;
        }
    }
}