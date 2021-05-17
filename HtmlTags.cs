using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow1
{
    public static class HtmlTags
    {
        public readonly static string EmptyCell = "<td />\n";
        public static string WrapIntoDocument(string title, string body)
        {
            string document = documentHeader;
            document += "\n<title>\n";
            document += title;
            document += "\n</title>\n</head>\n<body>\n";
            document += body;
            document += "\n</body>\n</html>";
            return document;
        }

        public static string HeaderRow(IList<string> values)
        {
            var header = "<th>";
            var headerEnd = "</th>\n";

            var table = new StringBuilder();

            foreach (var item in values)
            {
                table.Append(header);
                table.Append(item);
                table.Append(headerEnd);
            }

            return table.ToString();
        }

        public static string WrapIntoRow(IList<string> values)
        {
            var cell = "<td>";
            var cellEnd = "</td>\n";

            var table = new StringBuilder();

            foreach (var item in values)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    table.Append(EmptyCell);
                    continue;
                }
                table.Append(cell);
                table.Append(item);
                table.Append(cellEnd);
            }

            return table.ToString();
        }

        public static string WrapIntoTable(IList<string> rows)
        {
            var tableRow = "<tr>\n";
            var tableRowEnd = "</tr>\n";

            var table = new StringBuilder();

            table.Append("\n<table>");
            foreach (var item in rows)
            {
                table.Append(tableRow);
                table.Append(item);
                table.Append(tableRowEnd);
            }
            table.Append("\n</table>");

            return table.ToString();
        }

        private readonly static string documentHeader =
@"<!DOCTYPE html>
<html>
<head>
<style>
table {
  font-family: sans-serif;
  border-collapse: collapse;
  width: 100%;
}

td, th {
  border: 1px solid #dddddd;
  text-align: left;
  padding: 8px;
}

td {
  font-size: .8em;
}

tr:nth-child(even) {
  background-color: #dddddd;
}
</style>";
    }
}
