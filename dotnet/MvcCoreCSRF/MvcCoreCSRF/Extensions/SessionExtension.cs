﻿using Newtonsoft.Json;

namespace MvcCoreCSRF.Extensions
{
    public static class SessionExtension
    {
        public static void SetObject(this ISession session, string key, string value)
        {
            string data = JsonConvert.SerializeObject(value);
            session.SetString(key, data);
        }

        public static T? GetObject<T>(this ISession session, string key)
        {
            string? data = session.GetString(key);

            if (data == null)
            {
                return default;
            }

            T obj = JsonConvert.DeserializeObject<T>(key)!;
            return obj;
        }
    }
}
