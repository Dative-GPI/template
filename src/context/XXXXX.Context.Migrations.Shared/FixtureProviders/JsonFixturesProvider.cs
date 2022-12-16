

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace XXXXX.Context.Migrations.Shared
{
    public static class JsonFixturesProvider
    {
        public static IEnumerable<T> GetAll<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                Console.Error.WriteLine($"Unable to find file {filePath}");
                return Enumerable.Empty<T>();
            };

            return JsonSerializer.Deserialize<List<T>>(
                File.ReadAllText(filePath)
            );
        }
    }
}