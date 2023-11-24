using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForTest
{
    internal class ListSort
    {
        public void SortTest()
        {
            List<int> ints = new List<int>();
            Func<int, int, int> func =(int a, int b) => { return 0; };
            ints.Sort((int a, int b) => { return a > b ? 0 : 1; });
        }

        public void Test()
        {
            List<string> ss = new List<string> { "AAA", "BBB", "CCC" };

            foreach (var s in ss)
            {
                Console.WriteLine(s);
            }

            for (int i = 0, count = ss.Count; i < count; i++)
            {
                Console.ReadKey();

                string t = ss[i];

                ss[i] = $"{i}";

                foreach (var s in ss)
                {
                    Console.WriteLine(s);
                }



            }

            Console.ReadKey();
        }

    }
}
