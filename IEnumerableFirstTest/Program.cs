using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableFirstTest
{
    class Geometry
    {

    }
    
    class Feature
    {
        public Feature(int id)
        {
            ID = id;
        }

        public int ID { get; set; } = 0;

        public Geometry Geometry { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Feature f0 = new Feature(0);
            Feature f1 = new Feature(1);
            Feature f2 = new Feature(2);

            List<Feature> fs = new List<Feature>() { f0, f1, f2 };
            IEnumerable<Feature> fi = fs.Where(f => f.ID >= 0);

            Dictionary<string, IEnumerable<Feature>> layerFeas = new Dictionary<string, IEnumerable<Feature>>();
            layerFeas["layer0"] = fi;
            layerFeas["layer1"] = fi;
            layerFeas["layer2"] = fi;

            Geometry ff = layerFeas.Values.First().First().Geometry;

            foreach(var feas in layerFeas)
            {
                var layerFea = feas.Value.Select(f => f).ToList();

                int j = 0;
            }
            
            int i = 0;
        }
    }
}
