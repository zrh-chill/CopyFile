using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace DataGridTest.ViewModel.Controls
{
    /// <summary>
    /// DyDataGrid的数据源，自动新增列等功能
    /// </summary>
    public class DyDataGridViewModel : ViewModelBase
    {
        /// <summary>
        /// 绑定的数据
        /// </summary>
        ObservableCollection<ExpandoObject> _Items = new ObservableCollection<ExpandoObject>();

        private DataGrid _DDataGrid;
        public DataGrid DDataGrid
        {
            get
            {
                return _DDataGrid;
            }
            set
            {
                if (_DDataGrid != null)
                {
                    _DDataGrid.ItemsSource = null;
                }
                _DDataGrid = value;
                Init();
            }
        }

        public ObservableCollection<ExpandoObject> Items
        {
            get { return _Items; }
            set
            {
                _Items = value;
                RaisePropertyChanged(() => Items);
            }
        }

        #region 方法
        /// <summary>
        /// 初始化
        /// </summary>
        public void Init()
        {
            Items.Clear();

            for (int i = 0; i < 5; i++)
            {
                dynamic item = new ExpandoObject();
                item.A = "Property A value - " + i.ToString();
                item.B = "Property B value - " + i.ToString();
                _Items.Add(item);
            }

            DDataGrid.Columns.Add(new DataGridTextColumn() { Header = "A", Binding = new Binding("A") });
            DDataGrid.Columns.Add(new DataGridTextColumn() { Header = "B", Binding = new Binding("B") });

            _DDataGrid.ItemsSource = Items;
        }

        public void AddData()
        {
            //dynamic item = new ExpandoObject();
            //item.A = "New Item - A";
            //item.B = "New Item - B";
            //item.NewColumn1 = "New Item - C";
            //Items.Add(item);
        }

        /// <summary>
        /// 添加列和列数据
        /// </summary>
        /// <param name="columnName">列名</param>
        /// <param name="columnName">显示列名</param>
        /// <param name="vs">填充的列数据</param>
        public void AddColumn(string columnName, string Header, List<string> vs)
        {
            int i = 0;
            int count = vs.Count;
            //循环获取行数据
            foreach (IDictionary<String, Object> item in Items)
            {
                //每行添加新列数据
                item.Add(columnName, vs[i]);
                i++;
                //添加完数据跳出
                if (i >= vs.Count) break;
            }

            //如果列数据多，则继续添加
            for (; i < vs.Count; i++)
            {
                //可以这么用 columnName就是传进来的列名
                dynamic item = new ExpandoObject();
                item.columnName = vs[i];

                Items.Add(item);
            }

            //添加列
            DDataGrid.Columns.Add(new DataGridTextColumn()
            {
                Header = Header,
                Binding = new Binding(columnName)
            });

        }
        /// <summary>
        /// 删除选中列
        /// </summary>
        public void DeleteColumn()
        {
            for (int i = 0; i < DDataGrid.SelectedCells.Count; i++)
            {
                //DataRowView Row = (DataRowView)DDataGrid.SelectedCells[i].Item;
                //string result = Row[DDataGrid.SelectedCells[i].Column.DisplayIndex].ToString();

                //string result = DDataGrid.SelectedCells[i].Column.DisplayIndex.ToString();

                DDataGrid.Columns.Remove(DDataGrid.SelectedCells[i].Column);
            }
        }

        #endregion
    }
}
