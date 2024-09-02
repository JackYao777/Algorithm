using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.顺序结构模式
{
    /// <summary>
    /// 线性关系表中的顺序结构  查找,插入,删除算法的平均时间复杂度为O(n)
    /// 优点:1.存储密度大（结点本身所占存储量/结点结构所占存储量）
    /// 缺点： 为了克服这一缺点 ——————> 链表
    ///1.在读入、删除某一元素时，需要移动大量元素
    ///3.属于静态存储形式、数据元素的个数不能自由扩充
    /// </summary>
    public class SqList
    {
        public object[] element;
        public int length;
    }

    public class ArrayNew:IDisposable
    {
        //private object[] _array { get; set; }
        //private int _lenth { get; set; }
        /// <summary>
        /// 初始化空间
        /// </summary>
        /// <param name="array"></param>
        public bool InitialSqList(SqList sqList)
        {
            sqList.element = (object[])new string[100];
            sqList.length = 0;
            return true;
        }

        public bool DeleteSqlList(SqList sqList)
        {
            return true;
        }
        /// <summary>
        /// 获取元素对象
        /// </summary>
        /// <param name="sqList">对象</param>
        /// <param name="i">获取第几个元素</param>
        /// <param name="ele">元素</param>
        /// <returns></returns>
        public bool GetElem(SqList sqList, int i, string ele)
        {
            if (0 < i && i < sqList.length)
            {
                ele = sqList.element[i - 1].ToString();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 查到数据在结构中是否存在,不存在返回0,存在返回1
        /// </summary>
        /// <param name="sqList"></param>
        /// <param name="ele"></param>
        /// <returns></returns>
        public int LocalElement(SqList sqList, string ele)
        {
            for (int i = 0; i < sqList.length; i++)
            {
                if (sqList.element[i].ToString() == ele) return i + 1;
            }
            return 0;
        }

        /// <summary>
        /// 想结构中随机插入一条数据
        /// </summary>
        /// <param name="sqList"></param>
        /// <param name="i"></param>
        /// <param name="ele"></param>
        /// <returns></returns>
        public bool InsertElement(SqList sqList, int i, string ele)
        {
            if (0 < i && i < sqList.length)
            {
                #region Old //
                //for (int m = sqList.length; i <= m; m--)
                //{
                //    if (i == m)
                //    {
                //        sqList.element[m] = ele;
                //        return true;
                //    }
                //    sqList.element[m] = sqList.element[m - 1].ToString();
                //}
                #endregion
                for (int j = sqList.length - 1; j >= i - 1; j--)
                {
                    sqList.element[j + 1] = sqList.element[j];
                }
                sqList.element[i - 1] = ele;
                sqList.length++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 向某个地址删除数据
        /// </summary>
        /// <param name="sqList"></param>
        /// <param name="i"></param>
        /// <param name="ele"></param>
        /// <returns></returns>
        public bool DeleteElement(SqList sqList, int i, string ele)
        {
            if (0 < i && i < sqList.length)
            {
                #region Old  
                //for (int m = sqList.length; i <= m; m--)
                //{
                //    if (i == m)
                //    {
                //        sqList.element[m] = ele;
                //        return true;
                //    }
                //    sqList.element[m] = sqList.element[m - 1].ToString();
                //}
                #endregion
                for (int j = i; j < sqList.length - 1; j++)
                {
                    sqList.element[j - 1] = sqList.element[j];
                }
                sqList.length--;
                return true;
            }
            return false;
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}
