using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    public static class ListActionExtensions
    {
        public static List<Action> slice( this List<Action> _this, params object[] list)
        {
            return new List<Action>();
        }
    }
}
