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
    class Employee
    {
        public override string ToString()
        {
            return Name;
        }
        public Employee(object name)
        {
            Name = name?.ToString();
        }
        public string Name { get; set; }
    }
    class Crew
    {
        public override string ToString()
        {
            return Name;
        }
        public Crew(object name)
        {
            Name = $"Crew {name}";
        }
        public string Name { get; set; }
    }
    class Job
    {
        public override string ToString()
        {
            return Name;
        }
        public Job(object name)
        {
            Name = name.ToString();
        }
        public string Name { get; set; }
    }

    class EmployeeSchedule
    {
        

        public Employee Employee { get; set; }
        public Crew Crew { get; set; }
        public Job Job { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var schedules = GenerateData();

            schedules = schedules
                .OrderBy(s => s.Employee.Name)
                .ToList();

            foreach (var schedule in schedules)
            {
                Console.WriteLine($"Job: {schedule.Job}; " +
                    $"Employee: {schedule.Employee}; " +
                    $"Crew: {schedule.Crew}");
            }

            Console.WriteLine("Let me see if I can rearrange that into a table...");

            Console.WriteLine("\n\n\n");

            int columnWidth = GetLongestEmployeeName(schedules) + 2;
            Console.WriteLine($"column width: {columnWidth}");

            var jobNames = schedules.Select(s => s.Job.Name).Distinct().ToList();
            var header = CreateRow(jobNames, columnWidth);
            Console.WriteLine(header);
            int columnCount = jobNames.Count;
            PrintHorizontalLine((columnWidth + 2) * columnCount);

            var crewNames = schedules.Select(s => s.Crew.Name).Distinct().ToList();
            var crews = CreateRow(crewNames, columnWidth);
            Console.WriteLine(crews);

            var groups = schedules.GroupBy(s => s.Job);
            var rowCount = groups.Max(gr => gr.Count());

            for (int row = 0; row < rowCount; row++)
            {
                var rowNames = groups.Select(g => SelectEmployeeAt(g, row)).ToList();
                Console.WriteLine(CreateRow(rowNames, columnWidth));
            }

        }

        private static string SelectEmployeeAt(IGrouping<Job, EmployeeSchedule> g, int row)
        {
            var employees = g.Select(e => e.Employee);
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

        private static int GetLongestEmployeeName(List<EmployeeSchedule> schedules)
        {
            int max = 0;
            foreach (var item in schedules)
            {
                max = Math.Max(max, item.Employee.Name.Length);
            }
            return max;
        }

        private static List<EmployeeSchedule> GenerateData()
        {
            var employees = new List<Employee>();
            for (int i = 0; i < 25; i++)
            {
                employees.Add(new Employee(Names[i]));
            }

            var crews = new List<Crew>();
            for (int i = 0; i < 5; i++)
            {
                crews.Add(new Crew(i));
            }

            var jobs = new List<Job>();
            for (int i = 0; i < 5; i++)
            {
                jobs.Add(new Job(Jobs[i]));
            }

            var result = new List<EmployeeSchedule>();
            var rand = new Random();
            for (int i = 0; i < rand.Next(15, 25); i++)
            {
                var job = rand.Next(6) == 5 ?
                    jobs[0] : jobs[i % 5];



                result.Add(new EmployeeSchedule()
                {
                    Employee = employees[i],
                    Crew = crews[i % 5],
                    Job = job,
                });
            }

            return result;
        }

        private static List<string> Names => new List<string>()
        {
            "Aldair Miranda Provisor*",
            "Andy Byler",
            "Benjamin Perez",
            "Brent Nolt",
            "Brian Ramirez",
            "Brian Slattery",
            "Bruce Smith'",
            "Bryan Robles",
            "Carlos Alfredo Portugal*",
            "Carol Snyder",
            "Chris Peachy",
            "Ciro Pina Loyola*",
            "Damian Long",
            "Daniel Casarrubias",
            "Edilberto Portugal Mendoza*",
            "Elias Moyao-Ramirez",
            "Eric Schmeelk",
            "Ezra Weaver",
            "Felipe Diaz",
            "Fernando Martinez Reyes*",
            "Figgy-Robert Byler",
            "Jacob Roberts",
            "Jacob McCowen",
            "Javier Dominguez",
            "John Mullen",
        };

        private static List<string> Jobs => new List<string>()
        {
            "100' 3k Sukup Leg",
            "Replace Tube & Flight",
            "3,500 BPH Conveyor 38'",
            "21' 15RW CHT w/ Reclaim",
            "Extras For Swap",
        };
    }
}
