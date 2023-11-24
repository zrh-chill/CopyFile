using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using System.Windows.Threading;

namespace EventSample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 定义时间调度器timer
            DispatcherTimer timer = new DispatcherTimer();

            // 时间间隔
            timer.Interval = TimeSpan.FromSeconds(1);

            // 用+=操作符把Timer_Tick这个函数挂接到Tick事件上
            // 即当Tick事件触发时，Timer_Tick函数就会执行
            timer.Tick += Timer_Tick;

            // 启动
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timeTextBox.Text = DateTime.Now.ToString();
            //throw new NotImplementedException();
        }
    }
}
