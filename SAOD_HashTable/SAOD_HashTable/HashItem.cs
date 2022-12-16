using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SAOD_HashTable
{
     class HashItem<Tkey, TValue>
    {
        private Tkey key;
        private TValue val;

        public Tkey Key // Определение уровня доступа.
        {
            get { return key; }
            set { key = value; }
        }

       public TValue Value
        {
            get { return val; }
            set { val = value; }
        }

        public HashItem(Tkey t_key, TValue t_value) 
        {
           key = t_key;
           val = t_value;
        }
    }
}