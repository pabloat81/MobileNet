namespace TestMobileBuilder
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.bottomStatusBar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.recentProjects = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.about = new System.Windows.Forms.ToolStripMenuItem();
            this.topStripBar = new System.Windows.Forms.ToolStrip();
            this.build = new System.Windows.Forms.ToolStripButton();
            this.watch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.buildProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.serverPort = new System.Windows.Forms.ToolStripTextBox();
            this.startServer = new System.Windows.Forms.ToolStripButton();
            this.stopServer = new System.Windows.Forms.ToolStripButton();
            this.Notifier = new System.Windows.Forms.NotifyIcon(this.components);
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.lblProjectLocation = new System.Windows.Forms.Label();
            this.bottomStatusBar.SuspendLayout();
            this.menu.SuspendLayout();
            this.topStripBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bottomStatusBar
            // 
            this.bottomStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel2});
            this.bottomStatusBar.Location = new System.Drawing.Point(0, 338);
            this.bottomStatusBar.Name = "bottomStatusBar";
            this.bottomStatusBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bottomStatusBar.Size = new System.Drawing.Size(514, 22);
            this.bottomStatusBar.TabIndex = 0;
            this.bottomStatusBar.Text = "statusStrip1";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel4.Text = "Failed: 0";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(55, 17);
            this.toolStripStatusLabel3.Text = "Passed: 0";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(46, 17);
            this.toolStripStatusLabel2.Text = "Total: 0";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(514, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miOpenProject,
            this.recentProjects});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // miOpenProject
            // 
            this.miOpenProject.Name = "miOpenProject";
            this.miOpenProject.Size = new System.Drawing.Size(155, 22);
            this.miOpenProject.Text = "Open Project";
            this.miOpenProject.Click += new System.EventHandler(this.miOpenProject_Click);
            // 
            // recentProjects
            // 
            this.recentProjects.Name = "recentProjects";
            this.recentProjects.Size = new System.Drawing.Size(155, 22);
            this.recentProjects.Text = "Recent Projects";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.about});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // about
            // 
            this.about.Name = "about";
            this.about.Size = new System.Drawing.Size(107, 22);
            this.about.Text = "About";
            this.about.Click += new System.EventHandler(this.about_Click);
            // 
            // topStripBar
            // 
            this.topStripBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.build,
            this.watch,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.buildProgress,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.serverPort,
            this.startServer,
            this.stopServer});
            this.topStripBar.Location = new System.Drawing.Point(0, 24);
            this.topStripBar.Name = "topStripBar";
            this.topStripBar.Size = new System.Drawing.Size(514, 33);
            this.topStripBar.TabIndex = 2;
            this.topStripBar.Text = "toolStrip1";
            // 
            // build
            // 
            this.build.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.build.Image = ((System.Drawing.Image)(resources.GetObject("build.Image")));
            this.build.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.build.Name = "build";
            this.build.Size = new System.Drawing.Size(23, 30);
            this.build.Text = "toolStripButton1";
            this.build.ToolTipText = "Build";
            this.build.Click += new System.EventHandler(this.build_Click);
            // 
            // watch
            // 
            this.watch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.watch.Image = ((System.Drawing.Image)(resources.GetObject("watch.Image")));
            this.watch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.watch.Name = "watch";
            this.watch.Size = new System.Drawing.Size(23, 30);
            this.watch.Text = "toolStripButton2";
            this.watch.ToolTipText = "Watch";
            this.watch.Click += new System.EventHandler(this.watch_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(71, 30);
            this.toolStripLabel1.Text = "Build status:";
            // 
            // buildProgress
            // 
            this.buildProgress.Name = "buildProgress";
            this.buildProgress.Size = new System.Drawing.Size(150, 30);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 33);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(67, 30);
            this.toolStripLabel2.Text = "Server Port:";
            // 
            // serverPort
            // 
            this.serverPort.Name = "serverPort";
            this.serverPort.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.serverPort.Size = new System.Drawing.Size(35, 33);
            this.serverPort.Text = "4000";
            this.serverPort.ToolTipText = "Server Port";
            // 
            // startServer
            // 
            this.startServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startServer.Image = ((System.Drawing.Image)(resources.GetObject("startServer.Image")));
            this.startServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startServer.Name = "startServer";
            this.startServer.Size = new System.Drawing.Size(23, 30);
            this.startServer.Text = "toolStripButton1";
            this.startServer.ToolTipText = "Start Server";
            this.startServer.Click += new System.EventHandler(this.startServer_Click);
            // 
            // stopServer
            // 
            this.stopServer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopServer.Image = ((System.Drawing.Image)(resources.GetObject("stopServer.Image")));
            this.stopServer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopServer.Name = "stopServer";
            this.stopServer.Size = new System.Drawing.Size(23, 30);
            this.stopServer.Text = "toolStripButton2";
            this.stopServer.ToolTipText = "Stop Server";
            this.stopServer.Visible = false;
            // 
            // Notifier
            // 
            this.Notifier.Icon = ((System.Drawing.Icon)(resources.GetObject("Notifier.Icon")));
            this.Notifier.Text = "notifyIcon1";
            this.Notifier.Visible = true;
            // 
            // rtbConsole
            // 
            this.rtbConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbConsole.Location = new System.Drawing.Point(12, 70);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.Size = new System.Drawing.Size(491, 238);
            this.rtbConsole.TabIndex = 3;
            this.rtbConsole.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 315);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblProjectLocation);
            this.splitContainer1.Size = new System.Drawing.Size(490, 19);
            this.splitContainer1.SplitterDistance = 106;
            this.splitContainer1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Project location:";
            // 
            // lblProjectLocation
            // 
            this.lblProjectLocation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblProjectLocation.AutoSize = true;
            this.lblProjectLocation.Location = new System.Drawing.Point(3, 5);
            this.lblProjectLocation.Name = "lblProjectLocation";
            this.lblProjectLocation.Size = new System.Drawing.Size(13, 13);
            this.lblProjectLocation.TabIndex = 0;
            this.lblProjectLocation.Text = "--";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 360);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.rtbConsole);
            this.Controls.Add(this.topStripBar);
            this.Controls.Add(this.bottomStatusBar);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "Mobile Builder";
            this.bottomStatusBar.ResumeLayout(false);
            this.bottomStatusBar.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.topStripBar.ResumeLayout(false);
            this.topStripBar.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip bottomStatusBar;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miOpenProject;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem about;
        private System.Windows.Forms.ToolStrip topStripBar;
        private System.Windows.Forms.ToolStripButton build;
        private System.Windows.Forms.ToolStripButton watch;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox serverPort;
        private System.Windows.Forms.ToolStripButton startServer;
        private System.Windows.Forms.ToolStripButton stopServer;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripProgressBar buildProgress;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.NotifyIcon Notifier;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblProjectLocation;
        private System.Windows.Forms.ToolStripMenuItem recentProjects;
    }
}