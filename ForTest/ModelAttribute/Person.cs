using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTest.ModelAttribute
{
    internal class Person
    {
        [PersonTest(Name = "test")]
        [PersonCheck(CheckEmpty = true)]
        public int Id { get; set; }

        [PersonCheck(CheckEmpty = true, MaxLengh = 10)]
        public string Name { get; set; }
    }
}
