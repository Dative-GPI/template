using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace XXXXX.Context.Fixtures
{
    public class TranslationProvider
    {
        static string[] FILES_PATTERN = new[] { ".vue", ".ts" };
        const string REGEX_PATTERN = @"\$tr\(\s*['""]([\w\.-]*)['""],\s*(?:[']([^']*)[']|[""]([^""]*)[""])\s*\)";
        static List<string> Projects = new List<string>() {
            "../../app/admin/ui/src",
            "../../app/shell/ui/src"
        };

        static Regex Regex = new Regex(REGEX_PATTERN);


        public Dictionary<string, string> GetAllTranslations()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (var project in Projects)
            {
                var files = Directory.GetFiles(project, "*", SearchOption.AllDirectories)
                    .Where(filepath => FILES_PATTERN.Any(pattern => filepath.EndsWith(pattern)));

                foreach (var filepath in files)
                {
                    var content = File.ReadAllText(filepath);
                    var matches = Regex.Matches(content);

                    foreach (Match match in matches)
                    {
                        var translationKey = match.Groups[1].Value;
                        var translationValue = match.Groups[2].Value + match.Groups[3].Value; // Group2 = xxx in 'xxx', Group3 = xxx in "xxx"

                        var translationAdded = result.TryAdd(translationKey, translationValue);

                        if (!translationAdded)
                        {
                            var existingValue = result.ContainsKey(translationKey) ? result[translationKey] : null;

                            if (translationValue == existingValue) continue;

                            var filename = Path.GetFileName(filepath);
                            Console.WriteLine($"Couldn't add translation \"{translationValue}\" for key '{translationKey}' from file {filename}");
                            Console.WriteLine($"Existing translation for this key is \"{existingValue}\"");
                            Console.WriteLine();
                        }
                    }
                }
            }

            return result;
        }
    }
}