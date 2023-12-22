using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_2
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            comboBox1.Text = "Початкові значення";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x, z;

            if (comboBox1.SelectedItem.ToString() == "Початкові значення")
            {
                x = 2;
                z = 1;
                textBox1.Text = "2";
                textBox2.Text = "1";
            }
            else if (comboBox1.SelectedItem.ToString() == "Власні значення")
            {
                if (int.TryParse(textBox1.Text, out x) && int.TryParse(textBox2.Text, out z))
                {
                    // Процес валідації та конвертації значень з текстових полів.
                }
                else
                {
                    MessageBox.Show("Будь ласка, введіть корректне значення для x та z!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Будь ласка, виберіть початкові або власні значення!");
                return;
            }

            int resultA = x++ * z++;
            string typeA = resultA.GetType().ToString();

            int resultB = x++ * 3 != ++z * 3 ? 1 : 0;
            string typeB = resultB.GetType().ToString();

            int resultC = (--x < ++z) ? z : -z;
            string typeC = resultC.GetType().ToString();

            label1.Text = $"A) Результат: {resultA}, Тип: {typeA}\n" +
                          $"B) Результат: {resultB}, Тип: {typeB}\n" +
                          $"C) Результат: {resultC}, Тип: {typeC}\n\n" +
                          $"Кінцеві значення змінних: x = {x}, z = {z}";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            label1.Text = "Оберіть значення та натисніть \"Обчислити\", щоб отримати результат.";
        }
    }
}
