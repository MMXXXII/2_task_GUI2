using System.Text;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var counter = new LetterCounter(); // ������� ������ ������ LetterCounter
            string input = textBox1.Text; // �������� ����� �� ���������� ����

            if (string.IsNullOrEmpty(input)) // ���������, ��� ������ �� ������
            {
                MessageBox.Show("������� �������� ������.");
                return;
            }

            var letterCounts = counter.CountAdjacentLetters(input); // �������� ����� ��� �������� ����

            if (letterCounts.Count == 0) // ���� ������� ����, ������, ������������� ���� ���
            {
                MessageBox.Show("��� ���������� �������� ����.");
            }
            else
            {
                StringBuilder result = new StringBuilder(); // ���������� StringBuilder ��� �������� ����������

                foreach (var pair in letterCounts) // ���������� ����� � �������
                {
                    foreach (var length in pair.Value) // ���������� ����� ������������������� ��� ������ �����
                    {
                        result.AppendLine($"����� {pair.Key} - {length} ����"); // ��������� ��������� � StringBuilder
                    }
                }

                // ���������� ��������� � MessageBox
                MessageBox.Show(result.ToString(), "��������� �������� ���������� �������� ����");
            }
        }
    }

    public class LetterCounter
    {
        // ����� ��� �������� ���������� �������� ���� � ������
        public Dictionary<char, List<int>> CountAdjacentLetters(string input)
        {
            var letterCounts = new Dictionary<char, List<int>>(); // ������� ������� ��� �������� ���� � �� ������������� �������������������
            input = input.Replace(" ", "").ToLower(); // ������� ������� � �������� ������ � ������� ��������

            for (int i = 0; i < input.Length - 1; i++) // ���� �� �������� ������, ����� ����������
            {
                if (input[i] == input[i + 1]) // ���� ������� ������ ��������� �� ���������
                {
                    int length = 2; // �������� ������� ������������������ � 2
                    while (i + length < input.Length && input[i] == input[i + length]) // ���� ������� ����������
                        length++; // ����������� ����� ������������������

                    if (!letterCounts.ContainsKey(input[i])) // ���� ����� ����������� � �������
                        letterCounts[input[i]] = new List<int>(); // ��������� � �� ������� ����

                    letterCounts[input[i]].Add(length); // ��������� ��������� ����� ������������������ � �������
                    i += length - 1; // ���������� ��� ������������ �������
                }
            }

            return letterCounts; // ���������� ������� � ������������
        }
    }
}
