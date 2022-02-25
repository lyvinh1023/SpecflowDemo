using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowParallel.Pages
{
    public class LoginPage
    {

        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;

        public LoginPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext.Get<IWebDriver>("CurrentDriver");
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "name")]
        [CacheLookup]
        private readonly IWebElement txtUsername;

        [FindsBy(How = How.Id, Using = "password")]
        [CacheLookup]
        private readonly IWebElement txtPassword;

        [FindsBy(How = How.Id, Using = "login")]
        [CacheLookup]
        private readonly IWebElement btnLogin;

        [FindsBy(How = How.XPath, Using = "//div[text()=\"Password is invalid\"]")]
        private readonly IWebElement errPassword;

        public void LoadLoginPage() {
            driver.Url = "https://example.testproject.io/web/";
        }

        public void EnterLogin(string email, string password)
        {
            txtUsername.SendKeys(email);
            txtPassword.SendKeys(password);
        }

        public void ClickLogin() {
            btnLogin.Click();
            Thread.Sleep(3000);
        }

        public bool IsPasswordErrorDisplayed() {
            return errPassword.Displayed;
        }
    }
}
