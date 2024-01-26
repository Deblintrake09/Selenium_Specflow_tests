using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SpecFlow_OnlineBank.Specs.Pages;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace SpecFlow_OnlineBank.Specs.StepDefinitions
{
    [Binding]
    [Scope(Tag = "userinterface")]
    public class LoanApplicationStepDefinitions
    {

        private WebDriver driver;

        [BeforeScenario]
        public void StartBrowser()
        {
            
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--headless=new");


            this.driver = new ChromeDriver(options);
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //this.driver.Manage().Window.Maximize();
        }

        [Given(@"John is an active ParaBank customer")]
        public void GivenJohnIsAnActiveParaBankCustomer()
        {
            new LoginPage(this.driver).LoginAs("john", "demo");
        }

        [When(@"they apply for (\d+) loan")]
        public void WhenTheyApplyForLoan(int loanAmount)
        {
            new AccountOverviewPage(this.driver).SelectMenuItem("Request Loan");
            new RequestLoanPage(this.driver).SubmitLoanRequest(loanAmount, 1000, 13344);
        }

        [Then(@"the loan application is (approved|denied)")]
        public void ThenTheLoanApplicationIsApproved(string expectedResult)
        {
            Assert.That(new RequestLoanPage(this.driver).GetLoanApplicationResult(), Is.EqualTo(expectedResult));
        }


        [When(@"their monthly income is (\d+)")]
        public void WhenTheirMonthlyIncomeIs(int monthlyIncome)
        {

        }

        [AfterScenario]
        public void CloseBrowser()
        {
            this.driver.Quit();
        }
    }
}
