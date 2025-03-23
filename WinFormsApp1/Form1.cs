namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.SavedText;
        }

        // Сохраняем данные
        private void SaveText()
        {
            string text = textBox1.Text.Trim();
            Properties.Settings.Default.SavedText = text;
            File.WriteAllText("data.txt", text);
        }

        // Обработчик закрытия формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveText();
        }

        // Обработчик кнопки
        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(inputText))
            {
                ShowErrorMessage("Введите непустую строку.");
                return;
            }

            // Убираем пробелы и приводим к нижнему регистру
            inputText = inputText.Replace(" ", "").ToLower();

            var letterCounts = CountSameAdjacentLetters(inputText);
            string result = GetResultMessage(letterCounts);
            ShowInfoMessage(result);
        }

        // Подсчет одинаковых соседних букв
        private Dictionary<char, List<int>> CountSameAdjacentLetters(string text)
        {
            var counts = new Dictionary<char, List<int>>();

            for (int i = 0; i < text.Length;)
            {
                char currentChar = text[i];
                int count = 1;

                // Считаем одинаковые соседние буквы
                while (i + 1 < text.Length && text[i + 1] == currentChar)
                {
                    count++;
                    i++;
                }

                if (count > 1)
                {
                    if (!counts.ContainsKey(currentChar))
                    {
                        counts[currentChar] = new List<int>();
                    }
                    counts[currentChar].Add(count);
                }

                i++;
            }

            return counts;
        }

        // Формирование результата
        private string GetResultMessage(Dictionary<char, List<int>> counts)
        {
            if (counts.Count == 0)
            {
                return "Нет одинаковых соседних букв.";
            }

            List<string> resultLines = new List<string>();

            foreach (var entry in counts)
            {
                foreach (var length in entry.Value)
                {
                    resultLines.Add($"Буква {entry.Key} встречается {length} раз(а)");
                }
            }

            return string.Join("\n", resultLines);
        }

        // Показываем информационное сообщение
        private void ShowInfoMessage(string message)
        {
            MessageBox.Show(message, "Результат подсчета", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Показываем ошибку
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
