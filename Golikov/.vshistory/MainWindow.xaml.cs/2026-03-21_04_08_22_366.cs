using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Golikov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Calculator _calculator = new Calculator();
        private double _currentValue = 0;
        private string _currentOperation = null;
        private bool _isNewInput = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Number_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (_isNewInput)
            {
                InputBox.Text = "";
                _isNewInput = false;
            }
            InputBox.Text += button.Content.ToString();
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            if (!_isNewInput)
            {
                Calculate();
            }
            _currentValue = double.Parse(InputBox.Text);
            _currentOperation = (sender as Button).Content.ToString();
            _isNewInput = true;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
            _currentOperation = null;
            _isNewInput = true;
        }

        private void Calculate()
        {
            double newValue = double.Parse(InputBox.Text);
            switch (_currentOperation)
            {
                case "+": _currentValue = _calculator.Add(_currentValue, newValue); break;
                case "-": _currentValue = _calculator.Subtract(_currentValue, newValue); break;
                case "*": _currentValue = _calculator.Multiply(_currentValue, newValue); break;
                case "/": _currentValue = _calculator.Divide(_currentValue, newValue); break;
                case "^": _currentValue = _calculator.Power(_currentValue, newValue); break;
            }
            InputBox.Text = _currentValue.ToString();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            InputBox.Text = "0";
            _currentValue = 0;
            _currentOperation = null;
            _isNewInput = true;
        }
    }
}
