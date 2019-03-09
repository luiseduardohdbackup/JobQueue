using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    public class Job : Emitter
    {
        public string type;
        internal object id;
        internal int? retry;
        internal bool timeout;
        internal bool death;
        internal long time;

        //internal void emit(string v, object err)
        //{
        //    throw new NotImplementedException();
        //}

        //internal void emit(string v)
        //{
        //    emit(v, null);
        //}

        //internal void off()
        //{
        //    throw new NotImplementedException();
        //}

        //internal void on(string v, Action p)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
