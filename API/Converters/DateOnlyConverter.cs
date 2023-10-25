using System.Globalization;
using System.Text.Json;
using Newtonsoft.Json;

namespace API.Converters
{
    public class DateOnlyConverter : JsonConverter<DateOnly>
    {
        private const string Format = "yyyy-MM-dd";
        public override DateOnly ReadJson(JsonReader reader,
                Type objectType,
                DateOnly existingValue,
                bool hasExistingValue,
                Newtonsoft.Json.JsonSerializer serializer) =>
                DateOnly.ParseExact((string)reader.Value, Format, CultureInfo.InvariantCulture);

        public override void WriteJson(JsonWriter writer, DateOnly value, Newtonsoft.Json.JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
