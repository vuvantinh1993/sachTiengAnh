using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CTIN.Common.Extentions
{
    public static class ObjectExtention
    {
        public static T MapToObject<T>(this object source)
        {
            return JObject.FromObject(source).ToObject<T>();
        }

        public static T MapToArray<T>(this object source)
        {
            return JArray.FromObject(source).ToObject<T>();
        }

        public static T Patch<T>(this T objectValue, object toSource)
        {
            var source = JObject.FromObject(objectValue);
            var result = JObject.FromObject(toSource);
            foreach (var pr in result)
            {
                if (source.Properties().Any(x=>x.Name.ToLower() == pr.Key.ToLower()))
                {
                    SetValueObject(pr, source);
                }                
            }
            return source.ToObject<T>();
        }

        private static void SetValueObject(this KeyValuePair<string,JToken> pr, JObject result)
        {
            if (pr.Value.Type == JTokenType.Object)
            {
                foreach (var item in pr.Value as JObject)
                {
                    if (result.Value<JObject>(pr.Key).Properties().Any(x=>x.Name.ToLower() == item.Key.ToLower()))
                    {
                        SetValueObject(item, result.Value<JObject>(pr.Key));
                    }                    
                }
            }
            else
            {
                result[pr.Key] = pr.Value;
            }
        }        
    }
}
