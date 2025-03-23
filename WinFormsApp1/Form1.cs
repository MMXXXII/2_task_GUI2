namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = Properties.Settings.Default.SavedText;
        }

        // ��������� ������
        private void SaveText()
        {
            string text = textBox1.Text.Trim();
            Properties.Settings.Default.SavedText = text;
            File.WriteAllText("data.txt", text);
        }

        // ���������� �������� �����
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveText();
        }

        // ���������� ������
        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text.Trim();

            if (string.IsNullOrWhiteSpace(inputText))
            {
                ShowErrorMessage("������� �������� ������.");
                return;
            }

            // ������� ������� � �������� � ������� ��������
            inputText = inputText.Replace(" ", "").ToLower();

            var letterCounts = CountSameAdjacentLetters(inputText);
            string result = GetResultMessage(letterCounts);
            ShowInfoMessage(result);
        }

        // ������� ���������� �������� ����
        private Dictionary<char, List<int>> CountSameAdjacentLetters(string text)
        {
            var counts = new Dictionary<char, List<int>>();

            for (int i = 0; i < text.Length;)
            {
                char currentChar = text[i];
                int count = 1;

                // ������� ���������� �������� �����
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

        // ������������ ����������
        private string GetResultMessage(Dictionary<char, List<int>> counts)
        {
            if (counts.Count == 0)
            {
                return "��� ���������� �������� ����.";
            }

            List<string> resultLines = new List<string>();

            foreach (var entry in counts)
            {
                foreach (var length in entry.Value)
                {
                    resultLines.Add($"����� {entry.Key} ����������� {length} ���(�)");
                }
            }

            return string.Join("\n", resultLines);
        }

        // ���������� �������������� ���������
        private void ShowInfoMessage(string message)
        {
            MessageBox.Show(message, "��������� ��������", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ���������� ������
        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
