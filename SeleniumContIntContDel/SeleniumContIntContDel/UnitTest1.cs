using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Reflection;

namespace SeleniumContIntContDel
{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            //Here we are running the tests in headless mode.
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), chromeOptions);

            //This is for running the test with GUI
            //driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }
        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }


        [Test]
        public void Test1()
        {
            var wait=new WebDriverWait(driver,TimeSpan.FromSeconds(10));



            driver.Navigate().GoToUrl("https://www.google.com");
            driver.FindElement(By.Name("q")).SendKeys("Cheese" + Keys.Enter);
            var pageTitle = "Cheese - Google Search";

            

            wait.Until(driver=> driver.Title == pageTitle);

            Assert.AreEqual(pageTitle, driver.Title);
        }
    }
}