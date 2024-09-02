using Algorithm.BaseAlgorithm;
using Algorithm.DataStructure.Day1;
using Algorithm.Demo;
using Algorithm.DesignModel;
using Algorithm.Model;
using Algorithm.StrategyModel;
using Algorithm.线性结构_栈;
using Algorithm.迭代器;
using Algorithm.链表结构;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TDengineDriver;
using TDengineWS.Impl;

namespace Algorithm
{
    internal class Program
    {
        #region OLD
        //static void Main(string[] args)
        //{
        //    int m = 5;
        //    int n = m;
        //    m = 7;
        //    Console.WriteLine(n);

        //    #region  冒泡算法
        //    //var mpDemo = new MPDemo((new int[] { 12, 15, 11, 18, 5, 9, 4 }));
        //    //mpDemo.Bubble();
        //    //Console.ReadLine();
        //    #endregion

        //    #region 插入算法
        //    //var insertDemo = new InsertAlgorithmDemo((new int[] { 12, 15, 11, 18, 5, 9, 4 }));
        //    //insertDemo.InsertAlgor();
        //    //Console.ReadLine();
        //    #endregion

        //    #region 桶模式
        //    //IPXAlgorithm insertDemo = new BucketAlgorithmDemo((new int[] { 12, 15, 11, 18, 5, 9, 4 ,17}));
        //    //insertDemo.PXSum();
        //    //Console.ReadLine();
        //    #endregion

        //    #region 快速排序
        //    var quickSort = new QuickSortAlgorithmDemo();
        //    quickSort.QuickAlgor(new int[] { 6, 1, 2, 7, 9, 3, 4, 5, 10, 8 }, 6, 8);
        //    Console.ReadLine();
        //    #endregion

        //    #region 01背包问题
        //    var bagSort = new BagAlgorithmDemo(new int[] {0,1,3,4 },new int[] {0,15,20,30 },4);
        //    bagSort.printDP();
        //    Console.ReadLine();
        //    #endregion

        //    #region 适配器模式(也可以策略模式)
        //    //ISortAlgorithm sortAlgorithm = new SortAdapter(new MPDemo((new int[] { 12, 15, 11, 18, 5, 9, 4 })));
        //    //sortAlgorithm.SortNum();
        //    //Console.ReadLine();
        //    #endregion


        //}
        #endregion
        //static void Main(string[] args)
        //{
        //    List<TbDayDataValue> tbDayDataValues = new List<TbDayDataValue>();
        //    for (int i = 0; i < 10000; i++)
        //    {
        //        tbDayDataValues.Add(new TbDayDataValue());
        //    }

        //    for (int i = 0; i < 1000; i++)
        //    {
        //        Parallel.ForEach(tbDayDataValues, new ParallelOptions() { MaxDegreeOfParallelism = 10 }, (item) =>
        //        {
        //            Console.WriteLine($"测试{Thread.CurrentThread.ManagedThreadId.ToString()}");
        //            Task.Delay(30*1000);

        //        }
        //      );
        //        //Console.WriteLine("没有等待");
        //    }

        //}

        #region 链表结构
        //static void Main(string[] args)
        //{
        //    #region
        //    //TreeNode treeNode1 = new TreeNode("1", "山东", "0");
        //    //TreeNode treeNode2 = new TreeNode("2", "北京", "0");

        //    //TreeNode treeNode3 = new TreeNode("3", "历下区", treeNode1);
        //    //TreeNode treeNode4 = new TreeNode("4", "高新区", treeNode1);
        //    //TreeNode treeNode5 = new TreeNode("5", "历城区", treeNode1);
        //    //TreeNode treeNode6 = new TreeNode("6", "甸柳庄", treeNode3);
        //    //TreeNode treeNode7 = new TreeNode("7", "济南长途汽车站东站", treeNode6);


        //    //TreeNode treeNode8 = new TreeNode("8", "朝阳区", treeNode2);
        //    //TreeNode treeNode9 = new TreeNode("9", "海淀区", treeNode2);
        //    //TreeNode treeNode10 = new TreeNode("10", "金盏乡", treeNode8);


