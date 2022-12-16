using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList_SAOD
{
    internal class ListNode<T> where T : IEquatable<T> //Нельзя публичные.
    {
        T val; //значение
        ListNode<T> next; //Ссылка на следующий элемент.
        ListNode<T> prevs; //На предыдущий.

        public ListNode<T> Next
        {
            get { return next; }

            set { next = value; }
        }

        public T Value
        {
            get { return val; }

            set { val = value; }
        }

        public ListNode<T> Prevs
        {
            get { return prevs; }

            set { prevs = value; }
        }

        public ListNode(ListNode<T> t_next, ListNode<T> t_prevs, T t_value)
        {
            next = t_next;
            prevs = t_prevs;
            val = t_value;
        }
    }
}
