using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Communication
{
    public class TwilioSmsClient : ISmsClient
    {
        public void SendText(string to, string from, string message)
        {
            //New Twilio Client call code
            throw new NotImplementedException();
        }
    }
}
