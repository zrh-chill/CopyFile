using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsingNull
{
    class Test : IDisposable
    {
        public Test()
        {
            s = null;
        }

        private string s = null;

        public string Value
        {
            get { return s; }
        }

        public void Dispose()
        {
            s = null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool isNull = true;

            using (Test test = isNull ? null : new Test())
            {
                string s = test == null ? "是空的" : "不是空的";

                Console.WriteLine("进来了, test" + s);
                Console.ReadKey();
                return;
            }

            Console.WriteLine("没进去");
            Console.ReadKey();
        }
    }
}
