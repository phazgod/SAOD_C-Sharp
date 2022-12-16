using System;

namespace SAOD_Stack
{
    public class MyStack<T>
    {
        T[] array;
        int currentIndex = 0;

        public int Capacity //свойство, возвращающее вместимость стека (максимальное возможное количество элементов)
        {
            get
            {
                return array.Length;
            }
        }

        public MyStack(int capacity = 10) //кол-во элементов в массиве
        {
            array = new T[capacity];
        }

        public void Push(T val) //добавление элемента на верх стека
        {
            if (array.Length <= currentIndex)
            {
                throw new Exception("StackOverFlow");
            }
            else
            {
                array[currentIndex] = val;
                currentIndex++;
            }
        }

        public T Pop() //получение верхнего элемента и удаление его из стека
        {
            if (currentIndex == 0)
            {
                throw new Exception("StackUnderflow");
            }
            else
            {
                currentIndex--;
                T temp = array[currentIndex];
                array[currentIndex] = default(T);
                return temp;
            }
        }

        public T Top() //просмотр последнего добавленного элемента стека (без его удаления)
        {
            if (currentIndex == 0)
            {
                throw new Exception("StackUnderflow");
            }
            else
            {
                return array[currentIndex - 1];
            }
        }

        public override string ToString() //Преобразование в строку
        {
            string outp = "";
            for (int i = 0; i < currentIndex; i++)
            {
                outp += array[i].ToString() + "\r\n";
            }
            return outp;
        }
    }
}