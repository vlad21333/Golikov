using System;
using System.Windows;
using System.Windows.Controls;

namespace Golikov
{
    public partial class MainWindow : Window
    {
        // Экземпляр класса из библиотеки Calculator
        private Calculator.Class1 _calculator = new Calculator.Class1();

        // Хранение текущего значения
        private double _currentValue = 0;

        // Хранение текущей операции
        private string _currentOperation = null;

        // Флаг для нового ввода
        private bool _isNewInput = true;

        // Флаг для десятичной точки
        private bool _hasDecimalPoint = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия на цифровые кнопки
        /// </summary>
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string number = button.Content.ToString();

            if (_isNewInput)
            {
                InputBox.Text = "";
                _isNewInput = false;
                _hasDecimalPoint = false;
            }

            // Проверка на максимальную длину ввода
            if (InputBox.Text.Length < 15)
            {
                InputBox.Text += number;
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопку десятичной точки
        /// </summary>
        private void Dot_Click(object sender, RoutedEventArgs e)
        {
            if (_isNewInput)
            {
                InputBox.Text = "0";
                _isNewInput = false;
            }

            // Добавляем точку, если её ещё нет
            if (!_hasDecimalPoint && !InputBox.Text.Contains("."))
            {
                InputBox.Text += ".";
                _hasDecimalPoint = true;
            }
        }

        /// <summary>
        /// Обработчик нажатия на кнопки операций
        /// </summary>
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string operation = button.Content.ToString();

            // Если не новый ввод, выполняем предыдущую операцию
            if (!_isNewInput)
            {
                Calculate();
            }

            try
            {
                _currentValue = double.Parse(InputBox.Text);
            }
            catch (FormatException)
            {
                InputBox.Text = "Ошибка";
                _isNewInput = true;
                return;
            }

            _currentOperation = operation;
            _isNewInput = true;
            _hasDecimalPoint = false;
        }

        /// <summary>
        /// Обработчик нажатия на кнопку равно
        /// </summary>
        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            if (_currentOperation != null)
            {
                Calculate();
                _currentOperation = null;
                _isNewInput = true;
                _hasDecimalPoint = false;
            }
        }

        /// <summary>
        /// Выполнение арифметической операции
        /// </summary>
        private void Calculate()
        {
            double newValue;

            try
            {
                newValue = double.Parse(InputBox.Text);
            }
            catch (FormatException)
            {
                InputBox.Text = "Ошибка";
                _isNewInput = true;
                return;
            }

            try
            {
                switch (_currentOperation)
                {
                    case "+":
                        _currentValue = _calculator.Add(_currentValue, newValue);
                        break;
                    case "-":
                        _currentValue = _calculator.Subtract(_currentValue, newValue);
                        break;
                    case "*":
                        _currentValue = _calculator.Multiply(_currentValue, newValue);
                        break;
                    case "/":
                        _currentValue = _calculator.Divide(_currentValue, newValue);
                        break;
                    case "^":
                        _currentValue = _calculator.Power(_currentValue, newValue);
                        break;
                }

                // Форматирование результата
                if (Math.Abs(_currentValue % 1) < double.Epsilon)
                {
                    InputBox.Text = ((int)_currentValue).ToString();
                }
                else
                {
                    InputBox.Text = _currentValue.ToString();
                }
            }
            catch (DivideByZeroException ex)
            {
                InputBox.Text = ex.Message;
                _isNewInput = true;
            }
            catch (ArgumentException ex)
            {
                InputBox.Text = ex.Message;
                _isNewInput = true;
            }
            catch (Exception)
            {
                InputBox.Text = "Ошибка";
                _isNewInput = true;
            }
        }

        /// <summary>
        /// Полная очистка (C)
        /// </summary>
        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Text = "0";
            _currentValue = 0;
            _currentOperation = null;
            _isNewInput = true;
            _hasDecimalPoint = false;
        }

        /// <summary>
        /// Очистка текущего ввода (CE)
        /// </summary>
        private void ClearEntry_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Text = "0";
            _isNewInput = true;
            _hasDecimalPoint = false;
        }
    }
}