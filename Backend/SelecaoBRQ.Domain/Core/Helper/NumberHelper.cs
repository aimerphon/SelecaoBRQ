using System.Text.RegularExpressions;

namespace SelecaoBRQ.Domain.Core.Helper
{
    public static class NumberHelper
    {
        public static string GetNumber(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            return new Regex(@"[^\d]").Replace(value, "");
        }
    }
}
