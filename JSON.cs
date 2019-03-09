using System;
using Newtonsoft.Json;

namespace TestConsole
{
    internal class JSON
    {
        internal static string stringify(object o)
        {
            throw new NotImplementedException();
        }

        internal static T parse<T>(string s)
        {
            //throw new NotImplementedException();
            return JsonConvert.DeserializeObject<T>(s);
        }
    }
}