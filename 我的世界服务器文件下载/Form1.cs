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
using Tools.Fileoperate;

namespace 我的世界服务器文件下载
{
    public partial class Menu : Form
    {
        public String RunDir = Directory.GetCurrentDirectory();
        public String GitHub = "https://github.com/cngege/MinecraftBEServerFileDownload.git";

        public string API = "https://net-secondary.web.minecraft-services.net/api/v1.0/download/links";

        public String Serveraddr = "https://www.minecraft.net/en-us/download/server/bedrock/";
        public String Httpdata = "";
        public String PilterA = "https://www.minecraft.net/bedrockdedicatedserver/bin-win/bedrock-server-";
        public String PilterB = ".zip";
        public String PilterC = "https://www.minecraft.net/bedrockdedicatedserver/bin-linux/bedrock-server-";

        public String WinSerDownaddr = "";
        public String WinSaveFilename = "";
        public String WinVersion = "";

        public String LinuxSerDownaddr = "";
        public String LinuxSaveFilename = "";
        public String LinuxVersion = "";

        public InIFile savedata;
        public String SavePath;
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;    //允许线程操作UI
            savedata = new InIFile(RunDir + "\\MSDL.ini");
            SavePath = savedata.Read("SavePath","key", RunDir);
            
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

            Httpdata = GetHttpData(API);
            if (Httpdata == "")
            {
                this.BeginInvoke(new Analysis_class(TagShow),new object[] { "没有能读取到官网信息，后续操作中断" });
                return;
            }
            try {
                var data = JSON.parse(Httpdata);
                if(data != null) {
                    foreach(var item in data["result"]["links"]) {
                        if (item["downloadType"] == "serverBedrockWindows") {
                            WinSerDownaddr = item["downloadUrl"];
                            int 最后一个左斜杠位置 = WinSerDownaddr.LastIndexOf("/");
                            WinSaveFilename = WinSerDownaddr.Substring(最后一个左斜杠位置 + 1);
                            int 版本号开始位置 = 最后一个左斜杠位置 + 1 + "bedrock-server-".Length;
                            WinVersion = WinSerDownaddr.Substring(版本号开始位置, WinSerDownaddr.LastIndexOf(".zip") - 版本号开始位置);

                            DownWinServer.Enabled = true;
                            CopyWinAddr.Enabled = true;
                        }
                        else if (item["downloadType"] == "serverBedrockLinux") {
                            LinuxSerDownaddr = item["downloadUrl"];
                            int 最后一个左斜杠位置 = LinuxSerDownaddr.LastIndexOf("/");
                            LinuxSaveFilename = LinuxSerDownaddr.Substring(最后一个左斜杠位置 + 1);
                            int 版本号开始位置 = 最后一个左斜杠位置 + 1 + "bedrock-server-".Length;
                            LinuxVersion = LinuxSerDownaddr.Substring(版本号开始位置, LinuxSerDownaddr.LastIndexOf(".zip") - 版本号开始位置);

                            DownLinuxServer.Enabled = true;
                            CopyLinuxAddr.Enabled = true;
                        }
                    }
                }
            } catch(Exception ex) {
                this.BeginInvoke(new Analysis_class(TagShow), new object[] { "解析JSON异常，" + ex.Message + " " + Httpdata });
                return;
            }

            /**
             * {"result":{"links":[{"downloadType":"serverBedrockWindows","downloadUrl":"https://www.minecraft.net/bedrockdedicatedserver/bin-win/bedrock-server-1.21.92.1.zip"},{"downloadType":"serverBedrockLinux","downloadUrl":"https://www.minecraft.net/bedrockdedicatedserver/bin-linux/bedrock-server-1.21.92.1.zip"},{"downloadType":"serverBedrockPreviewWindows","downloadUrl":"https://www.minecraft.net/bedrockdedicatedserver/bin-win-preview/bedrock-server-1.21.100.21.zip"},{"downloadType":"serverBedrockPreviewLinux","downloadUrl":"https://www.minecraft.net/bedrockdedicatedserver/bin-linux-preview/bedrock-server-1.21.100.21.zip"},{"downloadType":"serverJar","downloadUrl":"https://piston-data.mojang.com/v1/objects/6e64dcabba3c01a7271b4fa6bd898483b794c59b/server.jar"}]}}
             */

            //TagShow("寻找Windows下载地址特征开始位置");

            if (WinSerDownaddr != "" && LinuxSerDownaddr != "") {
                this.BeginInvoke(new Analysis_class(TagShow), new object[] { $"Win版本：{WinVersion},Linux版本：{LinuxVersion}" });
            } else {
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

                
                Download DownWinServer = new Download(WinSerDownaddr, SavePath, WinSaveFilename);
                DownWinServer.Suffix = ".mcbds";    //定义下载的缓存文件后缀

                int win_percent;
                DownWinServer.Downprogress += (long filesize, long httpsize, bool isok) =>  //下载回调函数
                {
                    if (isok)   //回调函数中指示下载完成
                    {
                        this.DownWinServer.Enabled = true;
                        TagShow($"{WinSaveFilename} 下载完成");
                    }
                    win_percent = Download.GetintPercent(filesize, httpsize);   //计算并在进度条上显示下载进度
                    if (win_percent <= 100) Win_Bar.Value = win_percent;
                };

                switch (DownWinServer.Start())
                {
                    case 0:
                        this.DownWinServer.Enabled = true;
                        TagShow($"{WinSaveFilename} 下载失败");
                        break;
                    case 1:
                        this.DownWinServer.Enabled = false;
                        TagShow($"{WinSaveFilename} 开始下载");
                        break;
                    case 2:
                        this.DownWinServer.Enabled = true;
                        TagShow($"{WinSaveFilename} 下载完成");
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
                Download DownLinuxServer = new Download(LinuxSerDownaddr, SavePath, LinuxSaveFilename);
                DownLinuxServer.Suffix = ".mcbds";
                int lin_percent;
                DownLinuxServer.Downprogress += (long filesize, long httpsize, bool isok) =>
                {
                    if (isok)
                    {
                        this.DownLinuxServer.Enabled = true;
                        TagShow($"{LinuxSaveFilename} 下载完成");
                    }

                    lin_percent = Download.GetintPercent(filesize, httpsize);   //计算并在进度条上显示下载进度
                    if (lin_percent <= 100) Lin_Bar.Value = lin_percent;
                };

                switch (DownLinuxServer.Start())
                {
                    case 0:
                        this.DownLinuxServer.Enabled = true;
                        TagShow($"{LinuxSaveFilename} 下载失败");
                        break;
                    case 1:
                        this.DownLinuxServer.Enabled = false;
                        TagShow($"{LinuxSaveFilename} 开始下载");
                        break;
                    case 2:
                        this.DownLinuxServer.Enabled = true;
                        TagShow($"{LinuxSaveFilename} 下载完成");
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
            Tools.Formoperate.WinForms.MoveForm(this.Handle);
        }
        private void TITLE_MouseDown(object sender, MouseEventArgs e)
        {
            Tools.Formoperate.WinForms.MoveForm(this.Handle);
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
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
                //声明一个HttpWebRequest请求
                request.Timeout = 10 * 1000;  //设置连接超时时间
                request.Host = "net-secondary.web.minecraft-services.net";
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
