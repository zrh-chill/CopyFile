using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class Context
    {
        public WindowFactory WindowFactory { get; set; } = new HouseFactory();
    }

    abstract class BaseClass
    {
        public abstract void SetNum(BaseClass class3);
    }

    class MyClass : BaseClass
    {
        public int Num { get; set; }

        public override void SetNum(BaseClass class3)
        {
            class3 = this;
        }
    }

    class Program
    {
        static BaseClass Method1(BaseClass class1, int num)
        {
            //class1.SetNum(num);

            return class1;
        }

        static void Method2(BaseClass class1, int num)
        {
            //class1.SetNum(num);
        }

        static void Main(string[] args)
        {
            BaseClass class1 = new MyClass { Num = 132 };
            MyClass class2 = new MyClass();

            class1.SetNum(class2);

            Console.WriteLine(class2.Num);
            Console.ReadLine();


            //Entrance e = new Entrance();
            //Context context = new Context();

            //e.Start(context);

            //Console.ReadLine();
        }
    }

    class Entrance
    {
        public void Start(Context context)
        {
            CollectedWindow window = context.WindowFactory.CreateWindow(context);
            window.Show();
        }
    }

    abstract class WindowFactory
    {
        public abstract CollectedWindow CreateWindow(Context context);
    }

    class HouseFactory : WindowFactory
    {
        public override CollectedWindow CreateWindow(Context context)
        {
            return new House(context);
        }
    }

    class RoomFactory : WindowFactory
    {
        public override CollectedWindow CreateWindow(Context context)
        {
            return new Room(context);
        }
    }

    abstract class CollectedWindow
    {
        public abstract void Show();
    } 

    class House : CollectedWindow
    {
        public House(Context context)
        {

        }

        public override void Show()
        {
            Console.WriteLine("house");
        }
    }

    class Room : CollectedWindow
    {
        public Room(Context context)
        {

        }

        public override void Show()
        {
            Console.WriteLine("room");
        }
    }
}
