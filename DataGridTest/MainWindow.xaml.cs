using DataGridTest.Data;
using DataGridTest.ViewModel;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataGridTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : BlurWindow
    {
        //ObservableCollection<ExpandoObject> items = new ObservableCollection<ExpandoObject>();

        public MainWindow()
        {
            InitializeComponent();

            //mainViewModel.DDataGrid = dataGrid;
            Messenger.Default.Send<DataGrid>(dataGrid, MessageToken.SetDataGrid);
        }

        private void BlurWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

       
    }
}
