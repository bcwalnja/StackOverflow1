using System;
using System.Collections.Generic;
using System.Text;

namespace StackOverflow1
{
    class tblCrew
    {
        public override string ToString()
        {
            return Name;
        }
        public tblCrew(object name)
        {
            Name = $"Crew {name}";
        }
        public string Name { get; set; }
    }
}