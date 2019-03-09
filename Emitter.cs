using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    public class Emitter
    {
        //public Dictionary<string, List<Func<object, object>>> _callbacks;
        public Dictionary<string, List<Action> > _callbacks;
        //Dictionary<string, List<Func<object, object>>> coalesce(Dictionary<string, List<Func<object, object>>> FirstObject, Dictionary<string, List<Func<object, object>>> SecondObject)
        //{
        //    return Util.Coalesce<Dictionary<string, List<Func<object, object>>>>(FirstObject, SecondObject);
        //}
        Dictionary<string, List<Action>> coalesce(Dictionary<string, List<Action>> FirstObject, Dictionary<string, List<Action>> SecondObject)
        {
            return Util.Coalesce< Dictionary< string, List<Action> > >(FirstObject, SecondObject);
        }
        List<Func<object, object>> coalesce(List<Func<object, object>> FirstObject, List<Func<object, object>> SecondObject)
        {
            return Util.Coalesce<List<Func<object, object>>>(FirstObject, SecondObject);
        }
        List<Action> coalesce(List<Action> FirstObject, List<Action> SecondObject)
        {
            return Util.Coalesce<List<Action>>(FirstObject, SecondObject);
        }
        //public virtual Emitter on(string evnt, Func<object, object> fn)
        //{
        //    addEventListener(evnt, fn);
        //    return this;
        //}
        public virtual Emitter on(string evnt, Action fn)
        {
            addEventListener(evnt, fn);
            return this;
        }
        //public virtual Emitter addEventListener(string evnt, Func<object, object> fn)
        //{
        //    this._callbacks = coalesce(this._callbacks, new Dictionary<string, List<Func<object, object>>>());
        //    (this._callbacks['$' + evnt] = Util.Coalesce(this._callbacks['$' + evnt], new List<Func<object, object>>())).Add(fn);
        //    return this;
        //}
        public virtual Emitter addEventListener(string evnt, Action fn)
        {
            this._callbacks = coalesce(this._callbacks, new Dictionary<string, List<Action>>());
            (this._callbacks['$' + evnt] = coalesce(this._callbacks["$" + evnt], new List<Action>())).Add(fn);
            return this;
        }

        //Not implemented yet

        //public virtual Emitter once(string evnt, Func<object, object> fn)
        //{ 
        //    Action on = () =>
        //    {
        //        this.off(evnt, on);
        //        //fn.apply(this, arguments);

        //    };

        //    on.fn = fn;
        //    this.on(event, on);
        //    return this;
        //}
        /*
        Emitter.prototype.off =
        Emitter.prototype.removeListener =
        Emitter.prototype.removeAllListeners =
        Emitter.prototype.removeEventListener = function(event, fn) 
         */
        internal Emitter off(string evnt)
        {
            _callbacks.Remove(evnt);
            return this;
        }
        public virtual Emitter off(string evnt = null, Action fn = null)
        {
            return removeListener( evnt, fn);
            //return this;
        }
        public virtual Emitter removeListener(string evnt = null, Action fn = null)
        {
            return removeAllListeners(evnt, fn);
            //return this;
        }
        public virtual Emitter removeAllListeners(string evnt = null, Action fn = null)
        {
            return removeEventListener( evnt ,  fn );
            //return this;
        }
        //public virtual Emitter removeEventListener(string evnt = null, Func<object, object> fn = null)
        public virtual Emitter removeEventListener(string evnt = null, Action fn = null)
        { 
            this._callbacks = coalesce (this._callbacks , new Dictionary<string, List<Action>>());

            // all
            //if (0 == arguments.length) {
            if ( evnt == null || fn == null)
            {
                this._callbacks = new Dictionary<string, List<Action>>();
                return this;
            }

            // specific event
            var callbacks = this._callbacks["$" + evnt];
            if ( ! ( callbacks != null ) ) 
                return this;

            // remove all handlers
            //if (1 == arguments.length) {
            if (fn == null)
            {
                this._callbacks.Remove("$" + evnt);
                return this;
            }

            // remove specific handler
            //var cb;
            for (var i = 0; i < callbacks.Count; i++) {
                var cb = callbacks[i];
                if (cb == fn )
                {
                    callbacks.RemoveAt(i);
                    break;
                }
            }

            // Remove event specific arrays for event types that no
            // one is subscribed for to avoid memory leak.
            if (callbacks.Count == 0) {
                //delete this._callbacks['$' + evnt];
                this._callbacks.Remove("$" + evnt);
            }

            return this;
        }


        public virtual Emitter emit(string evnt, params object[] arguments)
        {
            this._callbacks = coalesce ( this._callbacks, new Dictionary<string, List<Action>>());
            //https://stackoverflow.com/questions/2125714/explanation-of-slice-call-in-javascript
            //var args = (new object[0]).slice().call(arguments, 1);
            var args = arguments;
            var callbacks = this._callbacks['$' + evnt];

            if ( callbacks != null ) {
                callbacks = callbacks.slice(0);
                for (int i = 0,  len = callbacks.Count; i<len; ++i) {
                  callbacks[i].apply(this, args);
                }
            }
            return this;
            //return emit( evnt, null);
        }
        //public virtual Emitter emit(string evnt,object o)
        //{
        //    return this;
        //}
        //public virtual List<Func<object, object>> listeners(string evnt)
        //{
        //    return coalesce(this._callbacks['$' + evnt], new List<Func<object, object>>());
        //}
        public virtual List<Action> listeners(string evnt)
        {
            return coalesce(this._callbacks['$' + evnt], new List<Action>());
        }
        public virtual int hasListeners(string evnt)
        {
            return this.listeners(evnt).Count;
        }


        public void off()
        {
            throw new NotImplementedException();
        }
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
