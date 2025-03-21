﻿using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Tools;
using Tools.Net;
using Tools.Data;
using Tools.Fileoperate;

namespace 我的世界服务器文件下载
{
    public partial class Menu : Form
    {
        public String RunDir = Directory.GetCurrentDirectory();
        public String GitHub = "https://github.com/cngege/MinecraftBEServerFileDownload.git";

        public String Serveraddr = "https://www.minecraft.net/en-us/download/server/bedrock/";
        public String Httpdata = "";
        public String PilterA = "https://www.minecraft.net/bedrockdedicatedserver/bin-win/bedrock-server-";
        public String PilterB = ".zip";
        public String PilterC = "https://www.minecraft.net/bedrockdedicatedserver/bin-linux/bedrock-server-";

        public String WinSerDownaddr = "";
        public int Winstartposition = 0;
        public int WinaddrLong = 0;
        public String WinVersion = "";

        public String LinuxSerDownaddr = "";
        public int Linuxstartposition = 0;
        public int LinuxaddrLong = 0;
        public String LinuxVersion = "";

        public InIFile savedata;
        public String SaveParh;
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;    //允许线程操作UI
            savedata = new InIFile(RunDir + "\\MSDL.ini");
            SaveParh = savedata.Read("SavePath","key", RunDir);
            
        }

        public void TagShow(String text)
        {
            label1.Text = text;
        }

        private void DownInformation_Click(object sender, EventArgs e)
        {
            TagShow("开始读取官网信息");
            new Thread(new ThreadStart(Analysis)).Start();
        }

        delegate void Analysis_class(String input);

        #region 获取官网信息，并分析Windows版和Linux版下载地址 以及版本
        public void Analysis()
        {
            int zipstartposition_win;
            int zipstartposition_linux;

            Httpdata = GetHttpData(Serveraddr);
            if (Httpdata == "")
            {
                this.BeginInvoke(new Analysis_class(TagShow),new object[] { "没有能读取到官网信息，后续操作中断" });
                return;
            }

            //TagShow("寻找Windows下载地址特征开始位置");
            Winstartposition = Httpdata.IndexOf(PilterA);
            if (Winstartposition > -1)
            {
                //TagShow("寻找Windows下载地址特征结束位置");
                zipstartposition_win = Httpdata.IndexOf(PilterB, Winstartposition);
                //TagShow("过滤出Windows服务器最新版本");
                WinVersion = Httpdata.Substring(Winstartposition + PilterA.Length, zipstartposition_win - Winstartposition - PilterA.Length);
                //TagShow("计算Windows下载地址长度");
                WinaddrLong = zipstartposition_win + PilterB.Length - Winstartposition;
                //TagShow("找出Windows下载地址");
                WinSerDownaddr = Httpdata.Substring(Winstartposition, WinaddrLong);

                Linuxstartposition = Httpdata.IndexOf(PilterC);
                zipstartposition_linux = Httpdata.IndexOf(PilterB, Linuxstartposition);
                LinuxVersion = Httpdata.Substring(Linuxstartposition + PilterC.Length, zipstartposition_linux - Linuxstartposition - PilterC.Length);
                LinuxaddrLong = zipstartposition_linux + PilterB.Length - Linuxstartposition;
                LinuxSerDownaddr = Httpdata.Substring(Linuxstartposition, LinuxaddrLong);

                this.BeginInvoke(new Analysis_class(TagShow), new object[] { $"Win版本：{WinVersion},Linux版本：{LinuxVersion}" });
            }
            else
            {
                TagShow("可能官网出现问题,没有找到标识,请等待更新, desktop::Error.log.txt");
                File.WriteAllText(String.Format(@"C:\Users\{0}\Desktop\Error.log.txt", Environment.GetEnvironmentVariable("UserName").ToString()), Httpdata);
            }
        }
        #endregion

        #region Win服务端程序下载
        private void DownWinServer_Click(object sender, EventArgs e)
        {
            if (WinSerDownaddr == "")
            {
                TagShow("未能获取远程下载地址");
            }
            else
            {
                TagShow("开始下载Windows服务端程序");

                
                Download DownWinServer = new Download(WinSerDownaddr, SaveParh, $"WinSer{WinVersion}.zip");
                DownWinServer.Suffix = ".MCBDS";    //定义下载的缓存文件后缀

                int win_percent;
                DownWinServer.Downprogress += (long filesize, long httpsize, bool isok) =>  //下载回调函数
                {
                    if (isok)   //回调函数中指示下载完成
                    {
                        this.DownWinServer.Enabled = true;
                        TagShow($"WinSer{WinVersion}.zip下载完成");
                    }
                    win_percent = Download.GetintPercent(filesize, httpsize);   //计算并在进度条上显示下载进度
                    if (win_percent <= 100) Win_Bar.Value = win_percent;
                };

                switch (DownWinServer.Start())
                {
                    case 0:
                        this.DownWinServer.Enabled = true;
                        TagShow($"WinSer{WinVersion}.zip下载失败");
                        break;
                    case 1:
                        this.DownWinServer.Enabled = false;
                        TagShow($"WinSer{WinVersion}.zip开始下载");
                        break;
                    case 2:
                        this.DownWinServer.Enabled = true;
                        TagShow($"WinSer{WinVersion}.zip下载完成");
                        break;
                }
            }
            
        }
        #endregion

