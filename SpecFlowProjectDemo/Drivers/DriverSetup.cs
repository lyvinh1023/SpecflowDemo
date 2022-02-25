using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SpecflowDemo.Drivers
{
    public class DriverSetup
    {
        public IWebDriver InitDriver() {
            IWebDriver driver = new ChromeDriver();
            //driver = new FirefoxDriver("D:\\poc");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            return driver;
        }
    }
}
