using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    public class FuncParams
    {
        public Func<object, object[]> func { get; set; }
        public object[] parameters { get; set; }
    }
}
