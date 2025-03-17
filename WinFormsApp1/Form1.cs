using WinFormsApp1.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Settings.Default.SavedText;
        }

        // Сохранение данных из текстового поля
        private void SaveData()
        {
            string text = textBox1.Text.Trim();
            Settings.Default.SavedText = text;
            File.WriteAllText("data.txt", text);
        }

        // Обработчик события закрытия формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }

        // Обработчик нажатия на кнопку
        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                ShowMessage("Введите непустую строку.", "Ошибка", MessageBoxIcon.Warning);
                return;
            }

            string result = BuildResultMessage(CountAdjacentLetters(input.Replace(" ", "").ToLower()));
            ShowMessage(result, "Результат подсчета", MessageBoxIcon.Information);
        }

        // Подсчёт одинаковых соседних букв
        private Dictionary<char, List<int>> CountAdjacentLetters(string input)
        {
            var letterCounts = new Dictionary<char, List<int>>();

            for (int i = 0; i < input.Length;)
            {
                char currentChar = input[i];
                int length = 1;

                // Подсчёт последовательных одинаковых букв
                while (++i < input.Length && input[i] == currentChar)
                {
                    length++;
                }

                if (length > 1)
                {
                    if (!letterCounts.ContainsKey(currentChar))
                    {
                        letterCounts[currentChar] = new List<int>();
                    }
                    letterCounts[currentChar].Add(length);
                }
            }

            return letterCounts;
        }

        // Формирование сообщения с результатом
        private string BuildResultMessage(Dictionary<char, List<int>> letterCounts)
        {
            if (letterCounts.Count == 0)
            {
                return "Нет одинаковых соседних букв.";
            }

            var resultLines = new List<string>();
            foreach (var pair in letterCounts)
            {
                foreach (var length in pair.Value)
                {
                    resultLines.Add($"Буква {pair.Key} - {length} раза");
                }
            }

            return string.Join("\n", resultLines);
        }

        // Показ всплывающего сообщения
        private void ShowMessage(string message, string caption, MessageBoxIcon icon)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
        }
    }
}
