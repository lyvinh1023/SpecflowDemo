using OpenQA.Selenium;
using SpecflowParallel.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;


namespace SpecflowParallel.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private LoginPage loginPage;

        public LoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            loginPage = new LoginPage(_scenarioContext);
        }

        [Given(@"I am navigated to Login page")]
        public void GivenIAmNavigatedToLoginPage()
        {
            loginPage.LoadLoginPage();
        }

        [When(@"I enter username and password")]
        public void WhenIEnterUsernameAndPassword(Table table)
        {
            dynamic values = table.CreateDynamicInstance();
            loginPage.EnterLogin("" + values.Username, "" + values.Password);
        }

        [When(@"I click Login button")]
        public void WhenIClickLoginButton()
        {
            loginPage.ClickLogin();
        }

        [Then(@"I should see the password error message")]
        public void ThenIShouldSeeTheErrorMessage()
        {
            if (loginPage.IsPasswordErrorDisplayed())
            {
                Console.WriteLine("Password error message displays");
            }
            else
            {
                Console.WriteLine("Password error message does not display");
                throw new NoSuchElementException();
            }
        }
    }
}
