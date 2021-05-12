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
            Name = $"Employee {name}";
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
            Name = $"Job {name}";
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

            schedules = schedules.OrderBy(s => s.Crew.Name).ThenBy(s => s.Job.Name).ToList();

            foreach (var schedule in schedules)
            {
                Console.WriteLine($"Job: {schedule.Job}; " +
                    $"Employee: {schedule.Employee}; " +
                    $"Crew: {schedule.Crew}");
            }

            Console.WriteLine("Let me see if I can rearrange that into a table...");

            Console.WriteLine("\n\n\n");

            int columnWidth = GetLongestEmployeeName(schedules) + 10;
            Console.WriteLine($"column width: {columnWidth}");

            var header = string.Empty;
            var jobNames = schedules.Select(s => s.Job.Name).Distinct().ToList();
            foreach (var name in jobNames)
            {
                var job = name.PadRight(columnWidth);
                header += $"{job} |";
            }
            Console.WriteLine(header);
            Console.WriteLine();
            for (int i = 0; i < jobNames.Count * (columnWidth + 2); i++)
            {
                Console.Write("=");
            }
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
                employees.Add(new Employee(i));
            }

            var crews = new List<Crew>();
            for (int i = 0; i < 5; i++)
            {
                crews.Add(new Crew(i));
            }

            var jobs = new List<Job>();
            for (int i = 0; i < 5; i++)
            {
                jobs.Add(new Job(i));
            }

            var result = new List<EmployeeSchedule>();
            var rand = new Random();
            for (int i = 0; i < rand.Next(15,25); i++)
            {
                result.Add(new EmployeeSchedule()
                {
                    Employee = employees[i],
                    Crew = crews[i%5],
                    Job = jobs[i%5],
                });
            }

            return result;
        }
    }
}
