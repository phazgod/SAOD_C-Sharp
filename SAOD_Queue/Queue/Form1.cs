using System;
using System.Windows.Forms;

namespace SAOD_Queue
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Queue<int> queue;

        private void Form1_Load(object sender, EventArgs e)
        {
            queue = new Queue<int>();
            Random r = new Random();
            for (int i = 0; i < queue.Capacity; i++)
            {
                queue.Enqueue(r.Next(1, 50));
            }
            textBox5.Text = queue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                queue.Enqueue(Convert.ToInt32(textBox1.Text));
                textBox5.Text = queue.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Queue OverFlow.");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = queue.Dequeue().ToString();
                textBox5.Text = queue.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Queue is empty.");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = queue.Peek().ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Queue is empty.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox4.Text = queue.IsEmpty().ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}