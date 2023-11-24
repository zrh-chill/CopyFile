using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTest.ModelAttribute
{
    internal class PersonCheckAttribute : Attribute
    {
        public bool CheckEmpty { get; set; }

        public int MaxLengh { get; set; }
    }

    internal class PersonTestAttribute : Attribute
    { 
        public string Name { get; set; }
    }

}
