using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyList_SAOD
{
    public class MyList<T>  where T: IEquatable<T> //могу сравнивать элементы типа <T>
    {
        ListNode<T> first; //первый элемент
        ListNode<T> last; //последний элемент
        int count = 0; //кол-во элементов


        public void Append(T val) //добавление элемента в конец. (Next, Prev, Value)
        {
            if (first == null)
            {
                first = new ListNode<T>(null, null, val); //создает новый элемент, записывается в переменную первой
                last = first; //из-за того, что один элемент, он первый и последний
            }

            else
            {
                ListNode<T> tmp = new ListNode<T>(null, last, val); //создает новый элемент
                last.Next = tmp; //меняю ссылку пред на след
                last = tmp; //последний эл становится тем, который добавил
            }

            count++;
        }

        public void Prepend(T val) //Добавление в начало.
        {
            if (first == null)
            {
                first = new ListNode<T>(null, null, val);
                last = first;
            }
            else
            {
                ListNode<T> tmp = new ListNode<T>(first, null, val);
                first.Prevs = tmp; //меняю ссылку на пред элемент
                first = tmp; //добавленный эл становится первым
            }
            count++;

        }

        public void Insert(T val, int index) // Добавление в середину.
        {
            int col = 0; //счетчик
            ListNode<T> tmp = first; //сохранение 1го элемента в tmp

            while (col != index) //счетчик = индекс
            {
                if (tmp == null) //проверка (если нет 1го элемента, то не можешь)
                {
                    throw new Exception();
                }

               tmp = tmp.Next; //след элемент
                col++;
            }

            ListNode<T> tmp_p = new ListNode<T>(tmp, tmp.Prevs, val); //когда нашел куда добавлять
            tmp.Prevs.Next = tmp_p; //меняю ссылку пред эл на след
            tmp.Prevs = tmp_p; //пред эл меняю на добавленный

            count++;
        }

        public int Find(T val) // Возвращать позицию элемента. Индекс элемента с этим значением.
        {
            ListNode<T> tmp = first;
            int col = 0;

            while (!tmp.Value.Equals(val)) //equals позволяет сравнивать значения типа <T>
            {
                if (tmp.Next == null)
                {
                    throw new Exception();
                }
                tmp = tmp.Next;
                col++;
            }
            return col; //возрат индекса элемента
        }

        public T At(int index) // Значение элемента. Если на этой позиции нет, то ошибка.
        {
            if(index < 0 || index > count-1) // || <--- или
            {
                throw new Exception();
            }

            int col = 0;
            ListNode<T> tmp = first; //tmp - значение

            while (col != index)
            {
                tmp = tmp.Next; //сохраняю значение
                col++;
            }

            return tmp.Value;
        }

        public bool Remove(T val) // По значению.
        {
            ListNode<T> tmp = first;

            while (!tmp.Value.Equals(val)) // ! <--- пока значение tmp != введенному значению
            {
                if (tmp.Next == null)
                {
                    return false;
                }

                else
                {
                    tmp = tmp.Next;
                }
            }
            if (tmp.Next == null && tmp.Prevs == null) //&& <-- and
            {
                first = last = null; // 1 = 2 и удаляем
            }
            else if (tmp.Prevs == null)
            {
                first = tmp.Next; //меняем ссылку 1эл
                tmp.Next.Prevs = null; //меняем ссылку 3эл
            }
            else if (tmp.Next == null)
            {
                last = tmp.Prevs;
                tmp.Prevs.Next = null; //у след эл нет пред
            }
            else
            {
                tmp.Prevs.Next = tmp.Next;
                tmp.Next.Prevs = tmp.Prevs;
            }
            count--;
            return true;
        }

        public bool RemoveAt(int index) // По индексу. тоже самое Remove, только по индексу
        {
            int col = 0;
            ListNode<T> tmp = first;

            while (col != index)
            {
                if (tmp.Next == null)
                {
                    return false;
                }
                else
                {
                    tmp = tmp.Next;
                    col++;
                }
            }


            if (tmp.Next == null && tmp.Prevs == null)
            {
                first = last = null;
            }

            else if (tmp.Prevs == null)
            {
                tmp.Next.Prevs = null;
            }

            else if (tmp.Next == null)
            {
                tmp.Prevs.Next = null;
            }

            else
            {
                tmp.Prevs.Next = tmp.Next;
                tmp.Next.Prevs = tmp.Prevs;
            }

            count--;

            return true;
        }

        public override string ToString()
        {
            string str = "";
            ListNode<T> tmp_2 = first;
            str += first.Value + "\r\n";

            while (tmp_2.Next != null)
            {
                tmp_2 = tmp_2.Next;
                str += tmp_2.Value + "\r\n";
            }

            return str;
        }
    }
}
