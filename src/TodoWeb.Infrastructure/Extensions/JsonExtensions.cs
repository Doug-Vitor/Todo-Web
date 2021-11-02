using System.Text.Json;
using System.Threading.Tasks;

namespace TodoWeb.Infrastructure.Extensions
{
    public static class JsonExtensions
    {
        private static readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        public static T FromJson<T>(this string json) =>
            JsonSerializer.Deserialize<T>(json, _jsonOptions);

        public static async Task<T> FromJsonAsync<T>(this string json) => 
            await JsonSerializer.DeserializeAsync<T>(json.GenerateStreamFromString(), _jsonOptions);

        public static string ToJson<T>(this T obj) =>
            JsonSerializer.Serialize(obj, _jsonOptions);
    }
}
