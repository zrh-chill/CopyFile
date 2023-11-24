using DataGridTest.Data;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Dynamic;
using System.Windows.Controls;
using System.Windows.Data;

namespace DataGridTest.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.  DataGrid
        /// </summary>
        public MainViewModel()
        {
            //注册设置vm里的DataGrid与界面的相关联
            Messenger.Default.Register<DataGrid>(this, MessageToken.SetDataGrid, (x) =>
            {
                DDataGrid = x;

                for (int i = 0; i < 5; i++)
                {
                    dynamic item = new ExpandoObject();
                    item.A = "Property A value - " + i.ToString();
                    item.B = "Property B value - " + i.ToString();
                    _Items.Add(item);
                }

                DDataGrid.Columns.Add(new DataGridTextColumn() { Header = "A", Binding = new Binding("A") });
                DDataGrid.Columns.Add(new DataGridTextColumn() { Header = "B", Binding = new Binding("B") });
                DDataGrid.ItemsSource = _Items;
            });

           
        }
        /// <summary>
        /// 绑定的数据
        /// </summary>
        ObservableCollection<ExpandoObject> _Items = new ObservableCollection<ExpandoObject>();

        public DataGrid DDataGrid;

        public ObservableCollection<ExpandoObject> Items
        {
            get { return _Items; }
            set
            {
                _Items = value;
                RaisePropertyChanged(()=> Items);
            }
        }


        public RelayCommand AddColumnCmd => new Lazy<RelayCommand>(() =>
           new RelayCommand(AddColumn)).Value;
        public RelayCommand AddDataCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(AddData)).Value;
        public RelayCommand DeleteColumnCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(DeleteColumn)).Value;

        private void AddData()
        {
            dynamic item = new ExpandoObject();
            item.A = "New Item - A";
            item.B = "New Item - B";
            item.NewColumn1 = "New Item - C";
            Items.Add(item);
        }

        int newColumnIndex = 1;
        private void AddColumn()
        {
            foreach (IDictionary<String, Object> item in Items)
            {
                item.Add("NewColumn" + newColumnIndex, "New Column Value - " + newColumnIndex.ToString());
            }

            DDataGrid.Columns.Add(new DataGridTextColumn() { Header = "NewColumn" + newColumnIndex, Binding = new Binding("NewColumn" + newColumnIndex) });

            newColumnIndex++;
        }

        private void DeleteColumn()
        {
            for (int i = 0; i < DDataGrid.SelectedCells.Count; i++)
            {
                //DataRowView Row = (DataRowView)DDataGrid.SelectedCells[i].Item;
                //string result = Row[DDataGrid.SelectedCells[i].Column.DisplayIndex].ToString();

                //string result = DDataGrid.SelectedCells[i].Column.DisplayIndex.ToString();
                
                DDataGrid.Columns.Remove(DDataGrid.SelectedCells[i].Column);
            }
        }
    }
}