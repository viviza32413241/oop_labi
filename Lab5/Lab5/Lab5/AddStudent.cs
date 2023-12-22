using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5
{
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }
        public Student NewStudent { get; private set; }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(numericUpDown4.Value.ToString(), out int examScore) &&
                int.TryParse(numericUpDown1.Value.ToString(), out int module1Score) &&
                int.TryParse(numericUpDown2.Value.ToString(), out int module2Score) &&
                int.TryParse(numericUpDown3.Value.ToString(), out int semesterGrade))
            {
                NewStudent = new Student
                {
                    LastName = textBox1.Text,
                    FirstName = textBox2.Text,
                    ExamScore = examScore,
                    Module1Score = module1Score,
                    Module2Score = module2Score,
                    SemesterGrade = semesterGrade,
                    Result = domainUpDown1.Text
                };
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Бали повинні бути числами.", "Помилка");
            }
        }
    }
}
