using Ookii.Dialogs.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveFileForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog folderDialog = new VistaFolderBrowserDialog();
            {
                // 设置对话框属性
                folderDialog.Description = "选择多个目录";
                folderDialog.RootFolder = Environment.SpecialFolder.MyComputer;

                // 允许用户选择多个目录
                folderDialog.Multiselect = true;

                // 打开对话框并获取用户的选择
                bool? result = folderDialog.ShowDialog();

                if (result == true)
                {
                    DirBox.Items.Clear();
                    // 处理用户选择的目录
                    string[] selectedDirectories = folderDialog.SelectedPaths;

                    // 输出选择的目录
                    foreach (string directory in selectedDirectories)
                    {
                        DirBox.Items.Add(directory);
                        var dirName = Path.GetFileName(directory) + ".prj";
                        var figureName = Path.Combine(directory, dirName, "Result", "Figure");
                    }

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(DirBox.Items.Count == 0)
            {
                ErrorBox.Items.Add("请先选择文件夹");
                return;
            }

            CreateDir createDir = new CreateDir();
            foreach (var item in DirBox.Items)
            {
                var directory = item.ToString();
                var dirName = Path.GetFileName(directory) + ".prj";
                var figureName = Path.Combine(directory, dirName, "Result", "Figure");
                createDir.Go(figureName, (m, c) =>
                {
                    ErrorBox.Items.Add(m, c);
                });
            }
            ErrorBox.Items.Add("-----------------------> 完成");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DirBox.Items.Clear();
            ErrorBox.Items.Clear();
        }
    }

    class CreateDir
    {
        public void Go(string dir, Action<string, bool> message)
        {
            var files = Directory.GetFiles(dir);
            if (files.Length == 0)
            {
                message(dir + "目录下没有文件", true);
                return;
            }
            foreach (var file in files)
            {
                var fileName = Path.GetFileName(file);
                Console.Write(fileName);
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(file);
                var dirPath = Path.Combine(Path.GetDirectoryName(file), fileNameWithoutExtension);
                Directory.CreateDirectory(dirPath);
                var newFilePath = Path.Combine(dirPath, fileName);
                File.Copy(file, newFilePath);
                File.Delete(file);
                //Console.Write(" -> ");
                //Console.Write(newFilePath);
                //Console.Write("\n");
                message("fileName -> " + newFilePath, false);
            }

            //Console.Write("\n");
        }
    }
}
