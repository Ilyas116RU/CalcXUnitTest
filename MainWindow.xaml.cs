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

namespace CalcXUnitTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
     
            private double firstNumber;
            private double secondNumber;
            private string operation;

            public MainWindow()
            {
                InitializeComponent();
            }

            private void NumberButton_Click(object sender, RoutedEventArgs e)
            {
                Button button = (Button)sender;
                string number = button.Content.ToString();

                if (resultTextBox.Text == "0")
                {
                    resultTextBox.Text = number;
                }
                else
                {
                    resultTextBox.Text += number;
                }
            }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Content.ToString();

            
            if (double.TryParse(resultTextBox.Text, out firstNumber))
            {
                resultTextBox.Text = "0";
            }
            else
            {
                
                MessageBox.Show("Invalid input. Please enter a valid number.");
            }
        }

        private void EqualButton_Click(object sender, RoutedEventArgs e)
            {
                secondNumber = double.Parse(resultTextBox.Text);

                switch (operation)
                {
                    case "+":
                        resultTextBox.Text = (firstNumber + secondNumber).ToString();
                        break;
                    case "-":
                        resultTextBox.Text = (firstNumber - secondNumber).ToString();
                        break;
                    case "*":
                        resultTextBox.Text = (firstNumber * secondNumber).ToString();
                        break;
                    case "/":
                        if (secondNumber == 0)
                        {
                            resultTextBox.Text = "Error: Division by zero";
                        }
                        else
                        {
                            resultTextBox.Text = (firstNumber / secondNumber).ToString();
                        }
                        break;
                }
            }

            private void ClearButton_Click(object sender, RoutedEventArgs e)
            {
                resultTextBox.Text = "0";
                firstNumber = 0;
                secondNumber = 0;
                operation = null;
            }

            private void DotButton_Click(object sender, RoutedEventArgs e)
            {
                if (!resultTextBox.Text.Contains("."))
                {
                    resultTextBox.Text += ".";
                }
            }

            private void BackspaceButton_Click(object sender, RoutedEventArgs e)
            {
                if (resultTextBox.Text.Length > 1)
                {
                    resultTextBox.Text = resultTextBox.Text.Substring(0, resultTextBox.Text.Length - 1);
                }
                else
                {
                    resultTextBox.Text = "0";
                }
            }

            private void Window_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                {
                    NumberButton_Click(GetButtonFromKey(e.Key), null);
                }
                else if (e.Key == Key.Add || e.Key == Key.Subtract || e.Key == Key.Multiply || e.Key == Key.Divide)
                {
                    OperationButton_Click(GetButtonFromKey(e.Key), null);
                }
                else if (e.Key == Key.Enter)
                {
                    EqualButton_Click(null, null);
                }
                else if (e.Key == Key.Escape)
                {
                    ClearButton_Click(null, null);
                }
                else if (e.Key == Key.Decimal)
                {
                    DotButton_Click(null, null);
                }
                else if (e.Key == Key.Back)
                {
                    BackspaceButton_Click(null, null);
                }
            }

            private Button GetButtonFromKey(Key key)
            {
                switch (key)
                {
                    case Key.D0:
                    case Key.NumPad0:
                        return button0;
                    case Key.D1:
                    case Key.NumPad1:
                        return button1;
                    case Key.D2:
                    case Key.NumPad2:
                        return button2;
                    case Key.D3:
                    case Key.NumPad3:
                        return button3;
                    case Key.D4:
                    case Key.NumPad4:
                        return button4;
                    case Key.D5:
                    case Key.NumPad5:
                        return button5;
                    case Key.D6:
                    case Key.NumPad6:
                        return button6;
                    case Key.D7:
                    case Key.NumPad7:
                        return button7;
                    case Key.D8:
                    case Key.NumPad8:
                        return button8;
                    case Key.D9:
                    case Key.NumPad9:
                        return button9;
                    case Key.Add:
                        return buttonPlus;
                    case Key.Subtract:
                        return buttonMinus;
                    case Key.Multiply:
                        return buttonMultiply;
                    case Key.Divide:
                        return buttonDivide;
                    default:
                        return null;
                }
            }
        }
    }
