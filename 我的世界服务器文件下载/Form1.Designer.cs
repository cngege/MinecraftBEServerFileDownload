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
            this.label1 = new System.Windows.Forms.Label();
            this.DownInformation = new System.Windows.Forms.Button();
            this.DownWinServer = new System.Windows.Forms.Button();
            this.DownLinuxServer = new System.Windows.Forms.Button();
            this.CopyWinAddr = new System.Windows.Forms.Button();
            this.CopyLinuxAddr = new System.Windows.Forms.Button();
            this.info_copyright = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(1, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "我的世界PE国际版服务器文件下载[当前位置]";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DownInformation
            // 
            this.DownInformation.AutoSize = true;
            this.DownInformation.Location = new System.Drawing.Point(12, 43);
            this.DownInformation.Name = "DownInformation";
            this.DownInformation.Size = new System.Drawing.Size(87, 23);
            this.DownInformation.TabIndex = 1;
            this.DownInformation.Text = "获取下载信息";
            this.DownInformation.UseVisualStyleBackColor = true;
            this.DownInformation.Click += new System.EventHandler(this.DownInformation_Click);
            // 
            // DownWinServer
            // 
            this.DownWinServer.AutoSize = true;
            this.DownWinServer.Location = new System.Drawing.Point(125, 43);
            this.DownWinServer.Name = "DownWinServer";
            this.DownWinServer.Size = new System.Drawing.Size(87, 23);
            this.DownWinServer.TabIndex = 2;
            this.DownWinServer.Text = "下载win文件";
            this.DownWinServer.UseVisualStyleBackColor = true;
            this.DownWinServer.Click += new System.EventHandler(this.DownWinServer_Click);
            // 
            // DownLinuxServer
            // 
            this.DownLinuxServer.AutoSize = true;
            this.DownLinuxServer.Location = new System.Drawing.Point(239, 43);
            this.DownLinuxServer.Name = "DownLinuxServer";
            this.DownLinuxServer.Size = new System.Drawing.Size(100, 23);
            this.DownLinuxServer.TabIndex = 3;
            this.DownLinuxServer.Text = "下载Linux文件";
            this.DownLinuxServer.UseVisualStyleBackColor = true;
            this.DownLinuxServer.Click += new System.EventHandler(this.DownLinuxServer_Click);
            // 
            // CopyWinAddr
            // 
            this.CopyWinAddr.AutoSize = true;
            this.CopyWinAddr.Location = new System.Drawing.Point(125, 83);
            this.CopyWinAddr.Name = "CopyWinAddr";
            this.CopyWinAddr.Size = new System.Drawing.Size(87, 23);
            this.CopyWinAddr.TabIndex = 4;
            this.CopyWinAddr.Text = "复制下载地址";
            this.CopyWinAddr.UseVisualStyleBackColor = true;
            this.CopyWinAddr.Click += new System.EventHandler(this.CopyWinAddr_Click);
            // 
            // CopyLinuxAddr
            // 
            this.CopyLinuxAddr.AutoSize = true;
            this.CopyLinuxAddr.Location = new System.Drawing.Point(239, 83);
            this.CopyLinuxAddr.Name = "CopyLinuxAddr";
            this.CopyLinuxAddr.Size = new System.Drawing.Size(100, 23);
            this.CopyLinuxAddr.TabIndex = 5;
            this.CopyLinuxAddr.Text = "复制下载地址";
            this.CopyLinuxAddr.UseVisualStyleBackColor = true;
            this.CopyLinuxAddr.Click += new System.EventHandler(this.CopyLinuxAddr_Click);
            // 
            // info_copyright
            // 
            this.info_copyright.AutoSize = true;
            this.info_copyright.Location = new System.Drawing.Point(12, 83);
            this.info_copyright.Name = "info_copyright";
            this.info_copyright.Size = new System.Drawing.Size(87, 23);
            this.info_copyright.TabIndex = 6;
            this.info_copyright.Text = "关于";
            this.info_copyright.UseVisualStyleBackColor = true;
            this.info_copyright.Click += new System.EventHandler(this.info_copyright_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 179);
            this.Controls.Add(this.info_copyright);
            this.Controls.Add(this.CopyLinuxAddr);
            this.Controls.Add(this.CopyWinAddr);
            this.Controls.Add(this.DownLinuxServer);
            this.Controls.Add(this.DownWinServer);
            this.Controls.Add(this.DownInformation);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Menu";
            this.Text = "我的世界BE服务器文件下载QQ:2586850402";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button DownInformation;
        private System.Windows.Forms.Button DownWinServer;
        private System.Windows.Forms.Button DownLinuxServer;
        private System.Windows.Forms.Button CopyWinAddr;
        private System.Windows.Forms.Button CopyLinuxAddr;
        private System.Windows.Forms.Button info_copyright;
    }
}

