using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DataStructure.Day1
{
    public class Demo
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var result = new List<IList<int>>();
            List<Tuple<int, int, int>> tuples = new List<Tuple<int, int, int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length - 1; j++)
                {
                    if (j == i) continue;

                    List<int> num = new List<int>();
                    if (nums[i] != nums[j] && nums[i] != nums[j + 1] && nums[j] != nums[j + 1] && nums[i] + nums[j] + nums[j + 1] == 0)
                    {
                        num.Add(nums[i]);
                        num.Add(nums[j]);
                        num.Add(nums[j + 1]);
                    }
                    if (num.Count > 0) result.Add(num);
                    //tuples.Add(new Tuple<int, int, int>(nums[i], nums[j], nums[j + 1]));
                }
            }
            //foreach (var item in tuples)
            //{
            //    List<int> num = new List<int>();
            //    if (item.Item1 + item.Item2 + item.Item3 == 0 && item.Item1 != item.Item2 && item.Item1 != item.Item3 && item.Item2 != item.Item3)
            //    {
            //        num.Add(item.Item1);
            //        num.Add(item.Item2);
            //        num.Add(item.Item3);
            //    }
            //    if (num.Count > 0) result.Add(num);
            //}

            return result;
        }

        public void ThreeSumNew(int[] nums)
        {
            var result = new List<IList<int>>();
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 1; j < nums.Length; j++)
                {
                    for (int m = 2; m < nums.Length; m++)
                    {
                        IList<int> data = new List<int>();
                        data.Add(i);
                        data.Add(j);
                        data.Add(m);
                        result.Add(data);
                    }
                }
            }
        }
    }
}
