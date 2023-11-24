using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fromIn
{
    class Point
    {
        public Point(double xx, double yy)
        {
            x = xx;
            y = yy;
        }

        public double x;
        public double y;

        public void Test()
        {
            List<Point> points = new List<Point>
            {
                new Point(1, 0),

                new Point(2, 1),
                new Point(3, 1),
                new Point(4, 1),

                new Point(5, 2),
                new Point(6, 2),
                new Point(7, 2),
                new Point(8, 2),

                new Point(9, 3),
                new Point(10, 3),
                new Point(11, 3),

                new Point(12, 4),
            };

            var res = from p in points
                      group p by p.y into g
                      orderby g.Count() descending
                      select g;

            var gr = res.First();

            foreach (var r in gr)
            {
                Console.WriteLine($"({r.x}, {r.y})");
            }

            string s = "+22.33";

            Console.WriteLine($"{Convert.ToDouble(s)}");

            Console.ReadKey();
        }
    }

    class DraftData
    {
        public DraftData(string name)
        {
            Name = name;
        }

        public virtual string Name { get; set; }
    }

    class Draft : DraftData
    {
        public Draft(string name) : base(name)
        {
            Name = name;
        }

        public override string Name { get; set; }
    }

    class Adraft
    {
        public Adraft(int num)
        {
            Num = num;
        }

        public int Num { get; set; }
    }

    class Program
    {
        void Test1()
        {
            List<string> ss = new List<string>()
            {
                "aa",
                "22",
                "bb",
                "11",
                "33",
                "cc"
            };

            var I = ss.Where(s => int.TryParse(s, out var x)).ToList();
            var S = ss.Except(I).ToList();

            I.ForEach(i => Console.WriteLine($"{i} "));
            S.ForEach(s => Console.WriteLine($"{s} "));

            Console.ReadLine();
        }

        void OrderByTest()
        {
            ObservableCollection<DraftData> draftDatas = new ObservableCollection<DraftData>
            {
                new Draft("20~5"),
                new Draft("6"),
                new Draft("1")
            };

            //foreach (var d in draftDatas)
            //{
            //    Console.WriteLine($"{d.Name.Split('~').First().ToInt()}");
            //}

            var dd = draftDatas.OrderBy(d => d.Name.Split('~').First().ToInt());

            foreach (var d in dd)
            {
                Console.WriteLine($"{d.Name}");
            }

            ObservableCollection<Adraft> adrafts = new ObservableCollection<Adraft>()
            {
                new Adraft(2),
                new Adraft(6),
                new Adraft(1)
            };

            var v = adrafts.OrderBy(r => r.Num);

            foreach (var a in v)
            {
                Console.WriteLine($"{a.Num}");
            }

            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            int[] num = new int[] { 0, 1, 2, 3, 4};

            for (int i = 0; i < num.Length - 1; i++)
            {
                Console.WriteLine($"{num[i]}---");

                for (int j = i + 1; j < num.Length; j++)
                {
                    Console.WriteLine($"{num[j]}");
                }

                Console.WriteLine("");
            }

            Console.ReadKey();
        }
    }
}
