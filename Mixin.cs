using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    class Mixin
    {
        //mixin mix, etc
        public virtual object mixin(object obj)
        {
            //for (var key in Emitter.prototype)
            //{
            //    obj[key] = Emitter.prototype[key];
            //}
            return obj;
        }
    }
}
