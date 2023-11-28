using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FtpFile.Ftp
{
    internal class FtpHelper
    {
        /// <summary>
        /// Ftp数据加载
        /// </summary>
        /// <param name="F_Ftp">FTP服务器IP</param>
        /// <param name="F_User">FTP登录帐号</param>
        /// <param name="F_Pwd">FTP登录密码</param>
        public void GetFtpFiles(string F_Ftp, string F_User, string F_Pwd)
        {
            //FTP请求对象
            FtpWebRequest request = null;
            //FTP响应
            FtpWebResponse ftpResponse = null;

            //FTP响应流
            StreamReader reader = null;

            try
            {
                //声明集合接收FTP里面的文件
                //FtpFiles为两个属性，Type， Name
                List<FtpFiles> list = new List<FtpFiles>();
                //声明uri请求格式

                string uri = string.Format("ftp://{0}", F_Ftp);


                //生成FTP请求
                request = (FtpWebRequest)WebRequest.Create(new Uri(uri));
                //FTP登录  账号&密码
                request.Credentials = new NetworkCredential(F_User,F_Pwd);
                //设置FTP方法
                request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                request.UsePassive = false;
                //生成FTP响应
                ftpResponse = (FtpWebResponse)request.GetResponse();

                //FTP响应流
                reader = new StreamReader(ftpResponse.GetResponseStream());

                string line = reader.ReadLine();

                while (line != null)
                {
                    //判断是文件夹
                    if (line.Contains("<DIR>"))
                    {
                        //截取字符串
                        string msg = line.Substring(line.LastIndexOf("<DIR>") + 5).Trim();
                        FtpFiles ftpFiles = new FtpFiles();
                        ftpFiles.Type = "[文件夹]";
                        ftpFiles.Name = msg;

                        list.Add(ftpFiles);
                    }
                    //否则是文件
                    else
                    {
                        string msg = line.Substring(39).Trim();
                        FtpFiles ftpFiles = new FtpFiles();
                        ftpFiles.Type = "[文  件]";
                        ftpFiles.Name = msg;

                        list.Add(ftpFiles);
                    }
                    line = reader.ReadLine();
                }

                //将数据绑定dataGridView1
                //dataGridView1.DataSource = list;
                //dataGridView1.AutoGenerateColumns = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("登录或链接失败！请检查FTP地址，用户名与密码");
            }
            finally
            {
                //关闭流
                if (reader != null)
                {
                    reader.Close();
                }
                if (ftpResponse != null)
                {
                    ftpResponse.Close();
                }

            }

        }

        /// <summary>
        /// FTP下载文件
        /// </summary>
        /// <param name="ftpServerIP">FTP服务器IP</param>
        /// <param name="ftpUserID">FTP登录帐号</param>
        /// <param name="ftpPassword">FTP登录密码</param>
        /// <param name="saveFilePath">保存文件路径</param>
        /// <param name="saveFileName">//保存文件名</param>
        /// <param name="downloadFileName">下载文件名</param>

        public void FTPDownLoadFile(string ftpServerIP, string ftpUserID, string ftpPassword, string saveFilePath, string saveFileName, string downloadFileName)
        {
            //定义FTP请求对象
            FtpWebRequest ftpRequest = null;
            //定义FTP响应对象
            FtpWebResponse ftpResponse = null;

            //存储流
            FileStream saveStream = null;
            //FTP数据流
            Stream ftpStream = null;

            try
            {
                //生成下载文件
                saveStream = new FileStream(saveFilePath + "\\" + saveFileName, FileMode.Create);

                //生成FTP请求对象                                         
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + downloadFileName));

                //设置下载文件方法
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;

                //设置文件传输类型
                ftpRequest.UseBinary = true;

                //设置登录FTP帐号和密码
                ftpRequest.Credentials = new NetworkCredential(ftpUserID, ftpPassword);

                //生成FTP响应对象
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

                //获取FTP响应流对象
                ftpStream = ftpResponse.GetResponseStream();

                //响应数据长度
                long cl = ftpResponse.ContentLength;

                int bufferSize = 2048;

                int readCount;

                byte[] buffer = new byte[bufferSize];

                //接收FTP文件流
                readCount = ftpStream.Read(buffer, 0, bufferSize);

                while (readCount > 0)
                {
                    saveStream.Write(buffer, 0, readCount);

                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }
                MessageBox.Show("下载成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                if (ftpStream != null)
                {
                    ftpStream.Close();
                }

                if (saveStream != null)
                {
                    saveStream.Close();
                }

                if (ftpResponse != null)
                {
                    ftpResponse.Close();
                }
            }


        }

    }
}
