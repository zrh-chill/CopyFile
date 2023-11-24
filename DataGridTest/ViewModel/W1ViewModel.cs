using DataGridTest.ViewModel.Controls;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGridTest.ViewModel
{
 
    public class W1ViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.  DataGrid
        /// </summary>
        public W1ViewModel(DyDataGridViewModel dyDataGridViewModel)
        {
            DyDGrid = dyDataGridViewModel;
        }
       
        public DyDataGridViewModel DyDGrid;

        public RelayCommand AddColumnCmd => new Lazy<RelayCommand>(() =>
           new RelayCommand(AddColumn)).Value;
        public RelayCommand AddDataCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(AddData)).Value;
        public RelayCommand DeleteColumnCmd => new Lazy<RelayCommand>(() =>
            new RelayCommand(DeleteColumn)).Value;

        private void AddData()
        {
            DyDGrid.AddData();
        }
        int newColumnIndex = 1;
        private void AddColumn()
        {
            string cName = "C" + newColumnIndex;
            List<string> vs = new List<string>();
            for (int i = 0; i < newColumnIndex; i++)
            {
                vs.Add("New Item - D" + i);
            }
            DyDGrid.AddColumn(cName, cName + "Show", vs);
            newColumnIndex++;
        }

        private void DeleteColumn()
        {
            DyDGrid.DeleteColumn();
        }
    }
}
