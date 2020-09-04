using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
                txtNumber.Text = string.Empty;
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
            if (txtNumber.Text != string.Empty)
            {
                if (WrongInput())
                    return;
                if (condition == Condition.operation)
                {
                    btnEq_Click(sender, e);
                    txtResult.Text += "-";
                    txtNumber.Text = string.Empty;
                }
                else
                {
                    txtResult.Text = txtNumber.Text + "-";
                    txtNumber.Text = string.Empty;
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
            if (txtNumber.Text != string.Empty)
            {
                if (WrongInput())
                    return;
                if (condition == Condition.operation)
                {
                    btnEq_Click(sender, e);
                    txtResult.Text += "+";
                    txtNumber.Text = string.Empty;
                }
                else
                {
                    txtResult.Text = txtNumber.Text + "+";
                    txtNumber.Text = string.Empty;
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
            if (txtNumber.Text != string.Empty)
            {
                if (WrongInput())
                    return;
                if (condition == Condition.operation)
                {
                    btnEq_Click(sender, e);
                    double k = Convert.ToDouble(txtResult.Text);
                    double res1 = k * k;
                    txtResult.Text = Math.Round(res1, 15).ToString();
                    txtNumber.Text = string.Empty;
                    return;
                }
                double n = Convert.ToDouble(txtNumber.Text);
                double res = n * n;
                txtResult.Text = Math.Round(res, 15).ToString();
                txtNumber.Text = string.Empty;
                condition = Condition.result;
            }
            else if (condition == Condition.result)
            {
                double n = Convert.ToDouble(txtResult.Text);
                double res = n * n;
                txtResult.Text = Math.Round(res, 15).ToString();
                txtNumber.Text = string.Empty;
            }
            txtNumber.Focus(FocusState.Pointer);
        }

        private void btnMulpiple_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumber.Text != string.Empty)
            {
                if (WrongInput())
                    return;
                if (condition == Condition.operation)
                {
                    btnEq_Click(sender, e);
                    txtResult.Text += "*";
                    txtNumber.Text = string.Empty;
                }
                else
                {
                    txtResult.Text = txtNumber.Text + "*";
                    txtNumber.Text = string.Empty;
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
            if (condition != Condition.operation && txtNumber.Text != string.Empty && !WrongInput())
            {
                txtResult.Text = txtNumber.Text;
                txtNumber.Focus(FocusState.Pointer);
                txtNumber.Text = string.Empty;
                return;
            }
            txtResult.Text += txtNumber.Text;
                string ResultTxt = txtResult.Text;
                string[] operands = ResultTxt.Split('/', '+', '-', '*');
            if (!IsDouble(operands[0]) || !IsDouble(operands[1]))
            {
                txtNumber.Text = string.Empty;
                txtResult.Text = string.Empty;
                txtNumber.Focus(FocusState.Pointer);
                return;
            }
                double operand1 = Convert.ToDouble(operands[0]);
                double operand2 = Convert.ToDouble(operands[1]);
                double res;
            if (ResultTxt.Contains('/') && operand2 != 0)
            {
                res = operand1 / operand2;
                txtResult.Text = Math.Round(res, 15).ToString();
            }
            else if (ResultTxt.Contains('/') && operand2 == 0)
            {
                txtResult.Text = string.Empty;
                txtNumber.Text = string.Empty;
                condition = Condition.none;
                txtNumber.Focus(FocusState.Pointer);
                return;
            }
            if (ResultTxt.Contains('+'))
            {
                
                res = (operand1 + operand2);
                txtResult.Text = Math.Round(res, 15).ToString();
            }
            if (ResultTxt.Contains('-'))
            {
                res = operand1 - operand2;
                txtResult.Text = Math.Round(res, 15).ToString();
            }
            if (ResultTxt.Contains('*'))
            {
                res = operand1 * operand2;
                txtResult.Text = Math.Round(res, 15).ToString();
            }
                txtNumber.Text = string.Empty;
            condition = Condition.result;
            txtNumber.Focus(FocusState.Pointer);
        }

        private void btnDiv_Click(object sender, RoutedEventArgs e)
        {
            if (txtNumber.Text != string.Empty)
            {
                if (WrongInput())
                    return;
                if (condition == Condition.operation)
                {
                    btnEq_Click(sender, e);
                    txtResult.Text += "/";
                    txtNumber.Text = string.Empty;
                }
                else
                {
                    txtResult.Text = txtNumber.Text + "/";
                    txtNumber.Text = string.Empty;
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
            txtNumber.Text = string.Empty;
            txtResult.Text = string.Empty;
            txtNumber.Focus(FocusState.Pointer);
        }
    }
}