        //    //List<TreeNode> list = new List<TreeNode>();

        //    //list.Add(treeNode1);
        //    //list.Add(treeNode2);
        //    //list.Add(treeNode3);
        //    //list.Add(treeNode4);
        //    //list.Add(treeNode5);
        //    //list.Add(treeNode6);
        //    //list.Add(treeNode7);
        //    //list.Add(treeNode8);
        //    //list.Add(treeNode9);
        //    //list.Add(treeNode10);

        //    //List<TreeNode> trees1 = TreeHelper.BulidTreeByRecursive(list, new List<TreeNode>(), "0");

        //    //List<TreeNode> trees = TreeHelper.BulidTree(list);
        //    #endregion

        //    List<Group> group = new List<Group>() {
        //        new Group() {Id=1,ParentId=0,GroupName="生物池1" },
        //        new Group() {Id=2,ParentId=1,GroupName="生物池1-2" },
        //        new Group() {Id=3,ParentId=1,GroupName="生物池3-4" },
        //        new Group() {Id=4,ParentId=2,GroupName="生物池2-4" },
        //        new Group() {Id=5,ParentId=2,GroupName="生物池2-4" },
        //    };
        //    var datass = GetLink(group, 0);

        //    //var dataTow = TreeHelper.BulidTree(group, 0);

        //}
        //public static List<LinkTree<Group>> GetLink(List<Group> groups, int parentId)
        //{
        //    List<LinkTree<Group>> linkTree = new List<LinkTree<Group>>();
        //    var data = groups.Where(x => x.ParentId == parentId).ToList();
        //    foreach (var item in data)
        //    {
        //        LinkTree<Group> treeNode = new LinkTree<Group>();
        //        treeNode.node = new Group();
        //        treeNode.node.Id = item.Id;
        //        treeNode.node.ParentId = item.ParentId;
        //        treeNode.node.GroupName = item.GroupName;
        //        treeNode.childrens = new List<LinkTree<Group>>();
        //        treeNode.childrens = GetLink(groups, item.Id);
        //        linkTree.Add(treeNode);
        //    }
        //    return linkTree;
        //}

        ///// <summary>
        ///// 双层循环
        ///// </summary>
        ///// <param name="treeNodes"></param>
        ///// <returns></returns>
        //public static List<LinkTree<Group>> BulidTree(List<Group> groups, int parentId)
        //{
        //    try
        //    {
        //        List<LinkTree<Group>> trees = new List<LinkTree<Group>>();

        //        foreach (var treeNode in groups)
        //        {
        //            LinkTree<Group> linkTree = new LinkTree<Group>();
        //            if (parentId == (treeNode.ParentId))
        //            {
        //                linkTree.node = new Group();
        //                linkTree.node.Id = treeNode.Id;
        //                linkTree.node.ParentId = treeNode.ParentId;
        //                linkTree.node.GroupName = treeNode.GroupName;
        //                trees.Add(linkTree);
        //            }
        //            else
        //            {

        //            }
        //            linkTree.childrens = new List<LinkTree<Group>>();
        //            foreach (var it in groups)
        //            {
        //                if (it.ParentId == treeNode.Id)
        //                {
        //                    LinkTree<Group> linkTrees = new LinkTree<Group>();
        //                    linkTrees.node = new Group();
        //                    linkTrees.node.Id = it.Id;
        //                    linkTrees.node.ParentId = it.ParentId;
        //                    linkTrees.node.GroupName = it.GroupName;
        //                    linkTree.childrens.Add(linkTrees);
        //                }
        //            }
        //            //trees.Add(linkTree);
        //        }
        //        return trees;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion

        #region 算法
        //static void Main(string[] args)
        //{

        //    SequencedStack<int> sequencedStack = new SequencedStack<int>();
        //    for (int i = 0; i < 5; i++)
        //    {
        //        sequencedStack.Push(i);
        //    }
        //    while (!sequencedStack.IsEmpty)
        //    {
        //        Console.WriteLine(sequencedStack.Pop());
        //    }
        //    Console.WriteLine();
        //    //var dataTow = TreeHelper.BulidTree(group, 0);

