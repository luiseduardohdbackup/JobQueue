using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    static class DelegateExtensions
    {
        public static void apply(this Delegate @delegate, params object[] list)
        {
            @delegate.DynamicInvoke(list);
        }
    }
}
