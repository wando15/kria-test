using System.Text.Json;

namespace Kria_Tests.UnitTests.Utils
{
    public static class Utils
    {
        public static T ReadFile<T>(string filePath) where T : new()
            => JsonSerializer.Deserialize<T>(File.OpenRead(filePath)) ?? new T();
    }
}
