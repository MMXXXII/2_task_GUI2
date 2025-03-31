namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();  // Инициализация компонентов формы
        }

        private void SaveText()
        {
            // Записываем текст из текстового поля в файл "data.txt"
            File.WriteAllText("data.txt", textBox1.Text);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // При закрытии формы сохраняем текст из текстового поля в файл
            SaveText();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;  // Получаем текст из текстового поля

            if (string.IsNullOrEmpty(inputText))  // Проверяем, не пустой ли текст
            {
                ShowErrorMessage("Введите непустую строку.");  // Показываем сообщение об ошибке, если строка пуста
                return;  // Выходим из метода
            }

            inputText = inputText.Replace(" ", "").ToLower();  // Убираем пробелы и приводим текст к нижнему регистру

            string result = CountSameAdjacentLetters(inputText);  // Подсчитываем одинаковые соседние буквы
            ShowInfoMessage(result);  // Показываем результат в информационном окне
        }

        private string CountSameAdjacentLetters(string text)
        {
            string result = "";  // Переменная для хранения результата
            int i = 0;  // Индекс для прохода по строке

            while (i < text.Length)  // Пока не пройдем всю строку
            {
                char currentChar = text[i];  // Текущий символ
                int count = 1;  // Начинаем с подсчета 1 для текущего символа

                while (i + 1 < text.Length && text[i + 1] == currentChar)  // Пока следующий символ одинаковый
                {
                    count++;  // Увеличиваем счетчик
                    i++;  // Переходим к следующему символу
                }

                if (count > 1)  // Если символ встречается более одного раза подряд
                {
                    result += $"Буква {currentChar} встречается {count} раз(а)\n";  // Добавляем информацию в результат
                }

                i++;  // Переходим к следующему символу
            }

            if (string.IsNullOrEmpty(result))  // Если нет одинаковых соседних букв
            {
                return "Нет одинаковых соседних букв.";  // Возвращаем сообщение, что одинаковых букв нет
            }

            return result;  // Возвращаем результат
        }

        private void ShowInfoMessage(string message)
        {
            // Показываем информационное сообщение
            MessageBox.Show(message, "Результат подсчета", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ShowErrorMessage(string message)
        {
            // Показываем сообщение об ошибке
            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
