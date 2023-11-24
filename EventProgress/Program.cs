using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventProgress
{
    class Program
    {
        static void Main(string[] args)
        {
            Work work = new Work();

            // 子线程工作
            Thread thread = new Thread(()=>
            {
                ProgressBar progressBar = new ProgressBar();
                progressBar.Work1 = work;
                progressBar.Pbar.Maximum = 100;
                work.ValueChanged += progressBar.Work_ValueChanged;
                progressBar.ShowDialog();
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            // 主线程工作
            for (int i = 0, count = 100; i < count; i++)
            {
                work.SetValue(i + 1);
                Thread.Sleep(20);
            }
        }
    }
}