        #region Linux服务端程序下载
        private void DownLinuxServer_Click(object sender, EventArgs e)
        {
            if (LinuxSerDownaddr == "")
            {
                TagShow("未能获取远程下载地址");
            }
            else
            {
                TagShow("开始下载Linux服务端程序");
                //开始实例化下载
                Download DownLinuxServer = new Download(LinuxSerDownaddr, SaveParh, $"LinuxSer{LinuxVersion}.zip");
                DownLinuxServer.Suffix = ".MCBDS";
                int lin_percent;
                DownLinuxServer.Downprogress += (long filesize, long httpsize, bool isok) =>
                {
                    if (isok)
                    {
                        this.DownLinuxServer.Enabled = true;
                        TagShow($"LinuxSer{LinuxVersion}.zip下载完成");
                    }

                    lin_percent = Download.GetintPercent(filesize, httpsize);   //计算并在进度条上显示下载进度
                    if (lin_percent <= 100) Lin_Bar.Value = lin_percent;
                };

                switch (DownLinuxServer.Start())
                {
                    case 0:
                        this.DownLinuxServer.Enabled = true;
                        TagShow($"LinuxSer{LinuxVersion}.zip下载失败");
                        break;
                    case 1:
                        this.DownLinuxServer.Enabled = false;
                        TagShow($"LinuxSer{LinuxVersion}.zip开始下载");
                        break;
                    case 2:
                        this.DownLinuxServer.Enabled = true;
                        TagShow($"LinuxSer{LinuxVersion}.zip下载完成");
                        break;
                }

            }
        }
        #endregion

        private void info_copyright_Click(object sender, EventArgs e)
        {
            DialogResult Result = MessageBox.Show("C#开发,GitHub开源\n" + 
                                                  "我的世界BE服务端文件下载器\n" + 
                                                  "可转载至非商业用途\n" + 
                                                  "作者：貔貅I勿念\n" + 
                                                  "联系QQ：2586850402"
                                                  , "AppInfo 按下‘确定’键打开开源项目", MessageBoxButtons.OKCancel);
            if (Result == DialogResult.OK)
            {
                System.Diagnostics.Process.Start(GitHub);
            }
        }

        private void CopyWinAddr_Click(object sender, EventArgs e)
        {
            if (WinSerDownaddr != "")
            {
                Data.CopyData(WinSerDownaddr);
                TagShow("已复制");
            }
            else
            {
                TagShow("没有获取到远程下载地址");
            }
        }

        private void CopyLinuxAddr_Click(object sender, EventArgs e)
        {
            if (LinuxSerDownaddr != "")
            {
                Data.CopyData(LinuxSerDownaddr);
                TagShow("已复制");
            }
            else
            {
                TagShow("没有获取到远程下载地址");
            }
        }

        private void Exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void min_btn_Click(object sender, EventArgs e)
        {
            Tools.Formoperate.WinForms.FormMessage((IntPtr)this.Handle,1);
        }


        // 用于移动窗口
        private void TitleMenu_MouseDown(object sender, MouseEventArgs e)
        {
            Tools.Formoperate.WinForms.MoveFrom(this.Handle);
        }
        private void TITLE_MouseDown(object sender, MouseEventArgs e)
        {
            Tools.Formoperate.WinForms.MoveFrom(this.Handle);
        }

        private void setup_Click(object sender, EventArgs e)
        {
            Formsetup Setup = new Formsetup();
            Setup.MainForm = this;
            Setup.ShowDialog();
        }


        public String GetHttpData(string Url)
        {
            string strResult = "";
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                //声明一个HttpWebRequest请求
                request.Timeout = 10 * 1000;  //设置连接超时时间
                request.Host = "www.minecraft.net";
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                //request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:89.0) Gecko/20100101 Firefox/89.0";

                request.Headers.Set("Cache-Control", "no-cache");
                request.Headers.Set("Upgrade-Insecure-Requests", "1");
                request.Headers.Set("Pragma", "no-cache");
                //request.Headers.Set("Accept-Encoding", "gzip, deflate, br");
                request.Headers.Set("Accept-Language", "zh-CN,zh;q=0.8,zh-TW;q=0.7,zh-HK;q=0.5,en-US;q=0.3,en;q=0.2");
                request.Headers.Set("Cookie", "ApplicationGatewayAffinityCORS=1bfc026d9c4b7d17a636076dd33a8622");
                request.Method = "GET";
                request.KeepAlive = true;
                request.Referer = Url;
                
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.ToString() != "")
                {
                    Stream streamReceive = response.GetResponseStream();
                    Encoding encoding = Encoding.GetEncoding("UTF-8");
                    StreamReader streamReader = new StreamReader(streamReceive, encoding);
                    strResult = streamReader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            //MessageBox.Show(strResult);
            return strResult;
        }
    }
}
