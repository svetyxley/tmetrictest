using NUnit.Framework;
using OpenQA.Selenium;

namespace Authorization
{
    public class Tests
    {
        private IWebDriver driver;
        private readonly By _loginButton = By.Id("login");
        private readonly By _EmailError = By.Id("Username-error");
        private readonly By _PassError = By.Id("Password-error");

        private const string _expectedEmailError = "Email is required.";
        private const string _expectedPassError = "Password is required.";

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Navigate().GoToUrl("https://app.tmetric.com/");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void EmptyEmailAndPassErrors()
        {
            var signin = driver.FindElement(_loginButton);
            signin.Click();

            var actualEmailError = driver.FindElement(_EmailError).Text;
            var actualPassError = driver.FindElement(_PassError).Text;

            Assert.AreEqual(_expectedEmailError, actualEmailError, "Wrong or missing message");
            Assert.AreEqual(_expectedPassError, actualPassError, "Wrong or missing message");
        }

        [TearDown]

        public void TearDown()
        { 
        
        }
    }
}