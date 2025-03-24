namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Сохраняем данные
        private void SaveText()
        {
            string text = textBox1.Text.Trim();
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
            //словарь, где ключ — символ, а значение — список длин последовательных повторений
            var counts = new Dictionary<char, List<int>>();

            // Проходим по всей строке
            for (int i = 0; i < text.Length;)
            {
                // текущий символ
                char currentChar = text[i];
                int count = 1;

                // Считаем количество подряд идущих одинаковых символов
                while (i + 1 < text.Length && text[i + 1] == currentChar)
                {
                    count++; 
                    i++; 
                }

                if (count > 1)
                {
                    // Если в словаре ещё нет такого символа, создаём для него запись
                    if (!counts.ContainsKey(currentChar))
                    {
                        counts[currentChar] = new List<int>();
                    }
                    // Добавляем количество повторений в список
                    counts[currentChar].Add(count);
                }

                i++;
            }

            return counts;
        }



      
        private string GetResultMessage(Dictionary<char, List<int>> counts)
        {
           
            if (counts.Count == 0)
            {
                return "Нет одинаковых соседних букв.";
            }

            // Создаём список строк для формирования итогового сообщения
            List<string> resultLines = new List<string>();

            // Проходим по каждому элементу в словаре
            foreach (var entry in counts)
            {
                // Для каждой длины последовательных одинаковых символов добавляем строку в результат
                foreach (var length in entry.Value)
                {
                    resultLines.Add($"Буква {entry.Key} встречается {length} раз(а)");
                }
            }

            return string.Join("\n", resultLines);
        }

        private void ShowInfoMessage(string message)
        {

            MessageBox.Show(message, "Результат подсчета", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void ShowErrorMessage(string message)
        {

            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

    }
}