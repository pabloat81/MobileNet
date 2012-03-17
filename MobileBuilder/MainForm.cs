using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MobileNet;
using System.IO;

namespace TestMobileBuilder
{
    public partial class MainForm : Form
    {
        StatusInformer StatusInformer;
        Commands Commands;

        string _ProjectPath = string.Empty;
        public string ProjectPath
        {
            get { return _ProjectPath; }
            set 
            { 
                _ProjectPath = value;
                lblProjectLocation.Text = value;
            }
        }

        MBConfig Config;

        public MainForm()
        {
            InitializeComponent();            
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
                        
            StatusInformer = new StatusInformer(this, buildProgress, rtbConsole, Notifier);

            LoadRecentProjects();
            ProjectPath = Config.RecentProjects.FirstOrDefault() ?? string.Empty;
            Commands = new Commands(StatusInformer, ProjectPath, null);           
        }
            
        private void LoadRecentProjects()
        {
            try
            {
                MBConfig c = new MBConfig();
                Config = c.DeSerialize(Directory.GetCurrentDirectory() + "\\MBConfig.config");
                List<string> toRemove = new List<string>();

                foreach (string path in Config.RecentProjects)
                {
                    if (!string.IsNullOrEmpty(path) && Directory.Exists(path))
                        recentProjects.DropDownItems.Add(path, null, OpenRecentProject);
                    else if (!Directory.Exists(path))
                        toRemove.Add(path);
                }

                if (toRemove.Count > 0)
                {
                    foreach(string path in toRemove)
                        Config.RecentProjects.Remove(path);                    
                }
            }
            catch { }
        }

        void OpenRecentProject(object sender, EventArgs e)
        {
            ProjectPath = ((ToolStripItem)sender).Text;
            Commands.ChangeRootPath(ProjectPath);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            if (Config.RecentProjects.Where(p => p.ToLower() == ProjectPath.ToLower()).Count() == 0)
            {
                Config.RecentProjects.Add(ProjectPath);
                Config.Serialize(Directory.GetCurrentDirectory() + "\\MBConfig.config");
            }
        }

        private void miOpenProject_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ffd = new FolderBrowserDialog();
            
            ffd.ShowNewFolderButton = false;
            
            if (ffd.ShowDialog() == DialogResult.OK)
            {
                ProjectPath = ffd.SelectedPath;
                lblProjectLocation.Text = ProjectPath;
                Commands.ChangeRootPath(ProjectPath);
            }
        }

        private void build_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProjectPath))
            {
                MessageBox.Show("You have to open a project.");
                return;
            }

            Commands.Build(false);            
        }

        private void watch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProjectPath))
            {
                MessageBox.Show("You have to open a project.");
                return;
            }

            Commands.Watch(true, false);
        }

        private void startServer_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProjectPath))
            {
                MessageBox.Show("You have to open a project.");
                return;
            }

            if (!Commands.ServerCanBeStarted)
            { 
                MessageBox.Show("Server can't be started yet, build or watch project first");
                return;
            }

            Commands.StartServer();
        }

        private void about_Click(object sender, EventArgs e)
        {
            (new About()).ShowDialog();
        } 
    }
}
