using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.链表结构
{
    public class LinkTree<Node>
    {
        public Node node { get; set; }

        public List<LinkTree<Node>> childrens { get; set; }
    }

    public class Group
    {
        public int Id { get; set; }

        public int ParentId { get; set; }
        public string GroupName { get; set; }
    }



    //public class ListNode<T>
    //{
    //    public T Value { get; set; }
    //    public ListNode<T> Next { get; set; }

    //    public ListNode(T value)
    //    {
    //        Value = value;
    //        Next = null;
    //    }
    //}

    //public class LinkedList<T>
    //{
    //    private ListNode<T> head;
    //    private ListNode<T> tail;

    //    public LinkedList()
    //    {
    //        head = null;
    //        tail = null;
    //    }

    //    public void Add(T value)
    //    {
    //        var newNode = new ListNode<T>(value);
    //        if (head == null)
    //        {
    //            head = newNode;
    //            tail = newNode;
    //        }
    //        else
    //        {
    //            tail.Next = newNode;
    //            tail = newNode;
    //        }
    //    }

    //    public void Remove(T value)
    //    {
    //        if (head == null)
    //        {
    //            return;
    //        }

    //        if (head.Value.Equals(value))
    //        {
    //            head = head.Next;
    //            if (head == null)
    //            {
    //                tail = null;
    //            }
    //        }
    //        else
    //        {
    //            var current = head;
    //            while (current.Next != null)
    //            {
    //                if (current.Next.Value.Equals(value))
    //                {
    //                    current.Next = current.Next.Next;
    //                    if (current.Next == null)
    //                    {
    //                        tail = current;
    //                    }
    //                    break;
    //                }
    //                current = current.Next;
    //            }
    //        }
    //    }
    //}
}
