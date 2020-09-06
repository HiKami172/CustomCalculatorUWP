using System;

namespace Calculation
{
    public static class Calculator
    {
        public static double Difference(double operand1, double operand2)
        {
            double result = operand1 - operand2;
            result = Math.Round(result, 15);
            return result;
        }

        public static double Sum(double operand1, double operand2)
        {
            double result = operand1 + operand2;
            result = Math.Round(result, 15);
            return result;
        }

        public static double Multiplication(double operand1, double operand2)
        {
            double result = operand1 * operand2;
            result = Math.Round(result, 15);
            return result;
        }

        public static double Division(double operand1, double operand2)
        {
            double result = operand1 / operand2;
            result = Math.Round(result, 15);
            return result;
        }

        public static double Square(double operand)
        {
            double result = operand * operand;
            result = Math.Round(result, 15);
            return result;
        }
    }
}
