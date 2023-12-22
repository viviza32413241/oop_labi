using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Lab5
{

    public partial class Form1 : Form
    {
        private List<Student> students = new List<Student>();
        private string currentFileName = "";

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JSON Files (*.json)|*.json";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFileName = openFileDialog.FileName;
                LoadDataFromJson(currentFileName);
                DisplayDataInDataGridView(dataGridView1, students);
            }
        }

        private void DisplayDataInDataGridView(DataGridView dataGridView, List<Student> data)
        {
            try {
                dataGridView.Rows.Clear();
                foreach (var student in data)
                {
                    dataGridView.Rows.Add(student.LastName, student.FirstName, student.ExamScore, student.Module1Score, student.Module2Score, student.SemesterGrade, student.Result);

                }
            } catch (NullReferenceException)
            {
                MessageBox.Show("Помилка при спробі считати дані з файлу, можливо ви вказали недійсний файл?", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveDataToJson(string fileName)
        {
            string json = JsonConvert.SerializeObject(students, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }

        // Функція для завантаження даних з файлу JSON
        private void LoadDataFromJson(string fileName)
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                students = JsonConvert.DeserializeObject<List<Student>>(json);
            }
        }

        private void saveFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentFileName))
            {
                SaveDataToJson(currentFileName);
                MessageBox.Show("Дані збережено в файлі " + currentFileName, "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Файл не вибраний. Використайте 'Відкрити файл' або 'Зберегти як'.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON Files (*.json)|*.json";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFileName = saveFileDialog.FileName;
                SaveDataToJson(currentFileName);
                MessageBox.Show($"Дані збережено в файлі {currentFileName}", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void showAllDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisplayDataInDataGridView(dataGridView1, students);
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (students != null)
            {
                var searchResults = students.Where(student => student.SemesterGrade > 80).ToList();
                if (searchResults.Count > 0)
                {
                    DisplayDataInDataGridView(dataGridView1, searchResults);
                }
                else
                {
                    MessageBox.Show("Немає результатів, що відповідають критеріям пошуку.", "Результати пошуку", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudent addStudentForm = new AddStudent();
            if (addStudentForm.ShowDialog() == DialogResult.OK)
            {
                students.Add(addStudentForm.NewStudent);
                if (!string.IsNullOrEmpty(currentFileName)) // Перевіряєм, чи ім'я файлу не пусте
                {
                    SaveDataToJson(currentFileName);
                    DisplayDataInDataGridView(dataGridView1, students);
                }
                else
                {
                    MessageBox.Show("Файл не выбран. Используйте 'Відкрити файл' або 'Зберегти як'.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toPdfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string pdfFileName = saveFileDialog.FileName;

                // Створюємо новий документ PDF
                Document pdfDocument = new Document();
                PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDocument, new FileStream(pdfFileName, FileMode.Create));

                // Відкриваємо докумемнт для запису
                pdfDocument.Open();

                // Створюємо таблицю PDF
                PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);
                pdfTable.DefaultCell.Padding = 3;
                pdfTable.WidthPercentage = 100;
                pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;

                // Встановлюємо шрифт (для використання а-яА-Я)
                BaseFont baseFont = BaseFont.CreateFont(@"C:\Windows\Fonts\arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
                iTextSharp.text.Font font = new iTextSharp.text.Font(baseFont, 12);

                // Добавляємо заголовки стовбців
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, font));
                    cell.BackgroundColor = new BaseColor(240, 240, 240);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(cell);
                }

                // Добавляємо данні з DataGridView в таблицю PDF
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        pdfTable.AddCell(new Phrase(cell.Value.ToString(), font));
                    }
                }

                // Добавляємо таблицю в документ PDF
                pdfDocument.Add(pdfTable);

                // Закриваємо документ
                pdfDocument.Close();

                MessageBox.Show("Дані збережено в PDF файлі: " + pdfFileName, "Успішно");
            }
        }
    }
    // Клас, який представляє дані студента
    public class Student
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int ExamScore { get; set; }
        public int Module1Score { get; set; }
        public int Module2Score { get; set; }
        public int SemesterGrade { get; set; }
        public string Result { get; set; }
    }
}
