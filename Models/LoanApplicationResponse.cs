using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow_OnlineBank.Specs.Models
{
    internal class LoanApplicationResponse
    {
        public string responseDate { get; set; }
        public string loanProviderName { get; set; }
        public bool approved { get; set; }
        public string message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int accountId { get; set; }
    }
}
