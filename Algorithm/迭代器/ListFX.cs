using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.迭代器
{
    public class ListFX<T>
    {
        private T[] array;
        private int count;

        public ListFX()
        {
            array = new T[4];
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public void Add(T item)
        {
            if (count == array.Length)
            {
                // 当数组已满时，创建一个新数组，将原数组中的元素复制到新数组中
                T[] newArray = new T[array.Length * 2];
                Array.Copy(array, newArray, array.Length);
                array = newArray;
            }

            array[count] = item;
            count++;
        }

        public void Remove(T item)
        {
            int index = Array.IndexOf(array, item, 0, count);
            if (index >= 0)
            {
                // 将后面的元素向前移动一个位置，覆盖要移除的元素
                Array.Copy(array, index + 1, array, index, count - index - 1);
                array[count - 1] = default(T); // 将最后一个位置置为默认值
                count--;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }
                return array[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }
                array[index] = value;
            }
        }
    }
    public class ExtendList
    {
        public static int IndexOf<T>(T[] array, T item, int startIndex, int count)
        {
            int endIndex = startIndex + count;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (EqualityComparer<T>.Default.Equals(array[i], item))
                {
                    return i;
                }
            }
            return -1;
        }

        public static void Copy(Array sourceArray, int sourceIndex, Array destinationArray, int destinationIndex, int length)
        {
            // 检查参数的有效性
            if (sourceArray == null || destinationArray == null)
            {
                throw new ArgumentNullException();
            }

            // 检查索引范围
            if (sourceIndex < 0 || destinationIndex < 0 || length < 0 ||
                sourceIndex + length > sourceArray.Length ||
                destinationIndex + length > destinationArray.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            // 获取元素类型
            Type elementType = sourceArray.GetType().GetElementType();

            // 判断是否为值类型，如果是，则使用内存块复制
            if (elementType.IsValueType)
            {
                Buffer.BlockCopy(sourceArray, sourceIndex * GetElementSize(elementType),
                    destinationArray, destinationIndex * GetElementSize(elementType),
                    length * GetElementSize(elementType));
            }
            else
            {
                // 如果是引用类型，则逐个复制元素
                for (int i = 0; i < length; i++)
                {
                    destinationArray.SetValue(sourceArray.GetValue(sourceIndex + i), destinationIndex + i);
                }
            }
        }

        private static int GetElementSize(Type elementType)
        {
            return Marshal.SizeOf(elementType);
        }
    }
 
}
