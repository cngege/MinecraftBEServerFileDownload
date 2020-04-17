using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace 我的世界服务器文件下载
{
    class download
    {
        private String Url;
        private String SavePath;
        private String SaveFile = "Default";
        private const string Suffix = ".downloading";


        public download(String _Url = "",String _SavePath = "" ,String _SaveFile = "")
        {
            Url = _Url;
            SaveFile = _SaveFile;
            SavePath = _SavePath;
        }

        public bool Start()
        {
            if (SavePath == "" || Url == "")
            {
                return false;
            }
            if (!SavePath.EndsWith("\\"))
            {
                SavePath += "\\";
            }
            
            bool flag = false;
            long SPosition;
            FileStream FStream = null;
            Stream myStream = null;
            String desFile = SavePath + SaveFile + Suffix;
            try
            {
                //判断要下载的文件夹是否存在
                if (File.Exists(desFile))
                {
                    //打开上次下载的文件
                    FStream = File.OpenWrite(desFile);
                    //获取已经下载的长度
                    SPosition = FStream.Length;
                    long serverFileLength = GetHttpLength(Url);
                    if (SPosition == serverFileLength)
                    {//文件是完整的，直接结束下载任务
                        return true;
                    }
                    FStream.Seek(SPosition, SeekOrigin.Current);
                }
                else
                {
                    //文件不保存创建一个文件
                    FStream = new FileStream(desFile, FileMode.Create);
                    SPosition = 0;
                }
                //打开网络连接
                HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(Url);
                if (SPosition > 0)
                {
                    myRequest.AddRange(SPosition);             //设置Range值
                }
                //向服务器请求,获得服务器的回应数据流
                myStream = myRequest.GetResponse().GetResponseStream();
                //定义一个字节数据
                byte[] btContent = new byte[512];
                int intSize = 0;
                intSize = myStream.Read(btContent, 0, 512);
                while (intSize > 0)
                {
                    FStream.Write(btContent, 0, intSize);
                    intSize = myStream.Read(btContent, 0, 512);
                }
                flag = true;//返回true下载成功
            }
            catch
            {
                //下载文件时异常
            }
            finally
            {
                //关闭流
                if (myStream != null)
                {
                    myStream.Close();
                    myStream.Dispose();
                }
                if (FStream != null)
                {
                    FStream.Close();
                    FStream.Dispose();
                }
            }
            if (flag)
            {
                File.Move(desFile, SavePath + SaveFile);
            }
            return flag;
        }

        // 从文件头得到远程文件的长度
        private long GetHttpLength(string url)
        {
            long length = 0;
            HttpWebRequest req = null;
            HttpWebResponse rsp = null;
            try
            {
                req = (HttpWebRequest)HttpWebRequest.Create(url);
                rsp = (HttpWebResponse)req.GetResponse();
                if (rsp.StatusCode == HttpStatusCode.OK)
                    length = rsp.ContentLength;
            }
            catch
            {
                //获取远程文件大小失败
            }
            finally
            {
                if (rsp != null)
                    rsp.Close();
                if (req != null)
                    req.Abort();
            }

            return length;
        }


        public void SetUrl(String _Url)
        {
            this.Url = _Url;
        }

        public void SetLoadPath(String path)
        {
            this.SaveFile = path;
        }

        public void SetSaveFile(String _File)
        {
            SaveFile = _File;
        }
    }
}
