using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow1
{
    static class MockData
    {
        internal static List<tblEmployeeSchedule> GenerateData()
        {
            var employees = new List<Employee>();
            for (int i = 0; i < 25; i++)
            {
                employees.Add(new Employee(Names[i]));
            }

            var crews = new List<tblCrew>();
            for (int i = 0; i < 5; i++)
            {
                crews.Add(new tblCrew(i));
            }

            var jobs = new List<Job>();
            for (int i = 0; i < 5; i++)
            {
                jobs.Add(new Job(Jobs[i]));
            }

            var result = new List<tblEmployeeSchedule>();
            var rand = new Random();
            for (int i = 0; i < rand.Next(15, 25); i++)
            {
                var job = rand.Next(6) == 5 ?
                    jobs[0] : jobs[i % 5];



                result.Add(new tblEmployeeSchedule()
                {
                    int_employee = employees[i],
                    int_job = job,
                });
            }

            foreach (var schedule in result)
            {
                var index = Jobs.IndexOf(schedule.int_job.Name);
                schedule.int_crew = crews[index];
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
