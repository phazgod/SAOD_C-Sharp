using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SAOD_HashTable
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MyHashTable<int, string> massive = new MyHashTable<int, string>();
        string[] value = new string[7] { "Никита", "Василий", "Георгий", "Александр", "Владислав", "Алена", "Игорь" };
        //Рандом не рандомит имена, так что создаем массив.


        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();

            for (int i = 0; i < 7; i++)
            {
                int key = r.Next(0, 100);
                string val = value[i]; // Берет Никита и --> Игорь.

                massive.Add(key, val);
            }

            textBox1.Text = massive.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox3.Text == "")
                {
                    MessageBox.Show("Введите значение.");
                }

                else
                {
                    massive.Add(Convert.ToInt32(textBox2.Text), textBox3.Text);

                    textBox1.Text = massive.ToString();
                }

            }

            catch
            {
                MessageBox.Show("Неверный ключ");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox5.Text = massive.Find(Convert.ToInt32(textBox4.Text));
            }
            catch
            {
                MessageBox.Show("Нет элемента с таким ключом");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                massive.Delete(Convert.ToInt32(textBox6.Text));
                textBox1.Text = massive.ToString();
            }
            catch
            {
                MessageBox.Show("Нет элемента с таким ключом");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string a = "";
            foreach (string str in massive.ToList()) //иттерация по элементам массива 
            {
                a += str + " ";
            }
            textBox1.Text = a;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = massive.ToString();
        }
    }
}
