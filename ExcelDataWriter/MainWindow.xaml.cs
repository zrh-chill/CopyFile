using Microsoft.Win32;
using System.Windows;
using Panuon.WPF.UI;
using System.Collections.Generic;
using System.IO;
using System;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace ExcelDataWriter
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog()
            {
                Filter = "Excel文件（*.xlsx, *.xls）|*.xlsx;*.xls",
            };

            if(dlg.ShowDialog() != true)
            {
                return;
            }
        }



        //此处是将list集合写入excel表，Supply也是自己定义的类，每一个字段对应需要写入excel表的每一列的数据
        //一次最多能写65535行数据，超过需将list集合拆分，分多次写入
        #region 写入excel
        //public static bool ListToExcel(List<Supply> list)
        //{
        //    bool result = false;
        //    IWorkbook workbook = new HSSFWorkbook();
        //    ISheet sheet = workbook.CreateSheet("Sheet1");//创建一个名称为Sheet0的表;
        //    IRow row = sheet.CreateRow(0);//（第一行写标题)
        //    row.CreateCell(0).SetCellValue("标题1");//第一列标题，以此类推
        //    row.CreateCell(1).SetCellValue("标题2");
        //    row.CreateCell(2).SetCellValue("标题3");
        //    int count = list.Count;//
        //    int max = 65535;//最大行数限制
        //    if (count < max)
        //    {
        //        //每一行依次写入
        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            row = sheet.CreateRow(i + 1);//i+1:从第二行开始写入(第一行可同理写标题)，i从第一行写入
        //            row.CreateCell(0).SetCellValue(list[i].Value1);//第一列的值
        //            row.CreateCell(1).SetCellValue(list[i].Value2);//第二列的值
        //            row.CreateCell(2).SetCellValue(list[i].Value3);
        //        }
        //        //文件写入的位置
        //        using (FileStream fs = File.OpenWrite(@"C:\Users\20882\Desktop\结果.xls"))
        //        {
        //            workbook.Write(fs);//向打开的这个xls文件中写入数据  
        //            result = true;
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("超过行数限制！");
        //        result = false;
        //    }

        //    return result;
        //}
        #endregion

        private void tBtn_Click(object sender, RoutedEventArgs e)
        {
            ButtonHelper.SetIsPending(tBtn, true);
        }
    }
}
