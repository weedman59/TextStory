using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextStory.Services
{
    public class AuthMessageSenderOptions
    {
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }

        public string SMSAccountIdentification { get; set; }
        public string SMSAccountPassword { get; set; }
        public string SMSAccountFrom { get; set; }



    }
}
