using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    class JavascriptDelegates
    {
        public delegate T ParamsAction<T>(params object[] args);
        public T ParamsActionFunction<T>(ParamsAction<T> f)
        {
            T result = f();
            return result;
        }
    }
}
