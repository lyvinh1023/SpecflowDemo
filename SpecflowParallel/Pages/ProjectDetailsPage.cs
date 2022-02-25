using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecflowParallel.Pages
{
    public class ProjectDetailsPage
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;

        public ProjectDetailsPage(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            driver = _scenarioContext.Get<IWebDriver>("CurrentDriver");
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//h1[text()=\"Community Powered Test Automation\"]")]
        [CacheLookup]
        private readonly IWebElement h1Title;

        [FindsBy(How = How.Id, Using = "country")]
        [CacheLookup]
        private readonly IWebElement cboCountry;

        [FindsBy(How = How.Id, Using = "address")]
        [CacheLookup]
        private readonly IWebElement txtAddress;

        [FindsBy(How = How.Id, Using = "email")]
        [CacheLookup]
        private readonly IWebElement txtEmail;

        [FindsBy(How = How.Id, Using = "phone")]
        [CacheLookup]
        private readonly IWebElement txtPhone;

        [FindsBy(How = How.Id, Using = "save")]
        [CacheLookup]
        private readonly IWebElement btnSave;

        [FindsBy(How = How.Id, Using = "logout")]
        [CacheLookup]
        private readonly IWebElement btnLogout;

        [FindsBy(How = How.XPath, Using = "//span[text()=\"Saved\"]")]
        [CacheLookup]
        private readonly IWebElement spnSaved;
        

        public bool IsPageTitleDisplayed() {
            return h1Title.Displayed;
        }

        public void EnterProjectDetails(string country, string address, string email, string phone)
        {
            SelectElement select = new SelectElement(cboCountry);
            select.SelectByText(country);
            txtAddress.SendKeys(address);
            txtEmail.SendKeys(email);
            txtPhone.SendKeys(phone);
        }

        public void ClickSave() {
            btnSave.Click();
            Thread.Sleep(3000);
        }

        public void ClickLogout()
        {
            btnLogout.Click();
            Thread.Sleep(3000);
        }

        public bool IsSavedMessageDisplayed()
        {
            return spnSaved.Displayed;
        }
    }
}
