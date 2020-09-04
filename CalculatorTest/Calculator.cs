using System;

namespace Calculation
{
    public class Calculator
    {
        public double Difference(double operand1, double operand2)
        {
            double result = operand1 - operand2;
            result = Math.Round(result, 15);
            return result;
        }

        public double Sum(double operand1, double operand2)
        {
            double result = operand1 + operand2;
            result = Math.Round(result, 15);
            return result;
        }

        public double Multiplication(double operand1, double operand2)
        {
            double result = operand1 * operand2;
            result = Math.Round(result, 15);
            return result;
        }

        public double Division(double operand1, double operand2)
        {
            double result = operand1 / operand2;
            result = Math.Round(result, 15);
            return result;
        }

        public double Square(double operand)
        {
            double result = operand * operand;
            result = Math.Round(result, 15);
            return result;
        }

    }
}
