using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    public class Date //: DateTime
    {
        public long getTime()
        {
            //throw new NotImplementedException();
            return DateTime.Now.ToUniversalTime().Ticks;
        }
    }
}
