using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAOD_HashTable
{
    public class MyHashTable<Tkey, Tvalue>
    {
        //Коллизия - это ошибка из-за повторяющихся индексов после преобразования хэш-функцией.

        List<HashItem<Tkey, Tvalue>>[] massive = new List<HashItem<Tkey, Tvalue>>[100]; // List для избежания коллизии.

        public MyHashTable() // Заполнение массива списками.
        {
            for (int i = 0; i < massive.Length; i++)
            {
                massive[i] = new List<HashItem<Tkey, Tvalue>>();
            }
        }


        public void Add(Tkey key, Tvalue value)
        {
            if (value == null)
            {
                throw new Exception();
            }

            else
            {
                int tmp = HashFunction(key); // Преобразование ключа в хэш-ключ.
                HashItem<Tkey, Tvalue> a = new HashItem<Tkey, Tvalue>(key, value); // Новый элемент, принимает параметры: ключ, значение.
                massive[tmp].Add(a); //Если есть элемент, то после.
            }
        }

        public Tvalue Find(Tkey key) //Поиск.
        {
            int tmp = HashFunction(key); 
            HashItem<Tkey, Tvalue> item = massive[tmp].Find(x => x.Key.Equals(key)); // Для х выполняется x.Key = введенному на форме ключу.
            if (item != null)
            {
                return item.Value;
            }

            throw new Exception();
        }

        public void Delete(Tkey key)
        {
            int tmp = HashFunction(key);

            HashItem<Tkey, Tvalue> item = massive[tmp].Find(x => x.Key.Equals(key));

            if (item != null)
            {
                massive[tmp].Remove(item);
            }

            else
            {
                throw new Exception();
            }
        }

        private int HashFunction(Tkey key) //Получить индекс элемента.
        {
            if (key is int ikey) //если ключ можно определить как инт, то записываем в инт переменную ikey
            {
                return ikey % massive.Length; //Индекс массива.
            }

            else if (key is string skey)
            {
                int tmp = 0;

                for (int i = 0; i < skey.Length; i++)
                {
                    tmp += (int)skey[i]; //Построчно считывает в инт переменную.
                }

                return tmp % massive.Length;
            }

            throw new Exception();
        }

        public List<Tvalue> ToList()
        {
            List<Tvalue> outp = new List<Tvalue>();
            for (int i = 0; i < massive.Length; i++)
            {
                for (int k = 0; k < massive[i].Count; k++)
                {
                    outp.Add(massive[i][k].Value); // Добавить значение.
                }
            }
            return outp;
        }

        public override string ToString()
        {
            string tmp = "";
            for (int i = 0; i < massive.Length; i++)
            {
                if (massive[i].Count > 0)
                {
                    for (int k = 0; k < massive[i].Count; k++)
                    {
                        tmp += "Значение: " + massive[i][k].Value.ToString() + " /" + "  Хэш-ключ: " + i + " /" + "  Ключ: " + massive[i][k].Key.ToString() + "\r\n";
                    }
                }
            }
            return tmp;
        }
    }
}