using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow1
{
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
}
