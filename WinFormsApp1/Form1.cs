using WinFormsApp1.Properties;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Settings.Default.SavedText; 
        }

        private void SaveData()
        {
            Settings.Default.SavedText = textBox1.Text.Trim();
            File.WriteAllText("data.txt", textBox1.Text.Trim());
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e) => SaveData();

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(input))
            {
                ShowMessage("Введите непустую строку.", "Ошибка", MessageBoxIcon.Warning);
                return;
            }

            var result = BuildResultMessage(CountAdjacentLetters(input.Replace(" ", "").ToLower()));
            ShowMessage(result, "Результат подсчета", MessageBoxIcon.Information);
        }

        private Dictionary<char, List<int>> CountAdjacentLetters(string input)
        {
            var letterCounts = new Dictionary<char, List<int>>();
            for (int i = 0; i < input.Length;)
            {
                char currentChar = input[i];
                int length = 1;
                while (++i < input.Length && input[i] == currentChar) length++;

                if (length > 1)
                {
                    if (!letterCounts.ContainsKey(currentChar))
                        letterCounts[currentChar] = new List<int>();
                    letterCounts[currentChar].Add(length);
                }
            }
            return letterCounts;
        }

        private string BuildResultMessage(Dictionary<char, List<int>> letterCounts) =>
            letterCounts.Count == 0
                ? "Нет одинаковых соседних букв."
                : string.Join("\n", letterCounts.SelectMany(pair =>
                    pair.Value.Select(length => $"Буква {pair.Key} - {length} раза")));

        private void ShowMessage(string message, string caption, MessageBoxIcon icon) =>
            MessageBox.Show(message, caption, MessageBoxButtons.OK, icon);
    }
}