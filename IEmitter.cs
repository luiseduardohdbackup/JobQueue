using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    class IEmitter : IMixin
    {
        Dictionary<string, List<Func<object, object>>> _callbacks { get; set; }
        Func<Dictionary<string, List<Func<object, object>>>, Dictionary<string, List<Func<object, object>>>, Dictionary<string, List<Func<object, object>>>> coalesce { get; set; }

        //List<Func<object, object>> coalesce(List<Func<object, object>> FirstObject, List<Func<object, object>> SecondObject)
        //{
        //    return Util.Coalesce<List<Func<object, object>>>(FirstObject, SecondObject);
        //}

        public Func<Emitter, string, Func<object, object>> on { get; set; }
        public Func<Emitter, string, Func<object, object>> addEventListener { get; set; }

        public Func<Emitter, string, Func<object, object> > once { get; set;}
        public Func  <Emitter,string , Func<object, object> > off { get; set; }
        public Func  <Emitter,string , Func<object, object> > removeListener { get; set; }
        public Func <Emitter,string , Func<object, object> > removeAllListeners { get; set; }
        public Func <Emitter,string , Func<object, object> > removeEventListener { get; set; }


        public Func <Emitter,string > emit { get; set; }
        public Func <List<Func<object, object>>,string > listeners { get; set; }
        public Func <int,string > hasListeners { get; set; }
    }
}
