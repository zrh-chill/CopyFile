using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpWork
{
    internal class LinkqAsync
    {
        public async void Work()
        {
            List<int> ints = new List<int>()
            {
                1,2, 3, 4, 5, 6, 7, 8, 9, 10,
            };

            Console.WriteLine("START");

            var tasks = ints.Select(Sel).ToArray();

            await Task.WhenAll(tasks);

            Console.WriteLine("END");
            Console.ReadLine();
        }

        private async Task<bool> Sel(int i)
        {
            Console.WriteLine($"before{i}");
            var result = await Bool(i);
            Console.WriteLine($"after{i}");
            return result;
        }

        private async Task<bool> Bool(int i)
        {
            return await Task.Run(() =>
            {
                System.Threading.Thread.Sleep(100);

                return i > 5;
            });
        }
    }
}