        //}
        #endregion

        #region 链表
        //static int Main(string[] args)
        //{
        //    string DSN = "ws://root:taosdata@127.0.0.1:6041/test";
        //    IntPtr wsConn = LibTaosWS.WSConnectWithDSN(DSN);

        //    if (wsConn == IntPtr.Zero)
        //    {
        //        Console.WriteLine("get WS connection failed");
        //        return -1;
        //    }
        //    else
        //    {
        //        Console.WriteLine("Establish connect success.");
        //        // close connection.
        //        LibTaosWS.WSClose(wsConn);
        //    }

        //    return 0;
        //}

        //static void Main(string[] args)
        //{
        //    Demo demo = new Demo();
        //    demo.ThreeSumNew(new int[] {0,1,2,3,4,5,6,7,8,9});
        //}
        //static void Main(string[] args)
        //{
        //    #region Old
        //    //ListNode listNode = new ListNode()

        //    //{ CurrentValue = 1, Next = new ListNode() { CurrentValue = 2, Next = new ListNode() { CurrentValue = 4 } } };

        //    //ListNode listNodeTow = new ListNode()
        //    //{ CurrentValue = 1, Next = new ListNode() { CurrentValue = 3, Next = new ListNode() { CurrentValue = 4 } } };
        //    ////Console.ReadLine();
        //    //var data = MergeLIstNode(listNode, listNodeTow);
        //    #endregion
        //    ListNode listNode = new ListNode()
        //    { CurrentValue = 1, Next = new ListNode() { CurrentValue = 4, Next = new ListNode() { CurrentValue = 5 } } };
        //    ListNode listNodeTow = new ListNode()
        //    { CurrentValue = 1, Next = new ListNode() { CurrentValue = 3, Next = new ListNode() { CurrentValue = 4 } } };
        //    ListNode listNodeThree = new ListNode()
        //    { CurrentValue = 2, Next = new ListNode() { CurrentValue = 6 } };
        //    ListNode[] listNodes = { listNode, listNodeTow, listNodeThree };

        //    var data = mergeKLists(listNodes);
        //    //var data = ChooseData(listNode);
        //}

        //static void Main(string[] args)
        //{
        //    //int[] arry = new int[] { 1, 4, 6, 20, 7, 8, 9, 3, 10, 6, 5, 13 };
        //    //XiErSore(arry.ToList());
        //    ListNode listNode = new ListNode() { CurrentValue = 5, Next = new ListNode() { CurrentValue = 1, Next = new ListNode() { CurrentValue = 0 } } };

        //    ListNode list = listNode;
        //    listNode = listNode.Next;
        //    listNode.CurrentValue = 7;
        //}

        //static void Main(string[] args)
        //{
        //    string longstring = longestPalindrome("babad");
        //}


        //static void Main(String[] args)
        //{
        //    #region 数据结构
        //    //值引用,不是地址引用
        //    int num = 1;
        //    int num2 = num;
        //    num = 3;
        //    Student student1 = new Student();
        //    Student student2 = new Student();
        //    student1 = student2;
        //    student2.Age = 15;
        //    student2.Name = "ceshi";
        //    student1.Dog = new Dog() { Color = "red" };


        //    //ListNode listNode = new ListNode() { CurrentValue = 5, Next = new ListNode { CurrentValue = 4, Next = new ListNode { CurrentValue = 3 } } };
        //    //ListNode listNodeNew = new ListNode() { CurrentValue = 3 };
        //    //listNodeNew = listNode.Next;// 这里是复制所有东西,并不是地址引用
        //    //listNode.Next = null;
        //    //listNode = listNodeNew;
        //    //listNode.Next = new ListNode() { CurrentValue = 5, Next = new ListNode { CurrentValue = 4 } };
        //    //ListNode team = new ListNode();
        //    //team = listNode;
        //    //listNode.Next = null;
        //    //listNode = team;
        //    //listNode = listNode.Next;

