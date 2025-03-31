namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();  // ������������� ����������� �����
        }

        private void SaveText()
        {
            // ���������� ����� �� ���������� ���� � ���� "data.txt"
            File.WriteAllText("data.txt", textBox1.Text);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // ��� �������� ����� ��������� ����� �� ���������� ���� � ����
            SaveText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;  // �������� ����� �� ���������� ����

            if (string.IsNullOrEmpty(inputText))  // ���������, �� ������ �� �����
            {
                ShowErrorMessage("������� �������� ������.");  // ���������� ��������� �� ������, ���� ������ �����
                return;  // ������� �� ������
            }

            inputText = inputText.Replace(" ", "").ToLower();  // ������� ������� � �������� ����� � ������� ��������

            string result = CountSameAdjacentLetters(inputText);  // ������������ ���������� �������� �����
            ShowInfoMessage(result);  // ���������� ��������� � �������������� ����
        }

        private string CountSameAdjacentLetters(string text)
        {
            string result = "";  // ���������� ��� �������� ����������
            int i = 0;  // ������ ��� ������� �� ������

            while (i < text.Length)  // ���� �� ������� ��� ������
            {
                char currentChar = text[i];  // ������� ������
                int count = 1;  // �������� � �������� 1 ��� �������� �������

                while (i + 1 < text.Length && text[i + 1] == currentChar)  // ���� ��������� ������ ����������
                {
                    count++;  // ����������� �������
                    i++;  // ��������� � ���������� �������
                }

                if (count > 1)  // ���� ������ ����������� ����� ������ ���� ������
                {
                    result += $"����� {currentChar} ����������� {count} ���(�)\n";  // ��������� ���������� � ���������
                }

                i++;  // ��������� � ���������� �������
            }

            if (string.IsNullOrEmpty(result))  // ���� ��� ���������� �������� ����
            {
                return "��� ���������� �������� ����.";  // ���������� ���������, ��� ���������� ���� ���
            }

            return result;  // ���������� ���������
        }

        private void ShowInfoMessage(string message)
        {
            // ���������� �������������� ���������
            MessageBox.Show(message, "��������� ��������", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowErrorMessage(string message)
        {
            // ���������� ��������� �� ������
            MessageBox.Show(message, "������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
