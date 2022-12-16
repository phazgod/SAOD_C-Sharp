using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList_SAOD
{
    internal class ListEnumerator<T>: IEnumerator //Перебор коллекции. Для работы foreach.
    {
        T[] els;
        int position = -1; //Курсор позиции.

        public ListEnumerator(T[] els) => this.els = els;

        public object Current //Возвращает объект, на котором находится курсор.
        {
            get
            {
                if (position == -1 || position >= els.Length)
                {
                    throw new ArgumentException();
                }
                    
                return els[position]; //Возвращает элемент.
            }
        }

        public bool MoveNext() //Двигает курсор на след. позицию.
        {
            if (position < els.Length - 1)
            {
                position++;
                return true;
            }

            else
                return false;
        }

        public void Reset() => position = -1; //Возвращает курсор в начало.
    }
}

