using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Reflection;

namespace SeleniumContIntContDel
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            var chromeOptions=new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            driver=new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),chromeOptions);
        }
        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }


        [Test]
        public void Test1()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.google.com");
            driver.FindElement(By.Name("q")).SendKeys("Cheese" + Keys.Enter);
            var pageTitle = "Cheese - Google Search";
            Assert.AreEqual(pageTitle, driver.Title);
        }
    }
}