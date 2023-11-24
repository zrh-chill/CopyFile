using ForWPF.view;
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

namespace ForWPF
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StackPanel_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Object"))
            {
                // These Effects values are used in the drag source's
                // GiveFeedback event handler to determine which cursor to display.
                if (e.KeyStates == DragDropKeyStates.ControlKey)
                {
                    e.Effects = DragDropEffects.Copy;
                }
                else
                {
                    e.Effects = DragDropEffects.Move;
                }
            }
        }

        private void StackPanel_Drop(object sender, DragEventArgs e)
        {
            // If an element in the panel has already handled the drop,
            // the panel should not also handle it.
            if (e.Handled == false)
            {
                Panel _panel = (Panel)sender;
                UIElement _element = (UIElement)e.Data.GetData("Object");

                if (_panel != null && _element != null)
                {
                    // Get the panel that the element currently belongs to,
                    // then remove it from that panel and add it the Children of
                    // the panel that its been dropped on.
                    Panel _parent = (Panel)VisualTreeHelper.GetParent(_element);

                    if (_parent != null)
                    {
                        if (e.KeyStates == DragDropKeyStates.ControlKey &&
                            e.AllowedEffects.HasFlag(DragDropEffects.Copy))
                        {
                            Circle _circle = new Circle((Circle)_element);
                            _panel.Children.Add(_circle);
                            // set the value to return to the DoDragDrop call
                            e.Effects = DragDropEffects.Copy;
                        }
                        else if (e.AllowedEffects.HasFlag(DragDropEffects.Move))
                        {
                            _parent.Children.Remove(_element);
                            _panel.Children.Add(_element);
                            // set the value to return to the DoDragDrop call
                            e.Effects = DragDropEffects.Move;
                        }
                    }
                }
            }
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {
            // 获取拖拽的文件列表  
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            if (files == null)
            {
                return;
            }

            // 处理文件数据  
            foreach (string file in files)
            {
                Tb.Text += file;
            }
        }

        private void Window_DragEnter(object sender, DragEventArgs e)
        {
            // 判断拖拽数据是否包含文件数据  
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // 设置拖拽效果  
                e.Effects = DragDropEffects.Copy;
            }
        }

        private void CommandTestBtn_Click(object sender, RoutedEventArgs e)
        {
            CommandTestWindow window = new CommandTestWindow(); ;
            window.Show();
        }

        private void EventTestBtn_Click(object sender, RoutedEventArgs e)
        {
            EventTestWindow window = new EventTestWindow(); ;
            window.Show();
        }
    }
}
