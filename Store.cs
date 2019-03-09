using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    public class Store
    {
        public string _ = "";
        public LocalStorage ls ;    
        public Store(string prefix)
        {
            this._ = coalesce(_ , "");
        }

        private string coalesce(string a, string b)
        {
            throw new NotImplementedException();
        }
        private object coalesce(object a, object b)
        {
            throw new NotImplementedException();
        }

        public Store prefix(string prefix ) {
            return new Store(prefix);
        }
        public Store ns(string prefix)
        {
            return this.prefix( prefix);
        }
        public int set(string key, object val)
        {
            var data="";
            try
            {
                data = JSON.stringify( coalesce ( val , null));
                ls.setItem(this._ + key, data);
                return data.Length;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        public Exception setItem(string key, string val)
        {
            if ( ! (val != null) ) return null;
            try
            {
                ls.setItem(this._ + key, val);
                return null;
            }
            catch (Exception e)
            {
                return e;
            }
        }

        public Job get(string key)
        {
            try
            {
                return new Job();// JSON.parse(ls.getItem(this._ + coalesce(key , "")));//TODO
            }
            catch (Exception _error)
            {
                return null;
            }
        }

        internal List<string> get()
        {
            //throw new NotImplementedException();
            return new List<string>();
        }
    }
}
