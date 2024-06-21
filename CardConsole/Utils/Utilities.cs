using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardConsole.Utils
{
    public static class Utilities
    {
        public static string ListToString<T>(IEnumerable<T> list)
        {
            return "[" + string.Join(", ", list.Select(item =>
            item is IEnumerable<object> && !(item is string) ?
            ListToString((IEnumerable<object>)item) :
            item?.ToString() ?? "null")) + "]";
        }

        public static string DictionaryToString(Dictionary<string, object> dict)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("{");

            foreach (var item in dict)
            {
                string valueString = "";
                if (item.Value is string)
                {
                    valueString = $"\"{item.Value}\"";
                }
                else if (item.Value is IEnumerable enumerable && !(item.Value is IDictionary) && !(item.Value is IEnumerable<KeyValuePair<object, object>>))
                {
                    // Handle non-dictionary IEnumerable separately
                    var listItems = enumerable.Cast<object>().ToList();
                    valueString = ListToString(listItems);
                }
                else if (item.Value is IFormattable)
                {
                    // Use InvariantCulture to ensure consistent formatting
                    valueString = ((IFormattable)item.Value).ToString(null, CultureInfo.InvariantCulture);
                }
                else
                {
                    valueString = item.Value.ToString();
                }
                sb.AppendLine($"\t\"{item.Key}\": {valueString},");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }
    }
}
