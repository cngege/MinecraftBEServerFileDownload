namespace 我的世界服务器文件下载
{
    partial class Menu
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.TitleMenu = new System.Windows.Forms.Panel();
            this.setup = new System.Windows.Forms.PictureBox();
            this.min_btn = new System.Windows.Forms.PictureBox();
            this.TITLE = new System.Windows.Forms.Label();
            this.Exitbtn = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Lin_Bar = new System.Windows.Forms.ProgressBar();
            this.Win_Bar = new System.Windows.Forms.ProgressBar();
            this.Lin_Text = new System.Windows.Forms.Label();
            this.Win_Text = new System.Windows.Forms.Label();
            this.info_copyright = new System.Windows.Forms.Button();
            this.CopyLinuxAddr = new System.Windows.Forms.Button();
            this.CopyWinAddr = new System.Windows.Forms.Button();
            this.DownLinuxServer = new System.Windows.Forms.Button();
            this.DownWinServer = new System.Windows.Forms.Button();
            this.DownInformation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TitleMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_btn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exitbtn)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitleMenu
            // 
            this.TitleMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(50)))));
            this.TitleMenu.Controls.Add(this.setup);
            this.TitleMenu.Controls.Add(this.min_btn);
            this.TitleMenu.Controls.Add(this.TITLE);
            this.TitleMenu.Controls.Add(this.Exitbtn);
            this.TitleMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleMenu.Location = new System.Drawing.Point(0, 0);
            this.TitleMenu.Name = "TitleMenu";
            this.TitleMenu.Size = new System.Drawing.Size(400, 24);
            this.TitleMenu.TabIndex = 7;
            this.TitleMenu.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleMenu_MouseDown);
            // 
            // setup
            // 
            this.setup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setup.Image = global::我的世界服务器文件下载.Properties.Resources.设置;
            this.setup.Location = new System.Drawing.Point(299, 0);
            this.setup.Name = "setup";
            this.setup.Size = new System.Drawing.Size(25, 24);
            this.setup.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.setup.TabIndex = 3;
            this.setup.TabStop = false;
            this.setup.Tag = "";
            this.setup.Click += new System.EventHandler(this.setup_Click);
            // 
            // min_btn
            // 
            this.min_btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.min_btn.Image = global::我的世界服务器文件下载.Properties.Resources.缩小;
            this.min_btn.Location = new System.Drawing.Point(332, 0);
            this.min_btn.Name = "min_btn";
            this.min_btn.Size = new System.Drawing.Size(25, 24);
            this.min_btn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.min_btn.TabIndex = 2;
            this.min_btn.TabStop = false;
            this.min_btn.Tag = "";
            this.min_btn.Click += new System.EventHandler(this.min_btn_Click);
            // 
            // TITLE
            // 
            this.TITLE.AutoSize = true;
            this.TITLE.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TITLE.ForeColor = System.Drawing.Color.White;
            this.TITLE.Location = new System.Drawing.Point(12, 4);
            this.TITLE.Name = "TITLE";
            this.TITLE.Size = new System.Drawing.Size(155, 17);
            this.TITLE.TabIndex = 1;
            this.TITLE.Text = "我的世界BE服务器文件下载\r\n";
            this.TITLE.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TITLE.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TITLE_MouseDown);
            // 
            // Exitbtn
            // 
            this.Exitbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exitbtn.Image = ((System.Drawing.Image)(resources.GetObject("Exitbtn.Image")));
            this.Exitbtn.Location = new System.Drawing.Point(363, 0);
            this.Exitbtn.Name = "Exitbtn";
            this.Exitbtn.Size = new System.Drawing.Size(25, 24);
            this.Exitbtn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Exitbtn.TabIndex = 0;
            this.Exitbtn.TabStop = false;
            this.Exitbtn.Tag = "";
            this.Exitbtn.Click += new System.EventHandler(this.Exitbtn_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panel2.Controls.Add(this.Lin_Bar);
            this.panel2.Controls.Add(this.Win_Bar);
            this.panel2.Controls.Add(this.Lin_Text);
            this.panel2.Controls.Add(this.Win_Text);
            this.panel2.Controls.Add(this.info_copyright);
            this.panel2.Controls.Add(this.CopyLinuxAddr);
            this.panel2.Controls.Add(this.CopyWinAddr);
            this.panel2.Controls.Add(this.DownLinuxServer);
            this.panel2.Controls.Add(this.DownWinServer);
            this.panel2.Controls.Add(this.DownInformation);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 216);
            this.panel2.TabIndex = 8;
            // 
            // Lin_Bar
            // 
            this.Lin_Bar.Location = new System.Drawing.Point(106, 191);
            this.Lin_Bar.Name = "Lin_Bar";
            this.Lin_Bar.Size = new System.Drawing.Size(249, 11);
            this.Lin_Bar.TabIndex = 11;
            // 
            // Win_Bar
            // 
            this.Win_Bar.Location = new System.Drawing.Point(106, 167);
            this.Win_Bar.Name = "Win_Bar";
            this.Win_Bar.Size = new System.Drawing.Size(249, 11);
            this.Win_Bar.TabIndex = 10;
            // 
            // Lin_Text
            // 
            this.Lin_Text.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lin_Text.ForeColor = System.Drawing.Color.White;
            this.Lin_Text.Location = new System.Drawing.Point(24, 183);
            this.Lin_Text.Name = "Lin_Text";
            this.Lin_Text.Size = new System.Drawing.Size(76, 24);
            this.Lin_Text.TabIndex = 9;
            this.Lin_Text.Text = "Lin_BDS";
            this.Lin_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Win_Text
            // 
            this.Win_Text.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Win_Text.ForeColor = System.Drawing.Color.White;
            this.Win_Text.Location = new System.Drawing.Point(24, 159);
            this.Win_Text.Name = "Win_Text";
            this.Win_Text.Size = new System.Drawing.Size(76, 24);
            this.Win_Text.TabIndex = 8;
            this.Win_Text.Text = "Win_BDS";
            this.Win_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // info_copyright
            // 
            this.info_copyright.AutoSize = true;
            this.info_copyright.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.info_copyright.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.info_copyright.ForeColor = System.Drawing.Color.White;
            this.info_copyright.Location = new System.Drawing.Point(28, 122);
            this.info_copyright.Name = "info_copyright";
            this.info_copyright.Size = new System.Drawing.Size(100, 24);
            this.info_copyright.TabIndex = 4;
            this.info_copyright.Text = "关于";
            this.info_copyright.UseVisualStyleBackColor = true;
            this.info_copyright.Click += new System.EventHandler(this.info_copyright_Click);
            // 
            // CopyLinuxAddr
            // 
            this.CopyLinuxAddr.AutoSize = true;
            this.CopyLinuxAddr.Enabled = false;
            this.CopyLinuxAddr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.CopyLinuxAddr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyLinuxAddr.ForeColor = System.Drawing.Color.White;
            this.CopyLinuxAddr.Location = new System.Drawing.Point(255, 122);
            this.CopyLinuxAddr.Name = "CopyLinuxAddr";
            this.CopyLinuxAddr.Size = new System.Drawing.Size(100, 24);
            this.CopyLinuxAddr.TabIndex = 6;
            this.CopyLinuxAddr.Text = "复制下载地址";
            this.CopyLinuxAddr.UseVisualStyleBackColor = true;
            this.CopyLinuxAddr.Click += new System.EventHandler(this.CopyLinuxAddr_Click);
            // 
            // CopyWinAddr
            // 
            this.CopyWinAddr.AutoSize = true;
            this.CopyWinAddr.Enabled = false;
            this.CopyWinAddr.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.CopyWinAddr.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CopyWinAddr.ForeColor = System.Drawing.Color.White;
            this.CopyWinAddr.Location = new System.Drawing.Point(141, 122);
            this.CopyWinAddr.Name = "CopyWinAddr";
            this.CopyWinAddr.Size = new System.Drawing.Size(100, 24);
            this.CopyWinAddr.TabIndex = 5;
            this.CopyWinAddr.Text = "复制下载地址";
            this.CopyWinAddr.UseVisualStyleBackColor = true;
            this.CopyWinAddr.Click += new System.EventHandler(this.CopyWinAddr_Click);
            // 
            // DownLinuxServer
            // 
            this.DownLinuxServer.AutoSize = true;
            this.DownLinuxServer.Enabled = false;
            this.DownLinuxServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.DownLinuxServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownLinuxServer.ForeColor = System.Drawing.Color.White;
            this.DownLinuxServer.Location = new System.Drawing.Point(255, 82);
            this.DownLinuxServer.Name = "DownLinuxServer";
            this.DownLinuxServer.Size = new System.Drawing.Size(100, 24);
            this.DownLinuxServer.TabIndex = 3;
            this.DownLinuxServer.Text = "下载Linux文件";
            this.DownLinuxServer.UseVisualStyleBackColor = true;
            this.DownLinuxServer.Click += new System.EventHandler(this.DownLinuxServer_Click);
            // 
            // DownWinServer
            // 
            this.DownWinServer.AutoSize = true;
            this.DownWinServer.Enabled = false;
            this.DownWinServer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.DownWinServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownWinServer.ForeColor = System.Drawing.Color.White;
            this.DownWinServer.Location = new System.Drawing.Point(141, 82);
            this.DownWinServer.Name = "DownWinServer";
            this.DownWinServer.Size = new System.Drawing.Size(100, 24);
            this.DownWinServer.TabIndex = 2;
            this.DownWinServer.Text = "下载win文件";
            this.DownWinServer.UseVisualStyleBackColor = true;
            this.DownWinServer.Click += new System.EventHandler(this.DownWinServer_Click);
            // 
            // DownInformation
            // 
            this.DownInformation.AutoSize = true;
            this.DownInformation.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.DownInformation.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Black;
            this.DownInformation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownInformation.ForeColor = System.Drawing.Color.White;
            this.DownInformation.Location = new System.Drawing.Point(28, 82);
            this.DownInformation.Name = "DownInformation";
            this.DownInformation.Size = new System.Drawing.Size(100, 24);
            this.DownInformation.TabIndex = 1;
            this.DownInformation.Text = "获取下载信息";
            this.DownInformation.UseVisualStyleBackColor = true;
            this.DownInformation.Click += new System.EventHandler(this.DownInformation_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(394, 31);
            this.label1.TabIndex = 7;
            this.label1.Text = "我的世界PE国际版服务器文件下载[默认当前位置]";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 240);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.TitleMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Minecraft Server Download";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.TitleMenu.ResumeLayout(false);
            this.TitleMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.setup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.min_btn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exitbtn)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitleMenu;
        private System.Windows.Forms.PictureBox Exitbtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button info_copyright;
        private System.Windows.Forms.Button CopyLinuxAddr;
        private System.Windows.Forms.Button CopyWinAddr;
        private System.Windows.Forms.Button DownLinuxServer;
        private System.Windows.Forms.Button DownWinServer;
        private System.Windows.Forms.Button DownInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label TITLE;
        private System.Windows.Forms.ProgressBar Lin_Bar;
        private System.Windows.Forms.ProgressBar Win_Bar;
        private System.Windows.Forms.Label Lin_Text;
        private System.Windows.Forms.Label Win_Text;
        private System.Windows.Forms.PictureBox min_btn;
        private System.Windows.Forms.PictureBox setup;
    }
}

