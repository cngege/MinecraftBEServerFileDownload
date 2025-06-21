using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tools.Fileoperate;

namespace 我的世界服务器文件下载
{
    public partial class Formsetup : Form
    {
        public Menu MainForm;
        
        InIFile savedata;
        String runParh;
        

        public Formsetup()
        {
            InitializeComponent();
        }

        private void Formsetup_Load(object sender, EventArgs e)
        {
            runParh = Directory.GetCurrentDirectory();
            savedata = MainForm.savedata;
            String saveSay = savedata.Read("SaveSay","key","0");
            if (saveSay == "0")
            {
                RadioBtn1.Select();
                PathText.Text = runParh;
                Selectpath.Enabled = false;
            }
            else if (saveSay == "1")
            {
                RadioBtn2.Select();
                PathText.Text = savedata.Read("SavePath", "key", runParh);
                Selectpath.Enabled = true;
            }
        }





        private void Exitbtn_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Tools.Formoperate.WinForms.MoveForm(this.Handle);
        }

        private void Selectpath_Click(object sender, EventArgs e)
        {
            DialogResult result = SavePath.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                PathText.Text = SavePath.SelectedPath;
                SetupTitle.Text = "设置";

            }
        }

        //设置页 保存按钮
        private void button1_Click(object sender, EventArgs e)
        {
            savedata.Write("SaveSay","key",RadioBtn1.Checked?"0":"1");  //存储选择框选中项
            savedata.Write("SavePath","key",PathText.Text);

            MainForm.SavePath = PathText.Text;

            SetupTitle.Text = "设置-已保存";
        }

        //单选框 下载到程序同路径
        private void RadioBtn1_CheckedChanged(object sender, EventArgs e)
        {
            /*            Selectpath.Enabled = false;
                        PathText.Text = runParh;
                        SetupTitle.Text = "设置";*/
            if (((RadioButton)sender).Checked)
            {
                PathText.Text = runParh;
                Selectpath.Enabled = false;
            }
            else
            {
                Selectpath.Enabled = true;
            }

            SetupTitle.Text = "设置";
        }

        //单选框 下载到自定义路径
        private void RadioBtn2_CheckedChanged(object sender, EventArgs e)
        {
            //Selectpath.Enabled = true;
            //SetupTitle.Text = "设置";

        }
    }
}
