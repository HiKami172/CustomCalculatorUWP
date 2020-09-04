using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium.Remote;
using System.Globalization;
using OpenQA.Selenium;
using Calculation;

namespace CalculatorTesting
{
    class CalculatorTest
    {
        protected static RemoteWebDriver AppSession;
        protected static CultureInfo Culture = CultureInfo.GetCultureInfo("en-US");
        protected TimeSpan TimeToWait = TimeSpan.FromSeconds(1);
        protected static IWebElement InputField;
        protected static IWebElement ResultField;
        Random random = new Random();
        Calculator calculator = new Calculator();

        public CalculatorTest(RemoteWebDriver appSession)
        {

            AppSession = appSession;
            InputField = AppSession.FindElementByName("txtNumber");
            ResultField = AppSession.FindElementByName("txtResult");
        }

        public void Sum()
        {
            double operand1 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand1.ToString(Culture));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnPlus").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            double operand2 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand2.ToString(Culture));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnEq").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = ResultField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double digitResult = calculator.Sum(operand1, operand2);
            string expectedResult = digitResult.ToString(Culture);
            Assert.AreEqual(expectedResult, txtResultTextElement.Text);
            ResultField.Clear();
        }

        public void Difference()
        {
            double operand1 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand1.ToString(Culture));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnMinus").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            double operand2 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand2.ToString(Culture));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnEq").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = ResultField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double digitResult = calculator.Difference(operand1, operand2);
            string expectedResult = digitResult.ToString(Culture);
            Assert.AreEqual(expectedResult, txtResultTextElement.Text);
            ResultField.Clear();
        }
   
        public void Multiplication()
        {
            double operand1 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand1.ToString(Culture));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnMultiple").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            double operand2 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand2.ToString(Culture));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnEq").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = ResultField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double digitResult = calculator.Multiplication(operand1, operand2);
            string expectedResult = digitResult.ToString(Culture);
            Assert.AreEqual(expectedResult, txtResultTextElement.Text);
            ResultField.Clear();
        }
       
        public void Division()
        {
            double operand1 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand1.ToString(Culture));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnDiv").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            double operand2 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand2.ToString(Culture));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnEq").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = ResultField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double digitResult = calculator.Division(operand1, operand2);
            string expectedResult = digitResult.ToString(Culture);
            Assert.AreEqual(expectedResult, txtResultTextElement.Text);
            ResultField.Clear();
        }
       
        public void DivisionByZero()
        {
            InputField.Clear();
            InputField.SendKeys("5");
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnDiv").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            InputField.Clear();
            InputField.SendKeys("0");
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnEq").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = ResultField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            Assert.AreEqual(String.Empty, txtResultTextElement.Text);
            ResultField.Clear();
        }
        
        public void Square()
        {
            double operand = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand.ToString(Culture));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnGetSquare").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = ResultField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double digitResult = calculator.Square(operand);
            string expectedResult = digitResult.ToString(Culture);
            Assert.AreEqual(expectedResult, txtResultTextElement.Text);
            ResultField.Clear();
        }
        
        public void AC()
        {
            double operand = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand.ToString(Culture));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnGetSquare").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnAC").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = ResultField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            Assert.AreEqual(String.Empty, txtResultTextElement.Text);

            txtResultTextElement = InputField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            Assert.AreEqual(String.Empty, txtResultTextElement.Text);
            ResultField.Clear();
        }
        
        public void SeqBinOper()
        {
            double operand1 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand1.ToString(Culture));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnPlus").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            double operand2 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand2.ToString(Culture));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnMultiple").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = ResultField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double digitResult = calculator.Sum(operand1, operand2);
            string expectedResult = digitResult.ToString(Culture) + '*';
            Assert.AreEqual(expectedResult, txtResultTextElement.Text);
            ResultField.Clear();
        }
        
        public void SquareAfterBinOper()
        {
            double operand1 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand1.ToString(Culture));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnPlus").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            double operand2 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand2.ToString(Culture));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnGetSquare").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = ResultField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double digitResult = calculator.Square(calculator.Sum(operand1, operand2));
            string expectedResult = digitResult.ToString(Culture);
            Assert.AreEqual(expectedResult, txtResultTextElement.Text);
            ResultField.Clear();
        }
       
        public void OperationWithPrevRes()
        {
            double operand = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand.ToString(Culture));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnGetSquare").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnGetSquare").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = ResultField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double digitResult = calculator.Square(calculator.Square(operand));
            string expectedResult = digitResult.ToString(Culture);
            Assert.AreEqual(expectedResult, txtResultTextElement.Text);
            ResultField.Clear();
        }
    }
}
