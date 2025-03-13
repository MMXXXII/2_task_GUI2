
using System.Text;
using WinFormsApp1.Properties; // Добавляем ссылку на настройки

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData(); // Восстановление данных при открытии формы
        }

        // Загрузка данных
        private void LoadData()
        {
            textBox1.Text = Settings.Default.SavedText;
        }

        // Сохранение данных
        private void SaveData()
        {
            Settings.Default.SavedText = textBox1.Text.Trim();
            Settings.Default.Save();
        }

        // Сохранение данных при закрытии формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveData();
        }

        // Подсчёт одинаковых соседних букв
        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Введите непустую строку, содержащую хотя бы одну букву.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var letterCounts = CountAdjacentLetters(input);

            string result = letterCounts.Count == 0
                ? "Нет одинаковых соседних букв."
                : BuildResultMessage(letterCounts);

            MessageBox.Show(result, "Результат подсчета", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // Метод для подсчёта одинаковых соседних букв
        private Dictionary<char, List<int>> CountAdjacentLetters(string input)
        {
            var letterCounts = new Dictionary<char, List<int>>();
            input = input.Replace(" ", "").ToLower();

            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    int length = 2; // Начинаем считать последовательность с 2
                    while (i + length < input.Length && input[i] == input[i + length])
                        length++;

                    if (!letterCounts.ContainsKey(input[i]))
                        letterCounts[input[i]] = new List<int>();

                    letterCounts[input[i]].Add(length);
                    i += length - 1;
                }
            }

            return letterCounts;
        }

        // Формирование текста для вывода результата
        private string BuildResultMessage(Dictionary<char, List<int>> letterCounts)
        {
            var result = new StringBuilder();
            foreach (var pair in letterCounts)
            {
                foreach (var length in pair.Value)
                {
                    result.AppendLine($"Буква {pair.Key} - {length} раза");
                }
            }
            return result.ToString();
        }
    }
}
