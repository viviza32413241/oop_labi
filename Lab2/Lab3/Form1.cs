using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool isGenMatrixA = false;
        bool isGenMatrixB = false;

        private void GenerateMatrix(int rows, int cols, ListBox targetBox)
        {
            Random random = new Random();
            targetBox.Items.Clear();

            for (int i = 0; i < rows; i++)
            {
                string row = "";
                for (int j = 0; j < cols; j++)
                {
                    int randomNumber = random.Next(10, 21); // Генеруємо випадкове число в інтервалі [10, 20]
                    row += randomNumber + " ";
                }
                targetBox.Items.Add(row.Trim()); // Додаємо рядок до listBox1, обрізаючи пробіли на кінці
            }

            // int[] massive = GetMatrixAsArray(targetBox);
            // Console.WriteLine("[{0}]", string.Join(", ", massive));

            if (isGenMatrixA == true && isGenMatrixB == true)
            {
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                groupBox4.Enabled = true;

                numericUpDown1.Maximum = listBox1.Items.Count;
                numericUpDown2.Maximum = listBox2.Items.Count;

                numericUpDown8.Maximum = listBox1.Items.Count;
                numericUpDown7.Maximum = listBox2.Items.Count;

                numericUpDown3.Maximum = listBox1.Items.Count;
                numericUpDown6.Maximum = listBox1.Items.Count;
            }

        }

        private int[] GetMatrixAsArray(ListBox targetBox)
        {
            List<int> matrixElements = new List<int>();

            foreach (string row in targetBox.Items)
            {
                string[] elements = row.Split(' ');
                foreach (string element in elements)
                {
                    matrixElements.Add(Convert.ToInt32(element));
                }
            }

            return matrixElements.ToArray();
        }

        private int[] GetRowAsArray(ListBox targetBox, int rowIndex)
        {
            string row = targetBox.Items[rowIndex].ToString();
            string[] elements = row.Split(' ');
            List<int> rowElements = new List<int>();

            foreach (string element in elements)
            {
                rowElements.Add(Convert.ToInt32(element));
            }

            return rowElements.ToArray();
        }

        private int[] GetColumnAsArray(ListBox targetBox, int columnIndex)
        {
            List<int> columnElements = new List<int>();

            foreach (string row in targetBox.Items)
            {
                string[] elements = row.Split(' ');

                if (columnIndex < elements.Length)
                {
                    columnElements.Add(Convert.ToInt32(elements[columnIndex]));
                }
                else
                {
                    // Обробка ситуації, коли вказаний стовпець виходить за межі рядка.
                    // Наприклад, можна викинути виняток або додати значення за замовчуванням.
                }
            }

            return columnElements.ToArray();
        }

        private void ReplaceRowInMatrix(ListBox sourceBox, int rowIndex, ListBox targetBox, int targetRowIndex)
        {
            rowIndex--;
            targetRowIndex--;

            if (rowIndex < 0 || rowIndex >= sourceBox.Items.Count || targetRowIndex < 0 || targetRowIndex >= targetBox.Items.Count)
            {
                MessageBox.Show("Невірний індекс рядка.");
                return;
            }

            string[] sourceMatrix = sourceBox.Items.Cast<string>().ToArray();
            string[] targetMatrix = targetBox.Items.Cast<string>().ToArray();

            string sourceRow = sourceMatrix[rowIndex];
            string[] targetRow = targetMatrix[targetRowIndex].Split(' ');

            int sourceRowLength = sourceRow.Split(' ').Length;
            int targetRowLength = targetRow.Length;

            if (sourceRowLength > targetRowLength)
            {
                // Обрізаємо джерело, якщо воно довше цільового рядка
                sourceRow = string.Join(" ", sourceRow.Split(' ').Take(targetRowLength));
            }

            for (int i = 0; i < sourceRow.Split(' ').Length; i++)
            {
                targetRow[i] = sourceRow.Split(' ')[i];
            }

            targetMatrix[targetRowIndex] = string.Join(" ", targetRow);

            targetBox.Items.Clear();

            foreach (string row in targetMatrix)
            {
                targetBox.Items.Add(row);
            }
        }

        private void ReplaceColumnInMatrix(ListBox sourceBox, int columnIndex, ListBox targetBox, int targetColumnIndex)
        {
            columnIndex--;
            targetColumnIndex--;

            if (columnIndex < 0 || targetColumnIndex < 0)
            {
                MessageBox.Show("Невірний індекс стовбця.");
                return;
            }

            string[] sourceMatrix = sourceBox.Items.Cast<string>().ToArray();
            string[] targetMatrix = targetBox.Items.Cast<string>().ToArray();

            int sourceMatrixRowCount = sourceMatrix.Length;
            int targetMatrixRowCount = targetMatrix.Length;

            // Визначаємо Min кількість рядків між джерелом та цільовою матрицею
            int minRowCount = Math.Min(sourceMatrixRowCount, targetMatrixRowCount);

            for (int i = 0; i < minRowCount; i++)
            {
                string[] sourceRow = sourceMatrix[i].Split(' ');
                string[] targetRow = targetMatrix[i].Split(' ');

                if (columnIndex >= sourceRow.Length)
                {
                    // Обрізаємо джерело, якщо індекс вихідного стовбця виходить за межі
                    Array.Resize(ref targetRow, columnIndex + 1);
                    sourceRow = sourceRow.Take(targetRow.Length).ToArray();
                }
                else if (columnIndex < sourceRow.Length)
                {
                    targetRow[targetColumnIndex] = sourceRow[columnIndex];
                }

                targetMatrix[i] = string.Join(" ", targetRow);
            }

            targetBox.Items.Clear();
            foreach (string row in targetMatrix)
            {
                targetBox.Items.Add(row);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = false;

            OneDimensionalArray.testAddArray();
            OneDimensionalArray.testMultiplicationArray();
            OneDimensionalArray.testDecrementArray();
            OneDimensionalArray.testEqualArray();
        }

        private void genericA_Click(object sender, EventArgs e)
        {
            if (domainUpDown1.Text.Contains("вибрати"))
            {
                MessageBox.Show("Оберіть розмір матриці!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isGenMatrixA) isGenMatrixA = true;

            switch (domainUpDown1.Text)
            {
                case "5x5":
                    GenerateMatrix(5, 5, listBox1);
                    break;
                case "4x4":
                    GenerateMatrix(4, 4, listBox1);
                    break;
                default:
                    GenerateMatrix(3, 3, listBox1);
                    break;
            }

        }

        private void genericB_Click(object sender, EventArgs e)
        {
            if (domainUpDown1.Text.Contains("вибрати"))
            {
                MessageBox.Show("Оберіть розмір матриці!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isGenMatrixB) isGenMatrixB = true;

            switch (domainUpDown1.Text)
            {
                case "5x5":
                    GenerateMatrix(5, 5, listBox2);
                    break;
                case "4x4":
                    GenerateMatrix(4, 4, listBox2);
                    break;
                default:
                    GenerateMatrix(3, 3, listBox2);
                    break;
            }
        }

        private void dubbleRow_Click(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "Дублювати рядок";
            toolStripLabel2.Text = "матриці A в рядок";
            toolStripLabel3.Text = "матриці B";
            
            if (toolStripButton1.Enabled == false) toolStripButton1.Enabled = true;
        }

        private void dubbleCol_Click(object sender, EventArgs e)
        {
            toolStripLabel1.Text = "Дублювати стовпець";
            toolStripLabel2.Text = "матриці A в стовпець";
            toolStripLabel3.Text = "матриці B";
            
            if (toolStripButton1.Enabled == false) toolStripButton1.Enabled = true;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            if (toolStripLabel1.Text.Contains("рядок"))
            {
                ReplaceRowInMatrix(listBox1, Convert.ToInt32(toolStripTextBox1.Text), listBox2, Convert.ToInt32(toolStripTextBox2.Text));
            }
            else
            {
                ReplaceColumnInMatrix(listBox1, Convert.ToInt32(toolStripTextBox1.Text), listBox2, Convert.ToInt32(toolStripTextBox2.Text));
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = (1 + listBox1.SelectedIndex).ToString();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            toolStripTextBox2.Text = (1 + listBox2.SelectedIndex).ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int firstNumeric = Convert.ToInt32(numericUpDown8.Value);
            int secondNumeric = Convert.ToInt32(numericUpDown7.Value);
            
            OneDimensionalArray array1 = new OneDimensionalArray(GetRowAsArray(listBox1, firstNumeric - 1));
            OneDimensionalArray array2 = new OneDimensionalArray(GetRowAsArray(listBox2, secondNumeric - 1));
            
            if (array1 == array2)
            {
                MessageBox.Show("Обрані рядки матриць рівні!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Обрані рядки матриць не рівні!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int firstNumeric = Convert.ToInt32(numericUpDown1.Value);
            int secondNumeric = Convert.ToInt32(numericUpDown2.Value);

            OneDimensionalArray array1 = new OneDimensionalArray(GetRowAsArray(listBox1, firstNumeric - 1));
            OneDimensionalArray array2 = new OneDimensionalArray(GetRowAsArray(listBox2, secondNumeric - 1));

            listBox3.Items.Add(array1 + array2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int numeric = Convert.ToInt32(numericUpDown6.Value);
            int decrementNums = Convert.ToInt32(numericUpDown5.Value);

            OneDimensionalArray array1 = new OneDimensionalArray(GetRowAsArray(listBox1, numeric - 1));

            for (int i = 0; i < decrementNums; i++)
            {
                array1--;
            }

            textBox2.Text = array1.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int numeric = Convert.ToInt32(numericUpDown3.Value);
            int scalarNum = Convert.ToInt32(numericUpDown4.Value);
            
            int result = 0;

            int[] arr = GetRowAsArray(listBox1, numeric - 1);

            for (int i = 0; i < arr.Length; i++) 
            {
                result += scalarNum * arr[i];
            }

            textBox1.Text = result.ToString();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
