using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lab4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string[] wordsEndingWithO = GetWordsEndingWith(textBox1.Text, "ко");
            
            if (wordsEndingWithO.Length < 1) 
            {
                MessageBox.Show("В полі немає слів, що закінчуються на \"ко\"!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (string el in wordsEndingWithO)
            {
                listBox2.Items.Add(el);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string selectedText = textBox1.SelectedText;

            if (string.IsNullOrWhiteSpace(selectedText)) 
            {
                MessageBox.Show("Будь ласка, виділіть слова в полі, щоб перенести їх у список!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string[] selectedWords = GetWords(selectedText);

            foreach (string el in selectedWords)
            {
                if (!listBox1.Items.Contains(el)) listBox1.Items.Add(el);
            }

            if (button5.Enabled == false) button5.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox3.Text = $"{CountVowels(textBox1.Text)}";
            textBox2.Text = $"{CountConsonants(textBox1.Text)}";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // string selectedText = textBox1.SelectedText;

            //if (selectedText != null)
            //{
            //    Console.WriteLine("selectedText: " + selectedText);
            //    string[] selectedWords = GetWords(selectedText);

            //    for (int i = 0; i < selectedWords.Length; i++)
            //    {
            //        textBox1.Text = textBox1.Text.Replace(selectedWords[i], InvertWords(selectedWords[i]));
            //    }
            //}

            if (listBox1.SelectedIndex >= 0)
            {
                string thisItemStr = listBox1.Items[listBox1.SelectedIndex].ToString();
                string invertsWord = InvertWords(thisItemStr);
                listBox1.Items[listBox1.SelectedIndex] = invertsWord;
                textBox1.Text = textBox1.Text.Replace(thisItemStr, invertsWord);
            }

            // textBox1.Text = string.Join(" ", InvertWords(GetWords(textBox1.Text)));
        }
        private void button6_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            button5.Enabled = false;
        }

        // Виділення слів з тексту
        static string[] GetWords(string input)
        {
            return input.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        }

        // Інверсія слів у тексті
        static string[] InvertWords(string[] words)
        {
            for (int i = 0; i < words.Length; i++)
            {
                char[] charArray = words[i].ToCharArray();
                Array.Reverse(charArray);
                words[i] = new string(charArray);
            }
            return words;
        }

        // Інверсія слова у тексті
        static string InvertWords(string word)
        {
            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            word = new string(charArray);
            return word;
        }

        // Пошук слів, що закінчуються на певну послідовність
        static string[] GetWordsEndingWith(string input, string ending)
        {
            string[] words = GetWords(input);
            return words.Where(word => word.EndsWith(ending, StringComparison.OrdinalIgnoreCase)).ToArray();
        }

        // Пошук кількості голосних букв
        static int CountVowels(string input)
        {
            return input.Count(c => "еї".Contains(char.ToLower(c)));
        }

        // Пошук кількості приголосних букв
        static int CountConsonants(string input)
        {
            return input.Count(c => "псл".Contains(char.ToLower(c)));
        }
        
        // Пошук та виведення збігів по шаблону
        static string MatchPattern(string input, string pattern)
        {
            Regex regex = new Regex(pattern); // Створюємо екземпляр Regex з заданим шаблоном
            MatchCollection matches = regex.Matches(input); // Використовуємо створений екземпляр для пошуку збігів
            string result = "";

            foreach (Match match in matches)
            {
                result += $"{match}, ";
            }
            return result;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label4.Text = MatchPattern(textBox1.Text, "obj [k-p]{3,}[d-i]?.z*y");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
