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
        private RemoteWebDriver AppSession { get; set; }
        private IWebElement InputField { get; set; }
        private IWebElement ResultField { get; set; }

        private CultureInfo Culture = CultureInfo.GetCultureInfo("en-US");
        private TimeSpan TimeToWait = TimeSpan.FromSeconds(5);
        Random random = new Random();

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

            double digitResult = Calculator.Sum(operand1, operand2);
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

            double digitResult = Calculator.Difference(operand1, operand2);
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

            double digitResult = Calculator.Multiplication(operand1, operand2);
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

            double digitResult = Calculator.Division(operand1, operand2);
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

            double digitResult = Calculator.Square(operand);
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

            double digitResult = Calculator.Sum(operand1, operand2);
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

            double digitResult = Calculator.Square(Calculator.Sum(operand1, operand2));
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

            double digitResult = Calculator.Square(Calculator.Square(operand));
            string expectedResult = digitResult.ToString(Culture);
            Assert.AreEqual(expectedResult, txtResultTextElement.Text);
            ResultField.Clear();
        }
    }
}
