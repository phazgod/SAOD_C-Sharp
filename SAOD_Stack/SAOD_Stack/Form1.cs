using System;
using System.Windows.Forms;

namespace SAOD_Stack
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MyStack<int> stack = new MyStack<int>();

        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            for (int i = 0; i < stack.Capacity; i++)
            {
                stack.Push(r.Next(1, 45));
            }
            textBox4.Text = stack.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                stack.Push(Convert.ToInt32(textBox1.Text));
                textBox4.Text = stack.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = stack.Top().ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                textBox3.Text = stack.Pop().ToString();
                textBox4.Text = stack.ToString();
            }       
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}