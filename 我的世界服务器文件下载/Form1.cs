using System;
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

namespace 我的世界服务器文件下载
{
    public partial class Menu : Form
    {
        public String RunDir = Directory.GetCurrentDirectory();
        public String Tail = ".MCBDS";

        public String Serveraddr = "https://www.minecraft.net/zh-hans/download/server/bedrock/";
        public String Httpdata = "";
        public String PilterA = "https://minecraft.azureedge.net/bin-win/bedrock-server-";
        public String PilterB = ".zip";
        public String PilterC = "https://minecraft.azureedge.net/bin-linux/bedrock-server-";

        public String WinSerDownaddr = "";
        public int Winstartposition = 0;
        public int WinaddrLong = 0;
        public String WinVersion = "";

        public String LinuxSerDownaddr = "";
        public int Linuxstartposition = 0;
        public int LinuxaddrLong = 0;
        public String LinuxVersion = "";

        public Menu()
        {
            InitializeComponent();
        }

        public String GetHttp(string Url)
        {
            string strResult = "";
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                //声明一个HttpWebRequest请求
                request.Timeout = 3000000;
                //设置连接超时时间
                request.Headers.Set("Pragma", "no-cache");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.ToString() != "")
                {
                    Stream streamReceive = response.GetResponseStream();
                    Encoding encoding = Encoding.GetEncoding("UTF-8");
                    StreamReader streamReader = new StreamReader(streamReceive, encoding);
                    strResult = streamReader.ReadToEnd();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("错误："+exp.Message);
                strResult = "";
            }
            return strResult;
        }

        public void TagShow(String text)
        {
            label1.Text = text;
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;    //允许线程操作UI
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

            Httpdata = Download.GetHttpData(Serveraddr);
            if (Httpdata == "")
            {
                this.BeginInvoke(new Analysis_class(TagShow),new object[] { "没有能读取到官网信息，后续操作中断" });
                return;
            }

            //TagShow("寻找Windows下载地址特征开始位置");
            Winstartposition = Httpdata.IndexOf(PilterA);
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

                //判断文件是否存在,及大小包是否完整,是否需要断点续传
                try
                {
                    FileInfo infoA = new FileInfo(RunDir + $"\\WinSer{WinVersion}.zip");
                    FileInfo infoB = new FileInfo(RunDir + $"\\WinSer{WinVersion}.zip" + Tail);
                    if (infoA.Exists)
                    {
                        if (infoA.Length >= Download.GetHttpLength(WinSerDownaddr))
                        {
                            TagShow($"WinSer{WinVersion}.zip下载结束[文件存在]");
                            return;
                        }
                        if (infoB.Exists)
                        {
                            if (infoA.Length > infoB.Length)
                            {
                                infoB.Delete();
                                infoA.MoveTo(RunDir + $"\\WinSer{WinVersion}.zip" + Tail);
                            }
                            else
                            {
                                infoA.Delete();
                            }
                        }
                        else
                        {
                            infoA.MoveTo(RunDir + $"\\WinSer{WinVersion}.zip" + Tail);
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message,"发送错误");
                }
                






                Download DownWinServer = new Download(WinSerDownaddr,RunDir,$"WinSer{WinVersion}.zip"+Tail);
                double win_percent;
                DownWinServer.Downprogress += (long filesize, long httpsize, bool isok) =>
                {
                    if (isok)
                    {
                        this.DownWinServer.Enabled = true;
                        TagShow($"WinSer{WinVersion}.zip下载完成");
                        new FileInfo(RunDir+ $"\\WinSer{WinVersion}.zip" + Tail).MoveTo(RunDir + $"\\WinSer{WinVersion}.zip");
                    }

                    win_percent = Download.GetintPercent(filesize, httpsize);   //计算并在进度条上显示下载进度
                    if ((int)win_percent <= 100) Win_Bar.Value = (int)win_percent;


                };

                if (DownWinServer.Start())
                {
                    this.DownWinServer.Enabled = false;
                    TagShow($"WinSer{WinVersion}.zip开始下载");
                }
                else
                {
                    this.DownWinServer.Enabled = true;
                    TagShow($"WinSer{WinVersion}.zip下载失败");
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

                //判断文件是否存在,及大小包是否完整,是否需要断点续传
                try
                {
                    FileInfo infoA = new FileInfo(RunDir + $"\\LinuxSer{LinuxVersion}.zip");
                    FileInfo infoB = new FileInfo(RunDir + $"\\LinuxSer{LinuxVersion}.zip" + Tail);
                    if (infoA.Exists)
                    {
                        if (infoA.Length >= Download.GetHttpLength(LinuxSerDownaddr))
                        {
                            TagShow($"LinuxSer{LinuxVersion}.zip下载结束[文件存在]");
                            return;
                        }
                        if (infoB.Exists)
                        {
                            if (infoA.Length > infoB.Length)
                            {
                                infoB.Delete();
                                infoA.MoveTo(RunDir + $"\\LinuxSer{LinuxVersion}.zip" + Tail);
                            }
                            else
                            {
                                infoA.Delete();
                            }
                        }
                        else
                        {
                            infoA.MoveTo(RunDir + $"\\LinuxSer{LinuxVersion}.zip" + Tail);
                        }
                    }
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message, "发送错误");
                }

                //开始实例化下载
                Download DownLinuxServer = new Download(LinuxSerDownaddr,RunDir,$"LinuxSer{LinuxVersion}.zip" + Tail);
                double lin_percent;
                DownLinuxServer.Downprogress += (long filesize, long httpsize, bool isok) =>
                {
                    if (isok)
                    {
                        this.DownLinuxServer.Enabled = true;
                        TagShow($"LinuxSer{LinuxVersion}.zip下载完成");
                        new FileInfo(RunDir + $"\\LinuxSer{LinuxVersion}.zip" + Tail).MoveTo(RunDir + $"\\LinuxSer{LinuxVersion}.zip");
                    }

                    lin_percent = Download.GetintPercent(filesize, httpsize);   //计算并在进度条上显示下载进度
                    if ((int)lin_percent <= 100) Lin_Bar.Value = (int)lin_percent;


                };

                if (DownLinuxServer.Start())
                {
                    this.DownLinuxServer.Enabled = false;
                    TagShow($"LinuxSer{LinuxVersion}.zip开始下载");
                }
                else
                {
                    this.DownLinuxServer.Enabled = true;
                    TagShow($"LinuxSer{LinuxVersion}.zip下载失败");
                }

            }
        }
        #endregion

        private void info_copyright_Click(object sender, EventArgs e)
        {
            MessageBox.Show("C#开发,GitHub开源\n我的世界BE服务端文件下载器\n可转载至非商业用途\n作者：貔貅I勿念\n联系QQ：2586850402","AppInfo");
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



        // 用于移动窗口
        private void TitleMenu_MouseDown(object sender, MouseEventArgs e)
        {
            Tools.Formoperate.WinForms.MoveFrom(this.Handle);
        }
        private void TITLE_MouseDown(object sender, MouseEventArgs e)
        {
            Tools.Formoperate.WinForms.MoveFrom(this.Handle);
        }
    }
}
