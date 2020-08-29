using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
   
    public sealed partial class MainPage : Page
    {
        enum Condition
        {
            none,
            operation,
            result
        }
        Condition condition = Condition.none;

        private double Truncate(double value, int precision)
        {
            var p = 1 / Math.Pow(10, precision);
            return value - (value % p);
        }
        private bool IsDouble(string text)
        {
            Double num = 0;
            bool isDouble = false;

            // Check for empty string.
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            isDouble = Double.TryParse(text, out num);

            return isDouble;
        }

        private bool WrongInput()
        {
            if(!IsDouble(txtNumber.Text))
            {
                txtNumber.Text = String.Empty;
                txtNumber.Focus(FocusState.Pointer);
                return true;
            }
            return false;
        }
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumber.Text != String.Empty)
            {
                if (WrongInput())
                    return;
                if (condition == Condition.operation)
                {
                    btnEq_Click(sender, e);
                    txtResult.Text += "-";
                    txtNumber.Text = String.Empty;
                }
                else
                {
                    txtResult.Text = txtNumber.Text + "-";
                    txtNumber.Text = String.Empty;
                }
            }
            else
            {
                if (condition == Condition.result)
                {
                    txtResult.Text += "-";
                }
            }
            condition = Condition.operation;
            txtNumber.Focus(FocusState.Pointer);
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumber.Text != String.Empty)
            {
                if (WrongInput())
                    return;
                if (condition == Condition.operation)
                {
                    btnEq_Click(sender, e);
                    txtResult.Text += "+";
                    txtNumber.Text = String.Empty;
                }
                else
                {
                    txtResult.Text = txtNumber.Text + "+";
                    txtNumber.Text = String.Empty;
                }
            }
            else
            {
                if (condition == Condition.result)
                {
                    txtResult.Text += "+";
                }
            }
            condition = Condition.operation;
            txtNumber.Focus(FocusState.Pointer);
        }
        private void btnGetSquare_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumber.Text != String.Empty)
            {
                if (WrongInput())
                    return;
                if (condition == Condition.operation)
                {
                    btnEq_Click(sender, e);
                    double k = Convert.ToDouble(txtResult.Text);
                    txtResult.Text = Truncate(k * k, 16).ToString();
                    txtNumber.Text = String.Empty;
                    return;
                }
                double n = Convert.ToDouble(txtNumber.Text);
                txtResult.Text = Truncate(n * n, 16).ToString();
                txtNumber.Text = String.Empty;
                condition = Condition.result;
            }
            else if (condition == Condition.result)
            {
                double n = Convert.ToDouble(txtResult.Text);
                txtResult.Text = Truncate(n*n, 16).ToString();
                txtNumber.Text = String.Empty;
            }
            txtNumber.Focus(FocusState.Pointer);
        }

        private void btnMulpiple_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumber.Text != String.Empty)
            {
                if (WrongInput())
                    return;
                if (condition == Condition.operation)
                {
                    btnEq_Click(sender, e);
                    txtResult.Text += "*";
                    txtNumber.Text = String.Empty;
                }
                else
                {
                    txtResult.Text = txtNumber.Text + "*";
                    txtNumber.Text = String.Empty;
                }
            }
            else
            {
                if (condition == Condition.result)
                {
                    txtResult.Text += "*";
                }
            }
            condition = Condition.operation;
            txtNumber.Focus(FocusState.Pointer);
        }

        private void btnEq_Click(object sender, RoutedEventArgs e)
        {
            if (condition != Condition.operation && txtNumber.Text != String.Empty && !WrongInput())
            {
                txtResult.Text = txtNumber.Text;
                txtNumber.Focus(FocusState.Pointer);
                txtNumber.Text = String.Empty;
                return;
            }
            txtResult.Text += txtNumber.Text;
                String ResultTxt = txtResult.Text;
                String[] operands = ResultTxt.Split('/', '+', '-', '*');
            if (!IsDouble(operands[0]) || !IsDouble(operands[1]))
            {
                txtNumber.Text = String.Empty;
                txtResult.Text = String.Empty;
                txtNumber.Focus(FocusState.Pointer);
                return;
            }
                double operand1 = Convert.ToDouble(operands[0]);
                double operand2 = Convert.ToDouble(operands[1]);
                double res;
            if (ResultTxt.Contains('/') && operand2 != 0)
            {
                res = operand1 / operand2;
                txtResult.Text = Truncate(res, 16).ToString();
            }
            else if (ResultTxt.Contains('/') && operand2 == 0)
            {
                txtResult.Text = String.Empty;
                txtNumber.Text = String.Empty;
                condition = Condition.none;
                txtNumber.Focus(FocusState.Pointer);
                return;
            }
            if (ResultTxt.Contains('+'))
            {
                
                res = (operand1 + operand2);
                txtResult.Text = Truncate(res, 16).ToString();
            }
            if (ResultTxt.Contains('-'))
            {
                res = operand1 - operand2;
                txtResult.Text = Truncate(res, 16).ToString();
            }
            if (ResultTxt.Contains('*'))
            {
                res = operand1 * operand2;
                txtResult.Text = Truncate(res, 16).ToString();
            }
                txtNumber.Text = String.Empty;
            condition = Condition.result;
            txtNumber.Focus(FocusState.Pointer);
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumber.Text != String.Empty)
            {
                if (WrongInput())
                    return;
                if (condition == Condition.operation)
                {
                    btnEq_Click(sender, e);
                    txtResult.Text += "/";
                    txtNumber.Text = String.Empty;
                }
                else
                {
                    txtResult.Text = txtNumber.Text + "/";
                    txtNumber.Text = String.Empty;
                }
            }
            else
            {
                if (condition == Condition.result)
                {
                    txtResult.Text += "/";
                }
            }
            condition = Condition.operation;
            txtNumber.Focus(FocusState.Pointer);
        }

        private void btnAC_Click(object sender, RoutedEventArgs e)
        {
            condition = Condition.none;
            txtNumber.Text = String.Empty;
            txtResult.Text = String.Empty;
            txtNumber.Focus(FocusState.Pointer);
        }
    }
}
