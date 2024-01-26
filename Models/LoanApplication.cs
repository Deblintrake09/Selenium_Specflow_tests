using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow_OnlineBank.Specs.Models
{
    internal class LoanApplication
    {

        public string Applicant { get; set; } = string.Empty;

        public int Amount { get; set; } = 0;

        public string Status { get; set; } = "New";  
    }
}
