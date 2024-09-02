using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.字符串查找
{
    public class StringMatching
    {
        /// <summary>
        /// 暴力解法
        /// </summary>
        /// <returns></returns>
        public bool SearchIsManching(string[] txt, string[] pat)
        {
            for (int i = 0; i < txt.Length; i++)
            {
                for (int j = 0; j < pat.Length; j++)
                {
                    if (pat[j] != txt[j + 1])
                        break;
                    else if (j == pat.Length)
                        return true;
                }
            }

            return false;
        }
    }
}
