using SpecFlow_OnlineBank.Specs.Models;
using TechTalk.SpecFlow.Assist;

namespace SpecFlow_OnlineBank.Specs.StepDefinitions
{
    [Binding]
    public class LoanApplicationProcessingStepDefinitions
    {
        private IEnumerable<LoanApplication>? loanApplications;

        [Given(@"the loan application workload contains the following applications:")]
        public void GivenTheLoanApplicationWorkloadContainsTheFollowingApplications(Table table)
        {
            loanApplications = table.CreateSet<LoanApplication>();
        }

        [When(@"the loan applications for (.+) are approved")]
        public void WhenTheLoanApplicationsForSusanAreApproved(string applicant)
        {
            foreach(LoanApplication loanApplication in loanApplications!)
            {
                if(loanApplication.Applicant.Equals(applicant))
                {
                    loanApplication.Status = "Approved";
                }
                
            }
        }

        [Then(@"the loan application workload contains the following applications:")]
        public void ThenTheLoanApplicationWorkloadContainsTheFollowingApplications(Table table)
        {
            table.CompareToSet(loanApplications);
        }
    }
}
