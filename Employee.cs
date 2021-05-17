using System;
using System.Collections.Generic;
using System.Text;

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
}
