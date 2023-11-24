using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dictionarySample
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> test = new Dictionary<int, string> { };
            test.Add(0, "000");
            test.Add(4, "444");
            test.Add(2, "222");
            test.Add(6, "666");

            Dictionary<int, string> dic1Asc = test.OrderBy(o => o.Key).ToDictionary(o => o.Key, p => p.Value);


            Console.WriteLine("小到大排序");
            foreach (KeyValuePair<int, string> k in dic1Asc)
            {
                Console.WriteLine("key:" + k.Key + " value:" + k.Value);
            }

            Console.WriteLine("大到小排序");
            Dictionary<int, string> dic1desc = test.OrderByDescending(o => o.Key).ToDictionary(o => o.Key, p => p.Value);

            foreach (KeyValuePair<int, string> k in dic1desc)
            {
                Console.WriteLine("key:" + k.Key + " value:" + k.Value);
            }

            Console.Read();
        }
    }
}
