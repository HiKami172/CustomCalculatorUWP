using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using CalculatorTesting;
using OpenQA.Selenium.Chrome;

namespace CalculatorTestAutomation
{
    [TestClass]
    public class OperationsTests
    {
        private const string APPDRIVERURL = "http://127.0.0.1:4723";
        private const string APPID = "6e5f3ee8-9f6a-43c5-8bdd-de9087470117_0krc4rn5z6t7c!App";
        private static RemoteWebDriver AppSession;
        private static CalculatorTest calculatorTest;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            var cap = new ChromeOptions();
            cap.AddAdditionalCapability("app", APPID, true);
            AppSession = new RemoteWebDriver(new Uri(APPDRIVERURL), cap);
            Assert.IsNotNull(AppSession);
            calculatorTest =  new CalculatorTest(AppSession);
        }

        [ClassCleanup]
        public static void TestsCleanup()
        {
            AppSession.Dispose();
            AppSession = null;
        }

        [TestMethod]
        [Priority(0)]
        public void Sum()
        {
            calculatorTest.Sum();
        }

        [TestMethod]
        [Priority(1)]
        public void Difference()
        {
            calculatorTest.Difference();
        }

        [TestMethod]
        [Priority(2)]
        public void Multiplication()
        {
            calculatorTest.Multiplication();
        }

        [TestMethod]
        [Priority(3)]
        public void Division()
        {
            calculatorTest.Division();
        }

        [TestMethod]
        [Priority(4)]
        public void DivisionByZero()
        {
            calculatorTest.DivisionByZero();
        }

        [TestMethod]
        [Priority(5)]
        public void Square()
        {
            calculatorTest.Square();
        }

        [TestMethod]
        [Priority(6)]
        public void AC()
        {
            calculatorTest.AC();
        }

        [TestMethod]
        [Priority(7)]
        public void SeqBinOper()
        {
            calculatorTest.SeqBinOper();
        }

        [TestMethod]
        [Priority(8)]
        public void SquareAfterBinOper()
        {
            calculatorTest.SquareAfterBinOper();
        }

        [TestMethod]
        [Priority(9)]
        public void OperationWithPrevRes()
        {
            calculatorTest.OperationWithPrevRes();
        }
    }
}
