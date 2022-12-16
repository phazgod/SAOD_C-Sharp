using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyList_SAOD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MyList<int> list = new MyList<int>();

        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();

            for (int i = 0; i < 15; i++)
            {
                list.Append(r.Next(0, 51));
            }

            textBox8.Text = list.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            list.Append(Convert.ToInt32(textBox1.Text));

            textBox8.Text = list.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            list.Prepend(Convert.ToInt32(textBox2.Text));

            textBox8.Text = list.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                list.Insert(Convert.ToInt32(textBox3.Text), Convert.ToInt32(textBox9.Text));

                textBox8.Text = list.ToString();
            }

            catch
            {
                MessageBox.Show("нельзя добавить элемент с данным индексом.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string str = list.Find(Convert.ToInt32(textBox4.Text)).ToString();
                textBox10.Text = str;
            }

            catch
            {
                MessageBox.Show("Нет элемента с таким значением.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int zn = list.At(Convert.ToInt32(textBox5.Text));
                textBox11.Text = zn.ToString();
            }

            catch
            {
                MessageBox.Show("Нет элементов с таким индексом.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox12.Text = list.Remove(Convert.ToInt32(textBox6.Text)).ToString();
            textBox8.Text = list.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox13.Text = list.RemoveAt(Convert.ToInt32(textBox7.Text)).ToString();
            textBox8.Text = list.ToString();
        }
    }
}
