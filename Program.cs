using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.Text;
using System.Numerics;
using System.Dynamic;

namespace StackOverflow1
{
    class Program
    {
        static void Main(string[] args)
        {
            var schedules = MockData.GenerateData();

            schedules = schedules
                .OrderBy(s => s.int_crew.Name)
                .ThenBy(s => s.int_employee.Name)
                .ToList();

            foreach (var schedule in schedules)
            {
                Console.WriteLine($"Job: {schedule.int_job}; " +
                    $"Employee: {schedule.int_employee}; " +
                    $"Crew: {schedule.int_crew}");
            }

            Console.WriteLine("\nLet me see if I can rearrange that into a table...\n");
            CreateAsciiTable(schedules);

            Console.WriteLine("\nHere's some html efforts... \n");

            CreateHtmlTable(schedules);
        }

        private static void CreateAsciiTable(List<tblEmployeeSchedule> schedules)
        {
            int columnWidth = GetLongestEmployeeName(schedules) + 2;
            Console.WriteLine($"column width: {columnWidth}");

            var jobNames = schedules.Select(s => s.int_job.Name).Distinct().ToList();
            var header = CreateRow(jobNames, columnWidth);
            Console.WriteLine(header);
            int columnCount = jobNames.Count;
            PrintHorizontalLine((columnWidth + 2) * columnCount);

            var crewNames = schedules.Select(s => s.int_crew.Name).Distinct().ToList();
            var crews = CreateRow(crewNames, columnWidth);
            Console.WriteLine(crews);

            var groups = schedules.GroupBy(s => s.int_crew);
            var rowCount = groups.Max(gr => gr.Count());

            for (int row = 0; row < rowCount; row++)
            {
                var rowNames = groups.Select(g => SelectEmployeeAt(g, row)).ToList();
                Console.WriteLine(CreateRow(rowNames, columnWidth));
            }
        }

        private static void CreateHtmlTable(List<tblEmployeeSchedule> schedules)
        {
            var crews = new List<string>();
            var jobs = new List<string>();
            var rows = new List<string>();

            var groups = schedules.GroupBy(s => s.int_crew);
            var rowCount = groups.Max(gr => gr.Count());

            crews.AddRange(groups.Select(gr => gr.Key.Name));
            foreach (var item in groups)
            {
                jobs.Add(item.FirstOrDefault()?.int_job?.Name);
            }

            for (int row = 0; row < rowCount; row++)
            {
                
                var rowNames = groups.Select(g => SelectEmployeeAt(g, row)).ToList();
                rows.Add(HtmlTags.WrapIntoRow(rowNames));
            }

            var headers = new string[] { HtmlTags.HeaderRow(crews),
            HtmlTags.HeaderRow(jobs)};

            var table = new List<string>();
            table.AddRange(headers);
            table.AddRange(rows);
            var htmlTable = HtmlTags.WrapIntoTable(table);

            var title = $"Daily Schedule Notification for {DateTime.Today:ddd MMM d}";

            var htmlDocument = HtmlTags.WrapIntoDocument(title, htmlTable);
            Console.WriteLine(htmlDocument);
        }

        private static string SelectEmployeeAt(IGrouping<tblCrew, tblEmployeeSchedule> g, int row)
        {
            var employees = g.Select(e => e.int_employee);
            if (employees.Count() > row)
            {
                return employees.ElementAt(row)?.Name ?? string.Empty;
            }
            return string.Empty;
        }

        private static void PrintHorizontalLine(int width)
        {
            for (int i = 0; i < width; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }

        private static string CreateRow(List<string> rowNames, int columnWidth)
        {
            var row = string.Empty;

            foreach (var rowName in rowNames)
            {
                var name = rowName.PadRight(columnWidth);
                row += $"{name} |";
            }
            return $"{row}";
        }

        private static int GetLongestEmployeeName(List<tblEmployeeSchedule> schedules)
        {
            int max = 0;
            foreach (var item in schedules)
            {
                max = Math.Max(max, item.int_employee.Name.Length);
            }
            return max;
        }

    }
}
