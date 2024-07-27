using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EmployeeManagerAPI.Models
{
    public class CustomBooleanConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            bool booleanValue = (bool)value;
            writer.WriteValue(booleanValue ? "Yes" : "No");
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            if (token.Type == JTokenType.String)
            {
                string stringValue = token.ToString().ToLower();
                if (stringValue == "yes") return true;
                if (stringValue == "no") return false;
            }
            throw new JsonSerializationException("Invalid boolean value.");
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }
    }
}