        //    //ListNode listNode = new ListNode() { CurrentValue = 1, Next = new ListNode() { CurrentValue = 2, Next = new ListNode() { CurrentValue = 3, Next = new ListNode { CurrentValue = 4 } } } };
        //    //ListNode newListNode = listNode.Next;
        //    //newListNode.Next = null;//这里是直接清掉引用数据



        //    //ListNode listNode = new ListNode() { CurrentValue = 1, Next = new ListNode() { CurrentValue = 2, Next = new ListNode() { CurrentValue = 3, Next = new ListNode { CurrentValue = 4 } } } };
        //    //ListNode newListNode = listNode.Next;
        //    //listNode.Next = listNode.Next.Next;//这里是指针清空,数据还在内存中  (都是指针引用)
        //    //listNode.Next.Next = null;
        //    //newListNode = newListNode.Next;
        //    //newListNode.Next = newListNode.Next.Next;  
        //    #endregion

        //    DictionaryCs<string, string> dictionary = new DictionaryCs<string, string>();
        //    dictionary.Add("jack","abc");
        //    Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            
        //}
        #endregion

        //    static void Main(string[] args)
        //{
        //    for (int i = 0; i < 900; i++)
        //    {
        //        Task.Delay(1000).Wait();
        //        Console.WriteLine(i);
        //    }
        //    Console.ReadLine();
        //}

        static void Main(string[] args)
        {
            ListNode listNode = new ListNode() { CurrentValue = 1, Next = new ListNode() { CurrentValue = 2, Next = new ListNode() { CurrentValue = 3, Next = new ListNode() { CurrentValue = 4, Next = new ListNode() { CurrentValue = 5, Next = new ListNode() { CurrentValue = 6 } } } } } };
            var newNode = reverse(listNode);

            //var newNode = reverseN(listNode, 3);

            //var newNodes = reverseBetween(listNode, 3, 4);

            int sum = GetFibonacciNumber(5);
        }

            //static void Main(string[] args)
            //{
            //    //for (int i = 0; i < 120; i++)
            //    //{
            //    //    Task.Delay(1000).Wait();
            //    //    Console.WriteLine($"倒计时{i}");
            //    //}
            //    //Console.ReadLine();
            //    SingleModel singleModel = new SingleModel();
            //    //var mm = singleModel.CreateSingleModel();

            //}

        public static ListNode MergeLIstNode(ListNode node, ListNode nodeTwo)
        {
            //里面的引用类型一直变
            // linux
            ////先按照自己的意思穷举出来
            ListNode listNode = new ListNode();
            ListNode listNodeNew = new ListNode();


            listNode = listNodeNew;
            while (node != null && nodeTwo != null)
            {
                if (node.CurrentValue > nodeTwo.CurrentValue)
                {
                    listNode.Next = nodeTwo;
                    nodeTwo = nodeTwo.Next;
                }
                else
                {
                    listNode.Next = node;
                    node = node.Next;
                }
                listNode = listNode.Next;//这里为什么listNodeNew没有改变(很难理解)https://blog.csdn.net/qq_42856647/article/details/106967889
                //https://www.shuzhiduo.com/A/x9J222WgJ6/值类型，引用类型比较
            }
            if (node != null)
            {
                listNode.Next = node;
            }

            if (nodeTwo != null)
            {
                listNode.Next = nodeTwo;
            }
            return listNodeNew.Next;
        }

        /// <summary>
        /// 无序列表,单链表的分解
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static ListNode ChooseData(ListNode node)
        {
            int x = 3;
            ListNode left = new ListNode();
            ListNode leftNew = left;
            ListNode right = new ListNode();
            ListNode rightNew = right;
            //先分割成两个链表，再合并成一个链表
            while (node != null)
            {
                if (node.CurrentValue >= 3)
                {
                    right.Next = node;
                    right = right.Next;
                }
                else
                {
                    left.Next = node;
                    left = left.Next;
                }
                // 断开原链表中的每个节点的 next 指针
                ListNode temp = node.Next; //精妙之处在这里
                node.Next = null;
                node = temp;
                //node = node.Next;
            }
            left.Next = rightNew.Next;
            //left.Next = rightNew;
            return leftNew.Next;
        }

