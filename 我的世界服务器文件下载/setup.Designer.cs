namespace 我的世界服务器文件下载
{
    partial class Formsetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formsetup));
            this.RadioBtn1 = new System.Windows.Forms.RadioButton();
            this.RadioBtn2 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Exitbtn = new System.Windows.Forms.PictureBox();
            this.SetupTitle = new System.Windows.Forms.Label();
            this.PathText = new System.Windows.Forms.Label();
            this.Selectpath = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SavePath = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Exitbtn)).BeginInit();
            this.SuspendLayout();
            // 
            // RadioBtn1
            // 
            this.RadioBtn1.AutoSize = true;
            this.RadioBtn1.Checked = true;
            this.RadioBtn1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RadioBtn1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RadioBtn1.ForeColor = System.Drawing.Color.White;
            this.RadioBtn1.Location = new System.Drawing.Point(12, 95);
            this.RadioBtn1.Name = "RadioBtn1";
            this.RadioBtn1.Size = new System.Drawing.Size(139, 24);
            this.RadioBtn1.TabIndex = 2;
            this.RadioBtn1.TabStop = true;
            this.RadioBtn1.Tag = "path";
            this.RadioBtn1.Text = "下载到程序同路径";
            this.RadioBtn1.UseVisualStyleBackColor = true;
            this.RadioBtn1.CheckedChanged += new System.EventHandler(this.RadioBtn1_CheckedChanged);
            // 
            // RadioBtn2
            // 
            this.RadioBtn2.AutoSize = true;
            this.RadioBtn2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RadioBtn2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RadioBtn2.ForeColor = System.Drawing.Color.White;
            this.RadioBtn2.Location = new System.Drawing.Point(12, 129);
            this.RadioBtn2.Name = "RadioBtn2";
            this.RadioBtn2.Size = new System.Drawing.Size(97, 24);
            this.RadioBtn2.TabIndex = 3;
            this.RadioBtn2.Tag = "path";
            this.RadioBtn2.Text = "自定义路径";
            this.RadioBtn2.UseVisualStyleBackColor = true;
            this.RadioBtn2.CheckedChanged += new System.EventHandler(this.RadioBtn2_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.SetupTitle);
            this.panel1.Controls.Add(this.Exitbtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(302, 30);
            this.panel1.TabIndex = 4;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // Exitbtn
            // 
            this.Exitbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exitbtn.Image = ((System.Drawing.Image)(resources.GetObject("Exitbtn.Image")));
            this.Exitbtn.Location = new System.Drawing.Point(269, 3);
            this.Exitbtn.Name = "Exitbtn";
            this.Exitbtn.Size = new System.Drawing.Size(25, 24);
            this.Exitbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Exitbtn.TabIndex = 2;
            this.Exitbtn.TabStop = false;
            this.Exitbtn.Tag = "";
            this.Exitbtn.Click += new System.EventHandler(this.Exitbtn_Click_1);
            // 
            // SetupTitle
            // 
            this.SetupTitle.AutoSize = true;
            this.SetupTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SetupTitle.ForeColor = System.Drawing.Color.White;
            this.SetupTitle.Location = new System.Drawing.Point(16, 4);
            this.SetupTitle.Name = "SetupTitle";
            this.SetupTitle.Size = new System.Drawing.Size(37, 20);
            this.SetupTitle.TabIndex = 3;
            this.SetupTitle.Text = "设置";
            // 
            // PathText
            // 
            this.PathText.AutoEllipsis = true;
            this.PathText.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.PathText.ForeColor = System.Drawing.Color.LightGray;
            this.PathText.Location = new System.Drawing.Point(11, 43);
            this.PathText.Name = "PathText";
            this.PathText.Size = new System.Drawing.Size(291, 49);
            this.PathText.TabIndex = 5;
            this.PathText.Text = "C:\\";
            // 
            // Selectpath
            // 
            this.Selectpath.ForeColor = System.Drawing.Color.Transparent;
            this.Selectpath.Location = new System.Drawing.Point(129, 132);
            this.Selectpath.Margin = new System.Windows.Forms.Padding(0);
            this.Selectpath.Name = "Selectpath";
            this.Selectpath.Size = new System.Drawing.Size(75, 23);
            this.Selectpath.TabIndex = 6;
            this.Selectpath.Text = "选择位置";
            this.Selectpath.UseVisualStyleBackColor = false;
            this.Selectpath.Click += new System.EventHandler(this.Selectpath_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(218, 132);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SavePath
            // 
            this.SavePath.Description = "请选择下载文件要保存的目录";
            // 
            // Formsetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(33)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(302, 178);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Selectpath);
            this.Controls.Add(this.PathText);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RadioBtn2);
            this.Controls.Add(this.RadioBtn1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Formsetup";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "setup";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Formsetup_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Exitbtn)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton RadioBtn1;
        private System.Windows.Forms.RadioButton RadioBtn2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Exitbtn;
        private System.Windows.Forms.Label SetupTitle;
        private System.Windows.Forms.Label PathText;
        private System.Windows.Forms.Button Selectpath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog SavePath;
    }
}