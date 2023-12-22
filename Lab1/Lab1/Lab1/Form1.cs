using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = "";
            label2.Text = "";

            // Приховування label [Інтервал, Результат] за допомогою властивості visible.

            /* label3.Visible = false;
            label2.Visible = false; */
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") {
                MessageBox.Show("Введіть ціле число для X!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else if (int.TryParse(textBox1.Text, out int x))
            {
                int sum = 0;

                for (int i = -x; i <= x; i++)
                {
                    // Якщо пропускаємо 0, як парне та кратне для 3
                    // if (i == 0) continue;

                    if (i % 2 == 0 && i % 3 == 0)
                    {
                        sum++;
                    }
                }

                label3.Text = "Інтервал: [" + x + "; -" + x + "]";
                label2.Text = "Результат: " + sum.ToString();

                // Відображення [Інтервал, Результат] використовуючи властивість.

                /* label3.Visible = true;
                label2.Visible = true; */
            }
            else
            {
                MessageBox.Show("Неправильний формат введених даних.\nВведіть ціле число для X!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