        /// <summary>
        /// 合并k个有序列表
        /// </summary>
        /// <param name="lists"></param>
        /// <returns></returns>
        public static ListNode MergeKLists(ListNode[] lists)
        {
            if (lists != null && lists.Length <= 1)
            {
                return lists[0];
            }
            int length = 0;
            ListNode listNode = lists[length];
            while (lists.Length - length > 1) //当位置大于
            {
                listNode = MergeLIstNode(listNode, lists[length++]);
                length++;
            }
            return listNode;
        }

        public static ListNode mergeKLists(ListNode[] lists)
        {
            //分治思想
            if (lists.Length == 0)
                return null;
            if (lists.Length == 1)
                return lists[0];
            if (lists.Length == 2)
            {
                return mergeTwoLists(lists[0], lists[1]);
            }

            int mid = lists.Length / 2;//分治思想,越来越少
            ListNode[] l1 = new ListNode[mid];
            for (int i = 0; i < mid; i++)
            {
                l1[i] = lists[i];
            }

            ListNode[] l2 = new ListNode[lists.Length - mid];
            for (int i = mid, j = 0; i < lists.Length; i++, j++)
            {
                l2[j] = lists[i];
            }
            return mergeTwoLists(mergeKLists(l1), mergeKLists(l2));
        }

        public static ListNode mergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;

            ListNode head = null;
            if (l1.CurrentValue <= l2.CurrentValue)
            {
                head = l1;
                head.Next = mergeTwoLists(l1.Next, l2);
            }
            else
            {
                head = l2;
                head.Next = mergeTwoLists(l1, l2.Next);
            }
            return head;
        }


        /// <summary>/// 希尔排序 从小到大/// </summary>
        private static void XiErSore(List<int> Nums)
        {
            //增量从一半开始，慢慢缩减，最小至为1
            for (int AddCount = Nums.Count / 2; AddCount > 0; AddCount /= 2)
            { //从增量开始，逐个对其所在组进行插入排序
                for (int i = AddCount; i < Nums.Count; i++)
                {
                    int j = i - AddCount;
                    while (j >= 0 && Nums[j] > Nums[j + AddCount])//对每组进行排序
                    {
                        Swap(Nums, j, j + AddCount);
                        j -= AddCount;
                    }
                    //if (Nums[j] > Nums[j + AddCount])
                    //{
                    //    Swap(Nums, j, j + AddCount);
                    //}
                }
            }
        }

        /// <summary>
        /// 希尔排序
        /// 在插入排序的基础上加入了分组策略
        /// 将数组序列分成若干子序列分别进行插入排序
        /// 测试用例： 49 38 65 32
        /// gap = 2;
        /// i = 2, j = 0; a[0] > a[2] NO
        /// i = 3, j = 1; a[1] > a[3] YES 交换 49 32 65 38
        /// 
        /// gap = 1;
        /// i = 1, j = 0; a[0] > a[1] YES 交换 32 49 65 38
        /// i = 2, j = 1; a[1] > a[2] NO
        /// i = 3, j = 2; a[2] > a[3] YES 交换 32 49 38 65
        /// i = 3, j = 1; a[1] > a[2] YES 交换 32 38 49 65
        /// i = 3, j = 0; a[0] > a[1] NO
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="length"></param>
        private static void ShellSort(int[] arr, int length)
        {
            for (int gap = length / 2; gap > 0; gap = gap / 2)
            {
                //插入排序
                for (int i = gap; i < length; i++)
                {
                    for (int j = i - gap; j >= 0 && arr[j] > arr[j + gap]; j -= gap)
                    {
                        //Swap(ref arr[j], ref arr[j + gap]);交换数据
                    }
                }
            }
        }

