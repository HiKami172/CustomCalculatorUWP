using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using System.Threading;
using System.Globalization;
namespace CalculatorTest
{
    [TestClass]
    public class UnitTest1
    {
        private double Truncate(double value, int precision)
        {
            var p = 1 / Math.Pow(10, precision);
            return value - (value % p);
        }
        protected const string AppDriverUrl = "http://127.0.0.1:4723";
        protected static RemoteWebDriver AppSession;
        Random random = new Random();
        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("app", "6e5f3ee8-9f6a-43c5-8bdd-de9087470117_0krc4rn5z6t7c!App");
            AppSession = new RemoteWebDriver(new Uri(AppDriverUrl), cap);
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
            double n = random.NextDouble();
            AppSession.FindElementByName("txtNumber").Clear();
            AppSession.FindElementByName("txtNumber").SendKeys(n.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("btnPlus").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            double k = random.NextDouble();
            AppSession.FindElementByName("txtNumber").Clear();
            AppSession.FindElementByName("txtNumber").SendKeys(k.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("btnEq").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = AppSession.FindElementByName("txtResult") as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double res = n + k;
            Assert.AreEqual(Truncate(res, 15).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")), txtResultTextElement.Text);
        }
        [TestMethod]
        public void Minus()
        {
            double n = random.NextDouble();
            AppSession.FindElementByName("txtNumber").Clear();
            AppSession.FindElementByName("txtNumber").SendKeys(n.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("btnMinus").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            double k = random.NextDouble();
            AppSession.FindElementByName("txtNumber").Clear();
            AppSession.FindElementByName("txtNumber").SendKeys(k.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("btnEq").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = AppSession.FindElementByName("txtResult") as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double res = n - k;
            Assert.AreEqual(Truncate(res, 15).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")), txtResultTextElement.Text);
        }
        [TestMethod]
        public void Multiply()
        {
            double n = random.NextDouble();
            AppSession.FindElementByName("txtNumber").Clear();
            AppSession.FindElementByName("txtNumber").SendKeys(n.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("btnMultiple").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            double k = random.NextDouble();
            AppSession.FindElementByName("txtNumber").Clear();
            AppSession.FindElementByName("txtNumber").SendKeys(k.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("btnEq").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = AppSession.FindElementByName("txtResult") as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double res = n * k;
            Assert.AreEqual(Truncate(res,15).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")), txtResultTextElement.Text);
        }
        [TestMethod]
        public void Division()
        {
            double n = random.NextDouble();
            AppSession.FindElementByName("txtNumber").Clear();
            AppSession.FindElementByName("txtNumber").SendKeys(n.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("btnDiv").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            double k = random.NextDouble();
            AppSession.FindElementByName("txtNumber").Clear();
            AppSession.FindElementByName("txtNumber").SendKeys(k.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("btnEq").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = AppSession.FindElementByName("txtResult") as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double res = n / k;
            Assert.AreEqual(Truncate(res, 15).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")), txtResultTextElement.Text);
        }
        [TestMethod]
        public void DivisionByZero()
        { 
            AppSession.FindElementByName("txtNumber").Clear();
            AppSession.FindElementByName("txtNumber").SendKeys("5");
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("btnDiv").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("txtNumber").Clear();
            AppSession.FindElementByName("txtNumber").SendKeys("0");
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("btnEq").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = AppSession.FindElementByName("txtResult") as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            Assert.AreEqual(String.Empty, txtResultTextElement.Text);
        }
        [TestMethod]
        public void Square()
        {
            double n = random.NextDouble();
            AppSession.FindElementByName("txtNumber").Clear();
            AppSession.FindElementByName("txtNumber").SendKeys(n.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("btnGetSquare").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);


            RemoteWebElement txtResultTextElement;
            txtResultTextElement = AppSession.FindElementByName("txtResult") as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double res = n * n;
            Assert.AreEqual(Truncate(res,15).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")), txtResultTextElement.Text);
        }
        [TestMethod]
        public void AC()
        {
            double n = random.NextDouble();
            AppSession.FindElementByName("txtNumber").Clear();
            AppSession.FindElementByName("txtNumber").SendKeys(n.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            
            AppSession.FindElementByName("btnGetSquare").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("btnAC").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);


            RemoteWebElement txtResultTextElement;
            txtResultTextElement = AppSession.FindElementByName("txtResult") as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            Assert.AreEqual(String.Empty, txtResultTextElement.Text);

            txtResultTextElement = AppSession.FindElementByName("txtNumber") as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            Assert.AreEqual(String.Empty, txtResultTextElement.Text);
        }
        [TestMethod]
        public void SeqBinOper()
        {
            double n = random.NextDouble();
            AppSession.FindElementByName("txtNumber").Clear();
            AppSession.FindElementByName("txtNumber").SendKeys(n.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("btnPlus").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            double k = random.NextDouble();
            AppSession.FindElementByName("txtNumber").Clear();
            AppSession.FindElementByName("txtNumber").SendKeys(k.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("btnMultiple").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = AppSession.FindElementByName("txtResult") as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double res = n + k;
            Assert.AreEqual(Truncate(res, 15).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + '*', txtResultTextElement.Text);
        }
        [TestMethod]
        public void SquareAfterBinOper()
        {
            double n = random.NextDouble();
            AppSession.FindElementByName("txtNumber").Clear();
            AppSession.FindElementByName("txtNumber").SendKeys(n.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("btnPlus").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            double k = random.NextDouble();
            AppSession.FindElementByName("txtNumber").Clear();
            AppSession.FindElementByName("txtNumber").SendKeys(k.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("btnGetSquare").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = AppSession.FindElementByName("txtResult") as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double res = (n + k) * (n + k);
            Assert.AreEqual(Truncate(res, 15).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")), txtResultTextElement.Text);
        }
        [TestMethod]
        public void OperationWithPrevRes()
        {
            double n = random.NextDouble();
            AppSession.FindElementByName("txtNumber").Clear();
            AppSession.FindElementByName("txtNumber").SendKeys(n.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")));
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("btnGetSquare").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            AppSession.FindElementByName("btnGetSquare").Click();
            AppSession.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            RemoteWebElement txtResultTextElement;
            txtResultTextElement = AppSession.FindElementByName("txtResult") as RemoteWebElement;
            Assert.IsNotNull(txtResultTextElement);

            double res = n * n * n * n;
            Assert.AreEqual(Truncate(res, 15).ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")), txtResultTextElement.Text);
        }

    }
}
