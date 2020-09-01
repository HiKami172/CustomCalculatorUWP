using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System.Globalization;
using System.Reflection.Emit;
using OpenQA.Selenium;

namespace CalculatorTest
{
    [TestClass]
    public class OperationsTests
    {
        private double Truncate(double value, int precision)
        {
            var p = 1 / Math.Pow(10, precision);
            return value - (value % p);
        }
        protected const string AppDriverUrl = "http://127.0.0.1:4723";
        protected const string AppID = "6e5f3ee8-9f6a-43c5-8bdd-de9087470117_0krc4rn5z6t7c!App";
        protected TimeSpan TimeToWait = TimeSpan.FromSeconds(1);
        protected static RemoteWebDriver AppSession;
        protected static IWebElement InputField;
        protected static IWebElement ResultField;
        Random random = new Random();
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("app", AppID);
            AppSession = new RemoteWebDriver(new Uri(AppDriverUrl), cap);
            InputField = AppSession.FindElementByName("txtNumber");
            ResultField = AppSession.FindElementByName("txtResult");
            Assert.IsNotNull(AppSession);
        }

        [ClassCleanup]
        public static void TestsCleanup()
        {
            AppSession.Dispose();
            AppSession = null;
        }

        [TestMethod]
        public void Plus()
        {
            double operand1 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand1.ToString(CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnPlus").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            double operand2 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand2.ToString(CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnEq").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = ResultField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double result = operand1 + operand2;
            string expectedResult = Truncate(result, 15).ToString(CultureInfo.GetCultureInfo("en-US"));
            Assert.AreEqual(expectedResult, txtResultTextElement.Text);
        }

        [TestMethod]
        public void Minus()
        {
            double operand1 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand1.ToString(CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnMinus").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            double operand2 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand2.ToString(CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnEq").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = ResultField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double result = operand1 - operand2;
            string expectedResult = Truncate(result, 15).ToString(CultureInfo.GetCultureInfo("en-US"));
            Assert.AreEqual(expectedResult, txtResultTextElement.Text);
        }

        [TestMethod]
        public void Multiply()
        {
            double operand1 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand1.ToString(CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnMultiple").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            double operand2 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand2.ToString(CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnEq").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = ResultField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double result = operand1 * operand2;
            string expectedResult = Truncate(result, 15).ToString(CultureInfo.GetCultureInfo("en-US"));
            Assert.AreEqual(expectedResult, txtResultTextElement.Text);
        }

        [TestMethod]
        public void Division()
        {
            double operand1 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand1.ToString(CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnDiv").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            double operand2 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand2.ToString(CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnEq").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = ResultField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double result = operand1 / operand2;
            string expectedResult = Truncate(result, 15).ToString(CultureInfo.GetCultureInfo("en-US"));
            Assert.AreEqual(expectedResult, txtResultTextElement.Text);
        }

        [TestMethod]
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
        }

        [TestMethod]
        public void Square()
        {
            double operand = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand.ToString(CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnGetSquare").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = ResultField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double result = operand * operand;
            string expectedResult = Truncate(result, 15).ToString(CultureInfo.GetCultureInfo("en-US"));
            Assert.AreEqual(expectedResult, txtResultTextElement.Text);
        }

        [TestMethod]
        public void AC()
        {
            double n = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(n.ToString(CultureInfo.GetCultureInfo("en-US")));
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
        }

        [TestMethod]
        public void SeqBinOper()
        {
            double operand1 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand1.ToString(CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnPlus").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            double operand2 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand2.ToString(CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnMultiple").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = ResultField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double result = operand1 + operand2;
            string expectedResult = Truncate(result, 15).ToString(CultureInfo.GetCultureInfo("en-US")) + '*';
            Assert.AreEqual(expectedResult, txtResultTextElement.Text);
        }

        [TestMethod]
        public void SquareAfterBinOper()
        {
            double operand1 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand1.ToString(CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnPlus").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            double operand2 = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand2.ToString(CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnGetSquare").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = ResultField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double result = (operand1 + operand2) * (operand1 + operand2);
            string expectedResult = Truncate(result, 15).ToString(CultureInfo.GetCultureInfo("en-US"));
            Assert.AreEqual(expectedResult, txtResultTextElement.Text);
        }

        [TestMethod]
        public void OperationWithPrevRes()
        {
            double operand = random.NextDouble();
            InputField.Clear();
            InputField.SendKeys(operand.ToString(CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnGetSquare").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            AppSession.FindElementByName("btnGetSquare").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeToWait;

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = ResultField as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double result = operand * operand * operand * operand;
            string expectedResult = Truncate(result, 15).ToString(CultureInfo.GetCultureInfo("en-US"));
            Assert.AreEqual(expectedResult, txtResultTextElement.Text) ;
        }
    }
}