        /// <summary>/// 交换数据/// </summary>
        private static void Swap(List<int> Nums, int index1, int index2)
        {
            int temp = Nums[index1];
            Nums[index1] = Nums[index2];
            Nums[index2] = temp;
        }


        private static int Search_bin(int[] ST, int key)//折半查找,一直缩小范围(仅限于有序的查找)
        {
            int low = 1; int high = ST.Length;  //置区间初值
            while (low <= high)
            {
                int mid = (low + high) / 2;
                if (ST[mid] == key) return mid;//知道待查元素
                else if (key < ST[mid])//缩小查找区间
                    high = mid - 1; //继续在前半区找
                else low = mid + 1;  //继续在后半区找
            }
            return 0;    //时间复杂度  log2n+1(2是底数,n的对数) 
        }


        //折半插入就是先用折半查找的方式先找到其插入的位置,然后对其进行for循环移动其位置，然后空出来位置进行插入（折半插入适用于有序列表）

        //        void main()
        //        {
        //            QSort(L, 1, L.length)
        //}

        void QSort(int[] L, int low, int high)  //快速排序适用于无序列表（找中心点，然后左右两边进行递归进行重复操作）
        {        //对顺序表L快速排序
            if (low < high)
            {   //长度大于1
                int pivotloc = Partition(L, low, high);//找中心点
                //将L.r[low....high]一分为2，pivotloc为中心元素排好序的位置
                QSort(L, low, pivotloc - 1);//对低子表递归排序
                QSort(L, pivotloc + 1, high);//对高子表递归排序
            }
        }

        int Partition(int[] L, int low, int high)//比右边小,比左边大,这就是唯一中心点
        {
            L[0] = L[low];
            int pivotkey = L[low];
            while (low < high)
            {
                while (low < high && L[high] >= pivotkey)
                    --high;
                L[low] = L[high];
                while (low < high && L[high] <= pivotkey)
                    ++low;
                L[low] = L[high];
            }
            L[low] = L[0];
            return low;
        }



        // 返回链表的倒数第 k 个节点
        ListNode findFromEnd(ListNode head, int k)
        {
            ListNode p1 = head;
            // p1 先走 k 步
            for (int i = 0; i < k; i++)
            {
                p1 = p1.Next;
            }
            ListNode p2 = head;
            // p1 和 p2 同时走 n - k 步
            while (p1 != null)
            {
                p2 = p2.Next;
                p1 = p1.Next;
            }
            // p2 现在指向第 n - k + 1 个节点，即倒数第 k 个节点
            return p2;
        }


        // 主函数
        public ListNode removeNthFromEnd(ListNode head, int n)
        {
            // 虚拟头结点
            ListNode dummy = new ListNode();
            dummy.Next = head;
            // 删除倒数第 n 个，要先找倒数第 n + 1 个节点
            ListNode x = findFromEnd(dummy, n + 1);
            // 删掉倒数第 n 个节点
            x.Next = x.Next.Next;
            return dummy.Next;
        }

        //单链表的中点 (快慢指针操作)
        ListNode middleNode(ListNode head)
        {
            // 快慢指针初始化指向 head
            ListNode slow = head, fast = head;
            // 快指针走到末尾时停止
            while (fast != null && fast.Next != null)
            {
                // 慢指针走一步，快指针走两步
                slow = slow.Next;
                fast = fast.Next.Next;
            }
            // 慢指针指向中点
            return slow;
        }

        //https://labuladong.github.io/algo/di-ling-zh-bfe1b/shuang-zhi-0f7cc/#判断链表是否包含环(也是快慢指针问题)
        bool hasCycle(ListNode head)
        {
            // 快慢指针初始化指向 head
            ListNode slow = head, fast = head;
            // 快指针走到末尾时停止
            while (fast != null && fast.Next != null)
            {
                // 慢指针走一步，快指针走两步
                slow = slow.Next;
                fast = fast.Next.Next;
                // 快慢指针相遇，说明含有环
                if (slow == fast)
                {
                    return true;
                }
            }
            // 不包含环
            return false;
        }

