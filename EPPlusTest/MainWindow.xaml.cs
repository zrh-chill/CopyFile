using Microsoft.Win32;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace EPPlusTest
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

        //private void MyBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    // 创建一个Excel包
        //    using (ExcelPackage excelPackage = new ExcelPackage())
        //    {
        //        // 添加一个工作表
        //        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

        //        // 获取DataGrid的列数和行数
        //        int rows = dataGrid.Items.Count + 1;
        //        int columns = dataGrid.Columns.Count;

        //        // 将DataGrid的列名写入Excel的第一行
        //        for (int col = 1; col <= columns; col++)
        //        {
        //            worksheet.Cells[1, col].Value = dataGrid.Columns[col - 1].Header;
        //        }

        //        // 将DataGrid的数据写入Excel
        //        for (int row = 0; row < rows - 1; row++)
        //        {
        //            for (int col = 0; col < columns; col++)
        //            {
        //                var cellValue = (dataGrid.Items[row] as DataRowView)?.Row.ItemArray[col];
        //                worksheet.Cells[row + 2, col + 1].Value = cellValue;
        //            }
        //        }

        //        // 保存Excel文件
        //        SaveFileDialog saveFileDialog = new SaveFileDialog
        //        {
        //            Filter = "Excel Files|*.xlsx|All Files|*.*"
        //        };

        //        if (saveFileDialog.ShowDialog() == true)
        //        {
        //            FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
        //            excelPackage.SaveAs(excelFile);
        //            MessageBox.Show("导出成功！");
        //        }
        //    }
        //}
    }
}
