using System;

namespace SAOD_Queue
{
    public class Queue<T>
    {
        T[] Array;
        int currentIn = 0; //Индекс на вход.
        int currentOut = 0; //Индекс на выход.
        int count = 0;

        public int Capacity
        {
            get{ return Array.Length; }
        }

        public int Count
        {
            get { return count; }
        }

        public Queue(int size = 10)
        {
            Array = new T[size];
        }

        public void Enqueue(T val) //Добавление элемента.
        {
            if (count == 10)
            {
                throw new Exception("Queue OverFlow.");
            }
            Array[currentIn] = val;
            currentIn++;
            if (currentIn == Array.Length)
            {
                currentIn = 0;
            }
            count++;
        }

        public T Dequeue() //Извлечение элемента.
        {
            if (count == 0)
            {
                throw new Exception("Queue is empty.");
            }
            T r = Array[currentOut];
            Array[currentOut] = default(T);
            currentOut++;
            if (currentOut == Array.Length)
            {
                currentOut = 0;
            }
            count--;
            return r;
        }

        public T Peek() //Верхний элемент.
        {
            if (count == 0)
            {
                throw new Exception("Queue is empty.");
            }
            return Array[currentOut];
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public T[] ToArray() //Возвращение массива.
        {
            int i = currentOut;
            int j = 0;
            T[] output = new T[count];
            while (j < count)
            {
                output[j] = Array[i];
                j++;
                i = (i + 1) % Array.Length;
            }
            return output;
        }

        public override string ToString()
        {
            string s = "";
            T[] tmp = this.ToArray();
            for (int i = 0; i < tmp.Length; i++)
            {
                s += tmp[i].ToString() + "\r\n";
            }
            return s;
        }
    }
}