        //当然，这个问题还有进阶版：如果链表中含有环，如何计算这个环的起点？
        ListNode detectCycle(ListNode head)
        {
            ListNode fast, slow;
            fast = slow = head;
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
                if (fast == slow) break;
            }
            // 上面的代码类似 hasCycle 函数
            if (fast == null || fast.Next == null)
            {
                // fast 遇到空指针说明没有环
                return null;
            }

            // 重新指向头结点
            slow = head;
            // 快慢指针同步前进，相交点就是环起点
            while (slow != fast)
            {
                fast = fast.Next;
                slow = slow.Next;
            }
            return slow;
        }

        //https://labuladong.github.io/algo/di-ling-zh-bfe1b/shuang-zhi-0f7cc/#两个链表是否相交
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {

            // p1 指向 A 链表头结点，p2 指向 B 链表头结点
            ListNode p1 = headA, p2 = headB;
            while (p1 != p2)
            {
                // p1 走一步，如果走到 A 链表末尾，转到 B 链表
                if (p1 == null) p1 = headB;
                else p1 = p1.Next;
                // p2 走一步，如果走到 B 链表末尾，转到 A 链表
                if (p2 == null) p2 = headA;
                else p2 = p2.Next;
            }
            return p1;
        }


        //数组问题中比较常见的快慢指针技巧，是让你原地修改数组(有序链表)
        int removeDuplicates(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }
            int slow = 0, fast = 0;
            while (fast < nums.Length)
            {
                if (nums[fast] != nums[slow])
                {
                    slow++;
                    // 维护 nums[0..slow] 无重复
                    nums[slow] = nums[fast];
                }
                fast++;
            }
            // 数组长度为索引 + 1
            return slow + 1;
        }

        //删除排序链表中的重复元素
        ListNode deleteDuplicates(ListNode head)
        {
            if (head == null) return null;
            ListNode slow = head, fast = head;
            while (fast != null)
            {
                if (fast.CurrentValue != slow.CurrentValue)
                {
                    // nums[slow] = nums[fast];
                    slow.Next = fast;
                    // slow++;
                    slow = slow.Next;
                }
                // fast++
                fast = fast.Next;
            }
            // 断开与后面重复元素的连接
            slow.Next = null;
            return head;
        }

        //除了让你在有序数组/链表中去重，题目还可能让你对数组中的某些元素进行「原地删除」
        int removeElement(int[] nums, int val)
        {
            int fast = 0, slow = 0;
            while (fast < nums.Length)
            {
                if (nums[fast] != val)
                {
                    nums[slow] = nums[fast];
                    slow++;
                }
                fast++;
            }
            return slow;
        }

        // 实现了这个 removeElement 函数，接下来看看力扣第 283 题
        void moveZeroes(int[] nums)
        {
            // 去除 nums 中的所有 0，返回不含 0 的数组长度
            int p = removeElement(nums, 0);
            // 将 nums[p..] 的元素赋值为 0
            for (; p < nums.Length; p++)
            {
                nums[p] = 0;
            }
        }

        //两数之和
        int[] twoSum(int[] nums, int target)
        {
            // 一左一右两个指针相向而行
            int left = 0, right = nums.Length - 1;
            while (left < right)
            {
                int sum = nums[left] + nums[right];
                if (sum == target)
                {
                    // 题目要求的索引是从 1 开始的
                    return new int[] { left + 1, right + 1 };
                }
                else if (sum < target)
                {
                    left++; // 让 sum 大一点
                }
                else if (sum > target)
                {
                    right--; // 让 sum 小一点
                }
            }
            return new int[] { -1, -1 };
        }

        //反转字符串
        void reverseString(char[] s)
        {
            // 一左一右两个指针相向而行
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                // 交换 s[left] 和 s[right]
                char temp = s[left];
                s[left] = s[right];
                s[right] = temp;
                left++;
                right--;
            }
        }

        //回文串判断
        bool isPalindrome(String s)
        {
            // 一左一右两个指针相向而行
            int left = 0, right = s.Length - 1;
            while (left < right)
            {
                if (s.CharAt(left) != s.CharAt(right))
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }


        // 在 s 中寻找以 s[l] 和 s[r] 为中心的最长回文串
        static string palindrome(String s, int l, int r)
        {
            // 防止索引越界
            while (l >= 0 && r < s.Length
                    && s.CharAt(l) == s.CharAt(r))
            {
                // 双指针，向两边展开
                l--; r++;
            }
            // 返回以 s[l] 和 s[r] 为中心的最长回文串
            return s.Substring(l + 1, r);
        }

        static string longestPalindrome(String s)
        {
            string res = "";
            for (int i = 0; i < s.Length; i++)
            {
                // 以 s[i] 为中心的最长回文子串
                string s1 = palindrome(s, i, i);
                // 以 s[i] 和 s[i+1] 为中心的最长回文子串
                string s2 = palindrome(s, i, i + 1);
                // res = longest(res, s1, s2)
                res = res.Length > s1.Length ? res : s1;
                res = res.Length > s2.Length ? res : s2;
            }
            return res;
        }

        // 定义：输入一个单链表头结点，将该链表反转，返回新的头结点
        static ListNode reverse(ListNode head)
        {
            if (head == null || head.Next == null)
            {
                return head;
            }
            ListNode last = reverse(head.Next);//后序遍历
            head.Next.Next = head;
            head.Next = null;
            return last;
        }


        static ListNode successor = null; // 后驱节点

        // 反转以 head 为起点的 n 个节点，返回新的头结点
        static ListNode reverseN(ListNode head, int n)
        {
            if (n == 1)
            {
                // 记录第 n + 1 个节点
                successor = head.Next;
                return head;
            }
            // 以 head.next 为起点，需要反转前 n - 1 个节点
            ListNode last = reverseN(head.Next, n - 1);// 后续遍历

            head.Next.Next = head;
            // 让反转之后的 head 节点和后面的节点连起来l
            head.Next = successor;
            return last;
        }


        static ListNode reverseBetween(ListNode head, int m, int n)
        {
            // base case
            if (m == 1)
            {
                return reverseN(head, n);//遍历+遍历
            }
            // 前进到反转的起点触发 base case
            head.Next = reverseBetween(head.Next, m - 1, n - 1);
            return head;
        }

        /** 反转区间 [a, b) 的元素，注意是左闭右开 */
        static ListNode reverseDD(ListNode a, ListNode b)
        {
            ListNode pre, cur, nxt;
            pre = null; cur = a; nxt = a;
            // while 终止的条件改一下就行了
            while (cur != b)
            {
                nxt = cur.Next;
                cur.Next = pre;
                pre = cur;
                cur = nxt;
            }
            // 返回反转后的头结点
            return pre;
        }


        static ListNode reverseKGroup(ListNode head, int k)
        {
            if (head == null) return null;
            // 区间 [a, b) 包含 k 个待反转元素
            ListNode a, b;
            a = b = head;
            for (int i = 0; i < k; i++)
            {
                // 不足 k 个，不需要反转，base case
                if (b == null) return head;
                b = b.Next;
            }
            // 反转前 k 个元素
            ListNode newHead = reverseDD(a, b);
            // 递归反转后续链表并连接起来
            a.Next = reverseKGroup(b, k);
            return newHead;
        }

        public static int GetFibonacciNumber(int index)
        {
            if (index < 1)
                return -1;
            if (index == 1)
                return 1;
            if (index == 2)
                return 1;
            int result = GetFibonacciNumber(index - 1) + GetFibonacciNumber(index - 2);
            return result;
        }
    }

    //获取最长回文参数
    public static class CharAtExtention
    {
        public static string CharAt(this string s, int index)
        {
            if ((index >= s.Length) || (index < 0))
                return "";
            return s.Substring(index, 1);
        }
    }

    public class Student
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public Dog Dog { get; set; }
    }

    public class Dog
    {
        public string Color { get; set; }
    }
}
