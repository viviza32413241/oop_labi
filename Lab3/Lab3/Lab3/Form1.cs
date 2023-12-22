using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class Form1 : Form
    {

        Class_arifm arifm;

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int firstElement = Convert.ToInt32(numericUpDown1.Value);
            int countStep = Convert.ToInt32(numericUpDown4.Value);
            int step = Convert.ToInt32(numericUpDown3.Value);

            arifm = new Class_arifm(countStep);

            arifm.FirstElement = firstElement;
            arifm.Step = step;

            arifm.array_value();

            textBox1.Text = $"Елементи арифметичної прогресії: {string.Join(", ", arifm.return_elements())}";

            button1.Enabled = true;
            button3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int searchIndex = Convert.ToInt32(numericUpDown2.Value);
            MessageBox.Show($"Значення {searchIndex}-го елемента послідовності: {arifm.k_elem(searchIndex)}", "Результат пошуку", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sum = arifm.sum(arifm.return_elements().Length);
            MessageBox.Show($"Сума арифметичної послідовності: {sum}", "Результат пошуку", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
