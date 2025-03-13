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
            var counter = new LetterCounter(); // Создаем объект класса LetterCounter
            string input = textBox1.Text; // Получаем текст из текстового поля

            if (string.IsNullOrEmpty(input)) // Проверяем, что строка не пустая
            {
                MessageBox.Show("Введите непустую строку.");
                return;
            }

            var letterCounts = counter.CountAdjacentLetters(input); // Вызываем метод для подсчета букв

            if (letterCounts.Count == 0) // Если словарь пуст, значит, повторяющихся букв нет
            {
                MessageBox.Show("Нет одинаковых соседних букв.");
            }
            else
            {
                StringBuilder result = new StringBuilder(); // Используем StringBuilder для создания результата

                foreach (var pair in letterCounts) // Перебираем буквы в словаре
                {
                    foreach (var length in pair.Value) // Перебираем длины последовательностей для каждой буквы
                    {
                        result.AppendLine($"Буква {pair.Key} - {length} раза"); // Добавляем результат в StringBuilder
                    }
                }

                // Отображаем результат в MessageBox
                MessageBox.Show(result.ToString(), "Результат подсчета одинаковых соседних букв");
            }
        }
    }

    public class LetterCounter
    {
        // Метод для подсчета одинаковых соседних букв в строке
        public Dictionary<char, List<int>> CountAdjacentLetters(string input)
        {
            var letterCounts = new Dictionary<char, List<int>>(); // Создаем словарь для хранения букв и их повторяющихся последовательностей
            input = input.Replace(" ", "").ToLower(); // Убираем пробелы и приводим строку к нижнему регистру

            for (int i = 0; i < input.Length - 1; i++) // Цикл по символам строки, кроме последнего
            {
                if (input[i] == input[i + 1]) // Если текущий символ совпадает со следующим
                {
                    int length = 2; // Начинаем считать последовательность с 2
                    while (i + length < input.Length && input[i] == input[i + length]) // Пока символы одинаковые
                        length++; // Увеличиваем длину последовательности

                    if (!letterCounts.ContainsKey(input[i])) // Если буква отсутствует в словаре
                        letterCounts[input[i]] = new List<int>(); // Добавляем её со списком длин

                    letterCounts[input[i]].Add(length); // Добавляем найденную длину последовательности в словарь
                    i += length - 1; // Пропускаем уже подсчитанные символы
                }
            }

            return letterCounts; // Возвращаем словарь с результатами
        }
    }
}
