using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int a) && int.TryParse(textBox2.Text, out int b))
            {
                int evenCount = 0; // Кількість парних чисел
                int oddCount = 0;  // Кількість непарних чисел

                // Перевіряємо, які значення були введені для a та b [я лише вибір з 3-х можливих по умовам завдання]
                if ((a == -120 && b == 30) || (a == 10 && b == 70) || (a == 0 && b == 250))
                {
                    // Перебираємо числа в інтервалі [a, b]
                    for (int i = a; i <= b; i++)
                    {
                        if (i % 2 == 0)
                        {
                            evenCount++;
                        }
                        else
                        {
                            oddCount++;
                        }
                    }

                    label1.Text = "Кількість парних чисел: " + evenCount.ToString();
                    label2.Text = "Кількість непарних чисел: " + oddCount.ToString();
                }
                else
                {
                    MessageBox.Show("Введені значення a та b не відповідають одному з трьох інтервалів." + $"\nДопустимі інтервали: {comboBox1.Items[0]}, {comboBox1.Items[1]}, {comboBox1.Items[2]}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, введіть коректні значення для a та b." + $"\nДопустимі інтервали: {comboBox1.Items[0]}, {comboBox1.Items[1]}, {comboBox1.Items[2]}", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                textBox1.Text = "-120";
                textBox2.Text = "30";
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                textBox1.Text = "10";
                textBox2.Text = "70";
            } else
            {
                textBox1.Text = "0";
                textBox2.Text = "250";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
