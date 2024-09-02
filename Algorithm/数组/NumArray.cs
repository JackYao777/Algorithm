using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.数组
{
    public class NumArray
    {
        // 前缀和数组
        private int[] preSum;  // 空间换时间

        /* 输入一个数组，构造前缀和 */
        public NumArray(int[] nums)
        {

            // preSum[0] = 0，便于计算累加和
            preSum = new int[nums.Length + 1];
            // 计算 nums 的累加和
            for (int i = 1; i < preSum.Length; i++)
            {
                preSum[i] = preSum[i - 1] + nums[i - 1];
            }
        }

        /* 查询闭区间 [left, right] 的累加和 */
        public int sumRange(int left, int right)
        {
            return preSum[right + 1] - preSum[left];
        }
    }
    public interface demo
    {
        //abstract void GetNum();
        //public int GetNum()
        //{
        //    return 1;
        //}
    }
}
