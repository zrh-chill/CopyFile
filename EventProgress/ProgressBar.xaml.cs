using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EventProgress
{
    /// <summary>
    /// ProgressBar.xaml 的交互逻辑
    /// </summary>
    public partial class ProgressBar : Window
    {
        public ProgressBar()
        {
            InitializeComponent();
        }

        public Work Work1 { get; set; }

        public void Work_ValueChanged(object sender, ValueChangedArg e)
        {
            this.Pbar.Dispatcher.BeginInvoke((ThreadStart)delegate { this.Pbar.Value = e.CurrentDwg; });
            this.tb.Dispatcher.BeginInvoke((ThreadStart)delegate { this.tb.Text = $"{e.CurrentDwg}/{this.Pbar.Maximum}"; });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0, count = 100; i < count; i++)
            {
                Work1.SetValue(i + 1);
                Thread.Sleep(20);
            }
        }
    }
}
