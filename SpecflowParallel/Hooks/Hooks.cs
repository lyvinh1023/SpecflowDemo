using OpenQA.Selenium;
using SpecflowParallel.Drivers;
using System;
using TechTalk.SpecFlow;

namespace SpecflowParallel.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext) {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            Console.WriteLine("Selenium webdriver starts");
            DriverSetup driverSetup = new DriverSetup();
            _scenarioContext.Set(driverSetup.InitDriver(), "CurrentDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            Console.WriteLine("Selenium webdriver stops");
            _scenarioContext.Get<IWebDriver>("CurrentDriver").Quit();
        }
    }
}