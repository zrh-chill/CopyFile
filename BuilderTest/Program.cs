using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderTest
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractRenderBuilder builder = new RenderBuilder();
            AbstractGraph.AbstractRender render = builder.CreateRender();
            render.Paint();
        }
    }

    public abstract class AbstractRenderBuilder
    {
        public abstract AbstractGraph.AbstractRender CreateRender();
    }

    public class RenderBuilder : AbstractRenderBuilder
    {
        public override AbstractGraph.AbstractRender CreateRender()
        {
            return new Graph.Render();
        }
    }
}

namespace AbstractGraph
{
    public abstract class AbstractRender
    {
        public abstract void Paint();
    }
}

namespace Graph
{
    public class Render : AbstractGraph.AbstractRender
    {
        public override void Paint()
        {
            Console.WriteLine("paint\n");
            Console.ReadKey();
        }
    }
}
