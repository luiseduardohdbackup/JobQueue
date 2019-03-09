using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestConsole
{
    //SessionaStorage in memory, Dictionary implementation.
    class SessionStorage
    {
        //public static List<string> list = new List<string>();
        public static Dictionary<string, string> dict = new Dictionary<string, string>();
        //https://developer.mozilla.org/es/docs/Web/API/Storage/setItem
        public void setItem(string key, string data)
        {
            dict.Add(key, data);
        }

        public string getItem(string key)
        {
            return dict[key];
        }

        public void removeItem(string key)
        {
            dict.Remove(key);
        }

        public void clear(object p)
        {
            dict.Clear();
        }

        public object key(int n)
        {
            return dict[dict.Keys.ToList()[n]];
        }
    }
}