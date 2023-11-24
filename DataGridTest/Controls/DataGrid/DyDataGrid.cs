using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Data;
using DataGridTest.ViewModel.Controls;

namespace DataGridTest.Controls
{
    public class DyDataGrid : DataGrid
    {
        public DyDataGrid()
            : base()
        {
            AutoGenerateColumns = false;
            CanUserAddRows = false;

            CanUserSortColumns = false;
        }

        // 这个控件的一个自定义属性;
        private DyDataGridViewModel mDataSource;
        public DyDataGridViewModel DataSource
        {
            get { return mDataSource; }
            set
            {
                mDataSource = value;
            }
        }

        /// <summary>
        /// 定义了一个名为DataSourc的控件依赖属性;
        /// 这个依赖属性用于显示peopoleDataGrid的内容;
        /// </summary>
        public static readonly DependencyProperty DataSourceProperty =
                DependencyProperty.Register("DataSource", typeof(DyDataGridViewModel), typeof(DyDataGrid),
                new FrameworkPropertyMetadata(new PropertyChangedCallback(OnDataSourcePeopertyChanged)));

        private static void OnDataSourcePeopertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            DyDataGrid dyDataGrid = (DyDataGrid)obj;

            if (args.NewValue is DyDataGridViewModel)
            {
                if (dyDataGrid != null)
                {
                    DyDataGridViewModel peoplesViewModel = args.NewValue as DyDataGridViewModel;
                    peoplesViewModel.DDataGrid = dyDataGrid;
                   
                }
            }

        }
    }
}
