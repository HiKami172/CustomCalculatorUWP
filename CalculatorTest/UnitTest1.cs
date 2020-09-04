using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Remote;
using CalculatorTesting;

namespace CalculatorTestAutomation
{
    [TestClass]
    public class OperationsTests
    {
        protected const string AppDriverUrl = "http://127.0.0.1:4723";
        protected const string AppID = "6e5f3ee8-9f6a-43c5-8bdd-de9087470117_0krc4rn5z6t7c!App";
        private static RemoteWebDriver AppSession;
        private static CalculatorTest calculatorTest;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("app", AppID);
            AppSession = new RemoteWebDriver(new Uri(AppDriverUrl), cap);
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
        public void Sum()
        {
            calculatorTest.Sum();
        }

        [TestMethod]
        public void Difference()
        {
            calculatorTest.Difference();
        }

        [TestMethod]
        public void Multiplication()
        {
            calculatorTest.Multiplication();
        }

        [TestMethod]
        public void Division()
        {
            calculatorTest.Division();
        }

        [TestMethod]
        public void DivisionByZero()
        {
            calculatorTest.DivisionByZero();
        }

        [TestMethod]
        public void Square()
        {
            calculatorTest.Square();
        }

        [TestMethod]
        public void AC()
        {
            calculatorTest.AC();
        }

        [TestMethod]
        public void SeqBinOper()
        {
            calculatorTest.SeqBinOper();
        }

        [TestMethod]
        public void SquareAfterBinOper()
        {
            calculatorTest.SquareAfterBinOper();
        }

        [TestMethod]
        public void OperationWithPrevRes()
        {
            calculatorTest.OperationWithPrevRes();
        }
    }
}
