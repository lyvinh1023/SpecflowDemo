using OpenQA.Selenium;
using SpecflowDemo.Pages;
using TechTalk.SpecFlow;

namespace SpecflowDemo.Steps
{
    [Binding]
    public class ProjectDetailsSteps
    {
        private readonly ScenarioContext _scenarioContext;
        private ProjectDetailsPage projectDetailsPage;

        public ProjectDetailsSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            projectDetailsPage = new ProjectDetailsPage(_scenarioContext);
        }

        [Then(@"I should see the Project Details page")]
        public void ThenIShouldSeeTheProjectDetailsPage()
        {
            if (projectDetailsPage.IsPageTitleDisplayed())
            {
                Console.WriteLine("Project Details page display");
            }
            else
            {
                Console.WriteLine("Project Details page does not display");
                throw new NoSuchElementException();
            }
        }

        [When(@"I enter project details: (.*), (.*), (.*), (.*)")]
        public void WhenIEnterProjectDetailsAngolaStEmailMailinator_Com(string country, string address, string email, string phone)
        {
            projectDetailsPage.EnterProjectDetails(country, address, email, phone);
        }

        [When(@"I click Save button")]
        public void WhenIClickSaveButton()
        {
            projectDetailsPage.ClickSave();
        }

        [Then(@"The project details info should be saved")]
        public void ThenTheProjectDetailsInfoShouldBeSaved()
        {
            if (projectDetailsPage.IsSavedMessageDisplayed())
            {
                Console.WriteLine("Project Details info is saved");
            }
            else
            {
                Console.WriteLine("Project Details info is not saved");
                throw new NoSuchElementException();
            }
        }
    }
}
