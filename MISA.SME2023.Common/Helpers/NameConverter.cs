using System.Text.RegularExpressions;

namespace MISA.SME2023.Common
{
    public static class NameConverter
    {
        public static string ConvertPascalToSnakeCase(string input)
        {
            return Regex.Replace(input, @"([a-z])([A-Z])", "$1_$2").ToLower();
        }
    }
}
