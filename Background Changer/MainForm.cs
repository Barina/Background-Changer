using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using Microsoft.Win32.TaskScheduler;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using System.Threading;
using System.Drawing.Imaging;
using System.Diagnostics;
using Background_Changer.WallUtils;
using System.IO.Pipes;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace Background_Changer
{
    public partial class MainForm : Form
    {
        WallHelper wallHelper;
        WallpaperQueue queue;
        SyncedQueue<Wallpaper> loaderQueue;
        SyncedQueue<Wallpaper> removalQueue;
        ListViewItem currentWallpaperItem;
        Task currentTask;

        public MainForm()
        {
            InitializeComponent();
            wallHelper = WallHelper.Instance;
            queue = WallpaperQueue.Instance;
            queue.WallpapersCleared += Queue_WallpapersCleared;
            loaderQueue = new SyncedQueue<Wallpaper>();
            removalQueue = new SyncedQueue<Wallpaper>();
            styleComboBox.DataSource = Enum.GetValues(typeof(WallHelper.WallpaperStyle));
            styleComboBox.SelectedIndex = (int)wallHelper.CurrentStyle;
            styleComboBox.SelectedIndexChanged += styleComboBox_SelectedIndexChanged;
            queueModeComboBox.DataSource = Enum.GetValues(typeof(WallpaperQueue.QueueMode));
            queueModeComboBox.SelectedIndex = (int)queue.QueueOrder;
            queueModeComboBox.SelectedIndexChanged += queueModeComboBox_SelectedIndexChanged;
            viewComboBox.DataSource = Enum.GetValues(typeof(View));
            viewComboBox.SelectedIndexChanged += viewComboBox_SelectedIndexChanged;
            viewComboBox.SelectedIndex = Properties.Settings.Default.CurrentView;
            TimeSpan interval = Properties.Settings.Default.ChangeInterval;
            minutesNumericUpDown1.Value = interval.Minutes;
            addWallpaperToListView(queue.Wallpapers.ToArray());
            updateComponent();
        }

        private void Queue_WallpapersCleared(object sender, EventArgs e)
        {
            schedulerEnabledCheckBox1.Checked = false;
        }

        private void updateComponent()
        {
            currentTask = wallHelper.GetCurrentTask();
            if (currentTask != null)
            {
                taskLabel1.Text = "Next execution will occure at " + currentTask.NextRunTime;
                counterTimer.Enabled = true;
            }
            else
            {
                taskLabel1.Text = "Scheduler is paused.";
                counterTimer.Enabled = false;
            }
            //string currentWall = wallHelper.CurrentWallpaper;
            //if (!string.IsNullOrEmpty(currentWall) && files.Contains(currentWall))
            Wallpaper current = queue.CurrentWallpaper;
            if (current != null && current.PathExist)
            {
                if (currentWallpaperItem != null)
                    currentWallpaperItem.BackColor = fileListView1.BackColor;
                currentWallpaperItem = fileListView1.Items[current.ID.ToString()];
                if (currentWallpaperItem != null)
                    currentWallpaperItem.BackColor = Color.YellowGreen;
            }
            foreach (ListViewItem item in fileListView1.Items)
            {
                Wallpaper wall = item.Tag as Wallpaper;
                item.SubItems[0].Text = wall.Name;
                item.SubItems[1].Text = wall.Path;
                item.SubItems[2].Text = wall.WallpaperStyle?.ToString() ?? "Auto";
            }
            switch (this.queue.Wallpapers.Count)
            {
                case 0:
                    toolStripStatusLabel.Text = "No Wallpapers..";
                    break;
                case 1:
                    toolStripStatusLabel.Text = this.queue.Wallpapers.Count + " Wallpaper";
                    break;
                default:
                    toolStripStatusLabel.Text = this.queue.Wallpapers.Count + " Wallpapers";
                    break;
            }
        }

        private void counterTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan timeLeft = currentTask.NextRunTime - DateTime.Now;
            string currentName = queue?.CurrentWallpaper?.Name ?? "None";
            string nextName = queue?.NextWallpaper?.Name ?? "None";
            if (counterTimer.Enabled = timeLeft.Milliseconds > 0)
                taskLabel1.Text = string.Format("Current wallpaper: '{0}'{1}Next wallpaper: '{2}'{1}Next execution: {3}",
                    currentName, Environment.NewLine, nextName, timeLeft.ToString(@"dd\.hh\:mm\:ss"));
            else
                updateComponent();
        }

        private void styleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            wallHelper.CurrentStyle = (WallHelper.WallpaperStyle)styleComboBox.SelectedIndex;
        }

        private void addNewWallpaperFiles(params string[] files)
        {
            List<Wallpaper> walls = new List<Wallpaper>();
            foreach (var file in files)
            {
                if (!File.Exists(file))
                    continue;

                string ext = Path.GetExtension(file).ToUpper();
                if (!wallHelper.extAllowed(ext))
                    continue;

                Wallpaper wall = new Wallpaper(file);
                if (queue.Wallpapers.Contains(wall))
                    continue;

                walls.Add(wall);
            }
            queue.addWallpapers(walls);
            addWallpaperToListView(walls.ToArray());
        }

        private void addWallpaperToListView(params Wallpaper[] walls)
        {
            foreach (var wall in walls)
            {
                removalQueue.RemoveItem(wall);

                if (!wall.PathExist)
                    continue;

                loaderQueue.Enqueue(wall);
                ListViewItem item = new ListViewItem(wall.Name);
                item.Name = wall.ID.ToString();
                item.Tag = wall;
                item.SubItems.Add(wall.Path);
                item.SubItems.Add(wall.WallpaperStyle?.ToString() ?? "Auto");
                item.ImageKey = wall.ID.ToString();

                string dir = Path.GetDirectoryName(wall.Path);
                ListViewGroup group = fileListView1.Groups[dir];
                if (group == null)
                    group = new ListViewGroup(dir, dir);
                item.Group = group;

                fileListView1.Groups.Add(group);
                fileListView1.Items.Add(item);
            }

            if (!imageListBackgroundWorker.IsBusy)
            {
                imageListBackgroundWorker.RunWorkerAsync();
                statusToolStripProgressBar.Visible = true;
            }
        }

        private void removeWallpapers(params Wallpaper[] wallpapers)
        {
            foreach (Wallpaper wall in wallpapers)
            {
                loaderQueue.RemoveItem(wall);
                removalQueue.Enqueue(wall);

                queue.removeWallpaper(wall);
                fileListView1.Items.RemoveByKey(wall.ID.ToString());
                //largeImageList.Images.RemoveByKey(wall.ID.ToString());
            }

            if (!imageListBackgroundWorker.IsBusy)
            {
                imageListBackgroundWorker.RunWorkerAsync();
                statusToolStripProgressBar.Visible = true;
            }
        }

        private void imageLoaderBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (removalQueue.Peek() != null || loaderQueue.Peek() != null)
            {
                if (imageListBackgroundWorker.CancellationPending)
                    return;

                if (loaderQueue.Peek() != null)
                {
                    Wallpaper wall = loaderQueue.Dequeue();
                    try
                    {
                        using (Image image = Image.FromFile(wall.Path))
                        {
                            Image pic = WallHelper.resizeImage(image, 256, 128);
                            (sender as BackgroundWorker).ReportProgress(0, new object[] { wall.ID.ToString(), pic });
                        }
                    }
                    catch (InvalidOperationException) { }
                    catch (OutOfMemoryException) { }
                }

                if (removalQueue.Peek() != null)
                {
                    Wallpaper wall = removalQueue.Dequeue();
                    (sender as BackgroundWorker).ReportProgress(0, new object[] { wall.ID.ToString(), null });
                }

                Thread.Sleep(100);
            }
        }

        private void imageLoaderBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            object[] data = e.UserState as object[];
            string id = data[0] as string;
            Image pic = data[1] as Image;
            if (pic != null)
            {
                if (!largeImageList.Images.ContainsKey(id))
                    largeImageList.Images.Add(id, pic);
                pic.Dispose();
            }
            else
                largeImageList.Images.RemoveByKey(id);
        }

        private void imageLoaderBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            statusToolStripProgressBar.Visible = false;
        }

        private void setToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setCurrentSelectedAsWallpaper();
        }

        private void setCurrentSelectedAsWallpaper()
        {
            if (fileListView1.SelectedItems.Count <= 0)
                return;
            ListViewItem item = fileListView1.SelectedItems[0];
            wallHelper.SetWallpaper(item.Tag as Wallpaper);
            queue.advance(item.Tag as Wallpaper);
            updateComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                addNewWallpaperFiles(openFileDialog.FileNames);
                updateComponent();
            }
        }

        private void addDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                addNewWallpaperFiles(Directory.GetFiles(folderBrowserDialog.SelectedPath));
                updateComponent();
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to clear all wallpapers?", "Please confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                removeWallpapers(queue.Wallpapers.ToArray());
                updateComponent();
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Wallpaper[] walls = new Wallpaper[fileListView1.SelectedItems.Count];

            for (int i = 0; i < fileListView1.SelectedItems.Count; i++)
                walls[i] = fileListView1.SelectedItems[i].Tag as Wallpaper;

            removeWallpapers(walls);
            updateComponent();
        }

        private void fileListView_ItemActivate(object sender, EventArgs e)
        {
            editSelectedWallpapers();
        }

        private void fileContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            editToolStripMenuItem.Enabled = openDirToolStripMenuItem.Enabled = openToolStripMenuItem.Enabled =
                setToolStripMenuItem.Enabled = removeToolStripMenuItem.Enabled = fileListView1.SelectedItems.Count > 0;
            clearToolStripMenuItem.Enabled = queue.Wallpapers.Count > 0;
            selectAllToolStripMenuItem.Enabled = fileListView1.SelectedItems.Count < fileListView1.Items.Count;
            selectNoneToolStripMenuItem.Enabled = fileListView1.SelectedItems.Count > 1;
            editToolStripMenuItem.Text = "Edit Wallpaper";
            if (fileListView1.SelectedItems.Count > 1)
                editToolStripMenuItem.Text += "s";
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] paths = e.Data.GetData(DataFormats.FileDrop) as string[];
            foreach (var path in paths)
            {
                FileAttributes attr = File.GetAttributes(path);
                if (attr.HasFlag(FileAttributes.Directory))
                    addNewWallpaperFiles(Directory.GetFiles(path));
                else
                    addNewWallpaperFiles(path);
            }
            updateComponent();
        }

        private const string MenuName = @"DesktopBackground\shell\background.changer";
        private const string Command = @"DesktopBackground\shell\background.changer\command";

        private void addToContextButton_Click(object sender, EventArgs e)
        {
            RegistryKey regmenu = null;
            RegistryKey regcmd = null;
            try
            {
                regmenu = Registry.ClassesRoot.CreateSubKey(MenuName);
                if (regmenu != null)
                    regmenu.SetValue("", "Next Wallpaper");
                regcmd = Registry.ClassesRoot.CreateSubKey(Command);
                if (regcmd != null)
                    regcmd.SetValue("", "\"" + Application.ExecutablePath + "\" c");
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
            finally
            {
                if (regmenu != null)
                    regmenu.Close();
                if (regcmd != null)
                    regcmd.Close();
            }
        }

        private void removeFromContextButton_Click(object sender, EventArgs e)
        {
            try
            {
                RegistryKey reg = Registry.ClassesRoot.OpenSubKey(Command);
                if (reg != null)
                {
                    reg.Close();
                    Registry.ClassesRoot.DeleteSubKey(Command);
                }
                reg = Registry.ClassesRoot.OpenSubKey(MenuName);
                if (reg != null)
                {
                    reg.Close();
                    Registry.ClassesRoot.DeleteSubKey(MenuName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.ToString());
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileListView1.SelectedItems.Count > 1)
            {
                if (MessageBox.Show("Open all selected images?", "Please confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    foreach (ListViewItem item in fileListView1.SelectedItems)
                        Process.Start((item.Tag as Wallpaper).Path);
            }
            else
                if (fileListView1.SelectedItems.Count == 1)
                Process.Start((fileListView1.SelectedItems[0].Tag as Wallpaper).Path);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Size = Properties.Settings.Default.MainSize;
            this.Location = Properties.Settings.Default.MainLocation;
            this.WindowState = Properties.Settings.Default.MainState;
            schedulerEnabledCheckBox1.Checked = wallHelper.GetCurrentTask() != null;
            fileListView1.SelectedIndexChanged += fileListView1_SelectedIndexChanged;
            schedulerEnabledCheckBox1.CheckedChanged += schedulerEnabledCheckBox_CheckedChanged;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            largeImageList.Dispose();

            Properties.Settings.Default.ChangeInterval = new TimeSpan(0, (int)minutesNumericUpDown1.Value, 0);
            Properties.Settings.Default.EnableScheduler = schedulerEnabledCheckBox1.Checked;

            queue.commitChanges();
            Properties.Settings.Default.MainState = this.WindowState;
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.MainSize = this.Size;
                Properties.Settings.Default.MainLocation = this.Location;
            }
            else
            {
                Properties.Settings.Default.MainSize = this.RestoreBounds.Size;
                Properties.Settings.Default.MainLocation = this.RestoreBounds.Location;
            }
            Properties.Settings.Default.Save();
        }

        private void queueModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            queue.QueueOrder = (WallpaperQueue.QueueMode)queueModeComboBox.SelectedItem;
            queue.reorderQueue();
        }

        private void viewComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            fileListView1.View = (View)viewComboBox.SelectedItem;
            Properties.Settings.Default.CurrentView = viewComboBox.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tool = sender as ToolStripMenuItem;
            if (tool.Name == selectAllToolStripMenuItem.Name || tool.Name == selectNoneToolStripMenuItem.Name)
                foreach (ListViewItem item in fileListView1.Items)
                    item.Selected = tool.Name == selectAllToolStripMenuItem.Name;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editSelectedWallpapers();
        }

        private void editSelectedWallpapers()
        {
            Wallpaper[] walls = new Wallpaper[fileListView1.SelectedItems.Count];
            for (int i = 0; i < walls.Length; i++)
                walls[i] = fileListView1.SelectedItems[i].Tag as Wallpaper;
            WallpaperDetailsForm details = new WallpaperDetailsForm(walls);
            if (details.ShowDialog(this) == DialogResult.OK)
                queue.changeWallpapers(details.Result);
            updateComponent();
        }

        private void schedulerEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TimeSpan interval = Properties.Settings.Default.ChangeInterval;
            if (schedulerEnabledCheckBox1.Checked)
                wallHelper.SetNewSchedule(interval);
            else
                wallHelper.ClearSchedule();
            updateComponent();
        }

        private void minutesNumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.ChangeInterval = new TimeSpan(0, (int)minutesNumericUpDown1.Value, 0);
        }

        private void nextWallButton_Click(object sender, EventArgs e)
        {
            wallHelper.SetNextWallpaper();
            updateComponent();
        }

        //private void taskListenerBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    while (true)
        //    {
        //        using (var stream = new NamedPipeServerStream("ChangeBGPipe", PipeDirection.InOut))
        //        {
        //            stream.WaitForConnection();
        //            taskListenerBackgroundWorker.ReportProgress(0);
        //        }
        //    }
        //}

        //private void taskListenerBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        //{
        //    nextWallButton.PerformClick();
        //}

        private void openDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> dirs = new List<string>();

            foreach (ListViewItem item in fileListView1.SelectedItems)
            {
                string wallPath = (item.Tag as Wallpaper).Path;
                if (string.IsNullOrEmpty(dirs.Find(d => Path.GetDirectoryName(d) == Path.GetDirectoryName(wallPath))))
                    dirs.Add(wallPath);
            }

            foreach (var dir in dirs)
                Process.Start("explorer.exe", "/select," + dir);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Program.WM_MSG)
                nextWallButton.PerformClick();
            base.WndProc(ref m);
        }

        private void fileListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedToolStripStatusLabel.Text = fileListView1.SelectedItems.Count + " Selected";

            foreach (ListViewItem item in fileListView1.SelectedItems)
            {
                Wallpaper wall = item.Tag as Wallpaper;
                if (!largeImageList.Images.ContainsKey(wall.ID.ToString()))
                {
                    loaderQueue.RemoveItem(wall);
                    loaderQueue.PushFirst(wall);
                    break;
                }
            }
        }
    }
}