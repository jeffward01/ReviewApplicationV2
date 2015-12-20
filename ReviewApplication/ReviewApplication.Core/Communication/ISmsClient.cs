using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApplication.Core.Communication
{
    public interface ISmsClient
    {
        void SendText(string to, string from, string message);
    }
}


//TODO: ask about Twilio SMS client Again