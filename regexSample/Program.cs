using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace regexSample
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regBrackets = new Regex(".*[()（）]{1}.*");         // 包含圆括号
            Regex regNum = new Regex("^[0-9]+$");                     // 纯数字
            Regex regNum1 = new Regex(".*[0-9a-zA-Z]{1}.*");          // 包含数字或字母
            Regex regLetter = new Regex("");
            Regex regFuShi = new Regex(".*[复式]{2}.*");

            string str = "IGII复";

            if (regFuShi.IsMatch(str))
            {
                Console.WriteLine("符合条件");
            }
            else
            {
                Console.WriteLine("不符合条件");
            }

            Console.ReadLine();
        }
    }
}
