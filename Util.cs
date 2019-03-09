using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    public static class Util
    {
        public static T Coalesce<T>(T FirstObject, T SecondObject) where T : class
        {
            if (FirstObject != null)
                return FirstObject;
            else
                return SecondObject;
        }

        public static int ms(string v)
        {
            return 0; throw new NotImplementedException();
        }

        //public static object Coalesce(object FirstObject, object SecondObject )
        //{
        //    if (FirstObject != null)
        //        return FirstObject;
        //    else
        //        return SecondObject;
        //}
    }
}
