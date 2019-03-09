using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    public static class ActionExtensions
    {

        public static object call(this Action _this, object thisArgs, object args1)
        {
            return new object();
        }
        //public static object apply( this Action _this, object thisArgs, object args1)
        public static object apply(this Action _this, params object[] args)
        {
            return new object();
        }
    }
}
