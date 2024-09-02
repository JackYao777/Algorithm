using DataStruct.新文件夹;
using DataStruct.栈;
using System.Text.Json;

namespace DataStruct
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            DerivedClass.Ceshi();


            ArrayStack<int> arrayStack = new ArrayStack<int>(4);
            arrayStack.Push(1);
            arrayStack.Push(2);
            arrayStack.Push(3);
            arrayStack.Push(4);
            Console.WriteLine(arrayStack.Peek());
            Console.WriteLine(arrayStack.Pop());


            Func<int, int, int> caculator = (a, b) => { return a + b; };
            Console.WriteLine(caculator(5, 7));

            //int sum = Sum(31);

            int n = 1;
            int seats = 120;
            int sumSeats = 0;//1376
            while (n <= 17)
            {
                sumSeats += 120 - 4 * (17 - n);
                n++;
            }

            await Task.Factory.StartNew(() => { });
            await Task.Run(() => { });
            ThreadPool.QueueUserWorkItem((obj) => { });

            MyClass myClass = new MyClass();
            await myClass.MyAsyncMethod();
        }

        //1,1,2,3,5,8,13
        public static int Sum(int num)
        {
            if (num == 1 || num == 2)
            {
                return 1;
            }
            else
            {
                return Sum(num - 1) + Sum(num - 2);
            }
        }


        public class MyClass
        {
            public async Task MyAsyncMethod()
            {
                // 模拟异步操作
                await Task.Delay(1000);

                // 异步操作完成后的逻辑
                Console.WriteLine("异步方法执行完成！");
            }
        }
        //public static int PrintArithmeticSeries(int firstTerm, int commonDifference, int n)
        //{
        //    if (n <= 0)
        //        return 0;

        //    Console.Write(firstTerm + " ");

        //    int nextTerm = firstTerm + commonDifference;

        //    PrintArithmeticSeries(nextTerm, commonDifference, n - 1);


        //}
    }
}