using Newtonsoft.Json;
using System;

namespace WebIU.Extensions
{
    public static class SessionExtensionMethots
    {
        public static void SetObject(this ISession session,string key,object value)
        {
            string objectString = JsonConvert.SerializeObject(value);
            session.SetString(key,objectString);
        }
        public static T GetObject<T>(this ISession session,string key) where T : class
        {
            string objectString = session.GetString(key);
            if (string.IsNullOrEmpty(objectString))
                return null;
            T valueDesirialize = JsonConvert.DeserializeObject<T>(objectString);
            return valueDesirialize;
        }

       
    }
}
