using Calculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Calculator
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
        bool OperationKnown = false;
        double result = 0;
        double PrevNum = 0;
        double NewNum = 0;
        double NextNum = 0;
        string _operator;
        string chain;
        string operationBlockChain;
        */
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
/*
        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string x = (string)button.Content;
            NewNum = double.Parse(x);

            if (OperationKnown == true)
            {                
                if (NextNum != 0)
                {
                    chain = NextNum.ToString() + NewNum.ToString();
                    NextNum = double.Parse(chain);
                }
                else
                {
                    NextNum = NewNum;
                }
            }
            else
            {
                if (PrevNum != 0)
                {
                    chain = PrevNum.ToString() + NewNum.ToString();
                    PrevNum = double.Parse(chain);
                }
                else
                {
                    PrevNum = NewNum;
                }
            }
            operationBlockChain = operationBlockChain + x;
            operationBlock.Text = operationBlockChain;
        }

        private void OperationButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;

            if ((string)button.Content == "=")
            {
                switch (_operator)
                {
                    case "/":
                        result = PrevNum / NextNum;
                        break;
                    case "x":
                        result = PrevNum * NextNum;
                        break;
                    case "-":
                        result = PrevNum - NextNum;
                        break;
                    case "+":
                        result = PrevNum + NextNum;
                        break;
                    default:

                        break;
                }
                resultBlock.Text = result.ToString("0.00");
                OperationKnown = false;
                operationBlock.Text = operationBlockChain + "=";
                operationBlockChain = string.Empty;
            }
            else if ((string)button.Content == "C")
            {
                result = 0;
                PrevNum = 0;
                NewNum = 0;
                NextNum = 0;
                resultBlock.Text = string.Empty;
                OperationKnown = false;
                operationBlock.Text = string.Empty;
                operationBlockChain = string.Empty;
            }
            else
            {
                if (OperationKnown == true)
                {
                    operationBlockChain = operationBlockChain.Remove(operationBlockChain.Length - 1, 1);                    
                }
                else
                {
                    OperationKnown = true;                    
                }
                _operator = (string)button.Content;
                operationBlockChain = operationBlockChain + _operator;
                operationBlock.Text = operationBlockChain;
            }
        }*/
    }
}
