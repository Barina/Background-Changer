namespace Background_Changer
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.counterTimer = new System.Windows.Forms.Timer(this.components);
            this.fileContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.setToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectNoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wallpaperToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.largeImageList = new System.Windows.Forms.ImageList(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.nameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pathColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.schedulerGroupBox = new System.Windows.Forms.GroupBox();
            this.nextWallButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.viewComboBox = new System.Windows.Forms.ComboBox();
            this.queueModeComboBox = new System.Windows.Forms.ComboBox();
            this.styleComboBox = new System.Windows.Forms.ComboBox();
            this.minutesNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.taskLabel1 = new System.Windows.Forms.Label();
            this.intervalLabel1 = new System.Windows.Forms.Label();
            this.schedulerEnabledCheckBox1 = new System.Windows.Forms.CheckBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.selectedToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.fileListView1 = new System.Windows.Forms.ListView();
            this.styleColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageListBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.titleMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.desktopContextMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNextWallpaperOptionToDesktopContextMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeNextWallpaperOptionFromDesktopContextMenuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileContextMenuStrip.SuspendLayout();
            this.schedulerGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minutesNumericUpDown1)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.titleMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Multiselect = true;
            // 
            // counterTimer
            // 
            this.counterTimer.Interval = 1000;
            this.counterTimer.Tick += new System.EventHandler(this.counterTimer_Tick);
            // 
            // fileContextMenuStrip
            // 
            this.fileContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.toolStripSeparator3,
            this.setToolStripMenuItem,
            this.openToolStripMenuItem,
            this.openDirToolStripMenuItem,
            this.toolStripSeparator1,
            this.addToolStripMenuItem,
            this.addDirToolStripMenuItem,
            this.toolStripSeparator2,
            this.selectAllToolStripMenuItem,
            this.selectNoneToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.fileContextMenuStrip.Name = "fileContextMenuStrip";
            this.fileContextMenuStrip.OwnerItem = this.wallpaperToolStripMenuItem;
            this.fileContextMenuStrip.Size = new System.Drawing.Size(202, 242);
            this.fileContextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.fileContextMenuStrip_Opening);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Enabled = false;
            this.editToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.editToolStripMenuItem.Text = "Edit Wallpaper";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(198, 6);
            // 
            // setToolStripMenuItem
            // 
            this.setToolStripMenuItem.Enabled = false;
            this.setToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.setToolStripMenuItem.Name = "setToolStripMenuItem";
            this.setToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.setToolStripMenuItem.Text = "Set as Wallpaper";
            this.setToolStripMenuItem.Click += new System.EventHandler(this.setToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Enabled = false;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.openToolStripMenuItem.Text = "Open File";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openDirToolStripMenuItem
            // 
            this.openDirToolStripMenuItem.Name = "openDirToolStripMenuItem";
            this.openDirToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.openDirToolStripMenuItem.Text = "Open Containing Folder";
            this.openDirToolStripMenuItem.Click += new System.EventHandler(this.openDirToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(198, 6);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.addToolStripMenuItem.Text = "Add wallpapers...";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // addDirToolStripMenuItem
            // 
            this.addDirToolStripMenuItem.Name = "addDirToolStripMenuItem";
            this.addDirToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.addDirToolStripMenuItem.Text = "Add folder";
            this.addDirToolStripMenuItem.Click += new System.EventHandler(this.addDirToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(198, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // selectNoneToolStripMenuItem
            // 
            this.selectNoneToolStripMenuItem.Name = "selectNoneToolStripMenuItem";
            this.selectNoneToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.selectNoneToolStripMenuItem.Text = "Select None";
            this.selectNoneToolStripMenuItem.Click += new System.EventHandler(this.selectToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Enabled = false;
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Enabled = false;
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.clearToolStripMenuItem.Text = "Clear all";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // wallpaperToolStripMenuItem
            // 
            this.wallpaperToolStripMenuItem.DropDown = this.fileContextMenuStrip;
            this.wallpaperToolStripMenuItem.Name = "wallpaperToolStripMenuItem";
            this.wallpaperToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.wallpaperToolStripMenuItem.Text = "Wallpaper";
            // 
            // largeImageList
            // 
            this.largeImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth16Bit;
            this.largeImageList.ImageSize = new System.Drawing.Size(256, 128);
            this.largeImageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // nameColumnHeader
            // 
            this.nameColumnHeader.Text = "Name";
            this.nameColumnHeader.Width = 129;
            // 
            // pathColumnHeader
            // 
            this.pathColumnHeader.Text = "Path";
            this.pathColumnHeader.Width = 487;
            // 
            // schedulerGroupBox
            // 
            this.schedulerGroupBox.Controls.Add(this.nextWallButton);
            this.schedulerGroupBox.Controls.Add(this.label1);
            this.schedulerGroupBox.Controls.Add(this.viewComboBox);
            this.schedulerGroupBox.Controls.Add(this.queueModeComboBox);
            this.schedulerGroupBox.Controls.Add(this.styleComboBox);
            this.schedulerGroupBox.Controls.Add(this.minutesNumericUpDown1);
            this.schedulerGroupBox.Controls.Add(this.taskLabel1);
            this.schedulerGroupBox.Controls.Add(this.intervalLabel1);
            this.schedulerGroupBox.Controls.Add(this.schedulerEnabledCheckBox1);
            this.schedulerGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.schedulerGroupBox.Location = new System.Drawing.Point(0, 24);
            this.schedulerGroupBox.Name = "schedulerGroupBox";
            this.schedulerGroupBox.Size = new System.Drawing.Size(1440, 119);
            this.schedulerGroupBox.TabIndex = 1;
            this.schedulerGroupBox.TabStop = false;
            this.schedulerGroupBox.Text = "Schedule";
            // 
            // nextWallButton
            // 
            this.nextWallButton.Location = new System.Drawing.Point(400, 70);
            this.nextWallButton.Name = "nextWallButton";
            this.nextWallButton.Size = new System.Drawing.Size(104, 23);
            this.nextWallButton.TabIndex = 9;
            this.nextWallButton.Text = "Next Wallpaper";
            this.nextWallButton.UseVisualStyleBackColor = true;
            this.nextWallButton.Click += new System.EventHandler(this.nextWallButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1268, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "View:";
            // 
            // viewComboBox
            // 
            this.viewComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.viewComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.viewComboBox.FormattingEnabled = true;
            this.viewComboBox.Location = new System.Drawing.Point(1307, 92);
            this.viewComboBox.Name = "viewComboBox";
            this.viewComboBox.Size = new System.Drawing.Size(121, 21);
            this.viewComboBox.TabIndex = 4;
            // 
            // queueModeComboBox
            // 
            this.queueModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.queueModeComboBox.FormattingEnabled = true;
            this.queueModeComboBox.Location = new System.Drawing.Point(383, 42);
            this.queueModeComboBox.Name = "queueModeComboBox";
            this.queueModeComboBox.Size = new System.Drawing.Size(121, 21);
            this.queueModeComboBox.TabIndex = 4;
            // 
            // styleComboBox
            // 
            this.styleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.styleComboBox.FormattingEnabled = true;
            this.styleComboBox.Location = new System.Drawing.Point(256, 42);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.Size = new System.Drawing.Size(121, 21);
            this.styleComboBox.TabIndex = 4;
            // 
            // minutesNumericUpDown1
            // 
            this.minutesNumericUpDown1.Location = new System.Drawing.Point(112, 43);
            this.minutesNumericUpDown1.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.minutesNumericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minutesNumericUpDown1.Name = "minutesNumericUpDown1";
            this.minutesNumericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.minutesNumericUpDown1.TabIndex = 3;
            this.minutesNumericUpDown1.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.minutesNumericUpDown1.ValueChanged += new System.EventHandler(this.minutesNumericUpDown1_ValueChanged);
            // 
            // taskLabel1
            // 
            this.taskLabel1.AutoSize = true;
            this.taskLabel1.Location = new System.Drawing.Point(6, 70);
            this.taskLabel1.Name = "taskLabel1";
            this.taskLabel1.Size = new System.Drawing.Size(80, 13);
            this.taskLabel1.TabIndex = 2;
            this.taskLabel1.Text = "There\'s no task";
            // 
            // intervalLabel1
            // 
            this.intervalLabel1.AutoSize = true;
            this.intervalLabel1.Location = new System.Drawing.Point(6, 45);
            this.intervalLabel1.Name = "intervalLabel1";
            this.intervalLabel1.Size = new System.Drawing.Size(84, 13);
            this.intervalLabel1.TabIndex = 1;
            this.intervalLabel1.Text = "Minutes interval:";
            // 
            // schedulerEnabledCheckBox1
            // 
            this.schedulerEnabledCheckBox1.AutoSize = true;
            this.schedulerEnabledCheckBox1.Checked = global::Background_Changer.Properties.Settings.Default.EnableScheduler;
            this.schedulerEnabledCheckBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::Background_Changer.Properties.Settings.Default, "EnableScheduler", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.schedulerEnabledCheckBox1.Location = new System.Drawing.Point(6, 20);
            this.schedulerEnabledCheckBox1.Name = "schedulerEnabledCheckBox1";
            this.schedulerEnabledCheckBox1.Size = new System.Drawing.Size(110, 17);
            this.schedulerEnabledCheckBox1.TabIndex = 0;
            this.schedulerEnabledCheckBox1.Text = "Enable Scheduler";
            this.schedulerEnabledCheckBox1.UseVisualStyleBackColor = true;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.selectedToolStripStatusLabel,
            this.statusToolStripProgressBar});
            this.statusStrip.Location = new System.Drawing.Point(0, 743);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1440, 22);
            this.statusStrip.TabIndex = 2;
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(59, 17);
            this.toolStripStatusLabel.Text = "Loading...";
            this.toolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // selectedToolStripStatusLabel
            // 
            this.selectedToolStripStatusLabel.Name = "selectedToolStripStatusLabel";
            this.selectedToolStripStatusLabel.Size = new System.Drawing.Size(1366, 17);
            this.selectedToolStripStatusLabel.Spring = true;
            this.selectedToolStripStatusLabel.Text = "0 Selected";
            this.selectedToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusToolStripProgressBar
            // 
            this.statusToolStripProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.statusToolStripProgressBar.Name = "statusToolStripProgressBar";
            this.statusToolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.statusToolStripProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.statusToolStripProgressBar.Visible = false;
            // 
            // fileListView1
            // 
            this.fileListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.nameColumnHeader,
            this.pathColumnHeader,
            this.styleColumnHeader});
            this.fileListView1.ContextMenuStrip = this.fileContextMenuStrip;
            this.fileListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileListView1.FullRowSelect = true;
            this.fileListView1.HideSelection = false;
            this.fileListView1.LargeImageList = this.largeImageList;
            this.fileListView1.Location = new System.Drawing.Point(0, 143);
            this.fileListView1.Name = "fileListView1";
            this.fileListView1.Size = new System.Drawing.Size(1440, 600);
            this.fileListView1.TabIndex = 3;
            this.fileListView1.UseCompatibleStateImageBehavior = false;
            this.fileListView1.ItemActivate += new System.EventHandler(this.fileListView_ItemActivate);
            // 
            // styleColumnHeader
            // 
            this.styleColumnHeader.Text = "Style";
            // 
            // imageListBackgroundWorker
            // 
            this.imageListBackgroundWorker.WorkerReportsProgress = true;
            this.imageListBackgroundWorker.WorkerSupportsCancellation = true;
            this.imageListBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.imageLoaderBackgroundWorker_DoWork);
            this.imageListBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.imageLoaderBackgroundWorker_ProgressChanged);
            this.imageListBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.imageLoaderBackgroundWorker_RunWorkerCompleted);
            // 
            // titleMenuStrip
            // 
            this.titleMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.wallpaperToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.titleMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.titleMenuStrip.Name = "titleMenuStrip";
            this.titleMenuStrip.Size = new System.Drawing.Size(1440, 24);
            this.titleMenuStrip.TabIndex = 9;
            this.titleMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.desktopContextMenuToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // desktopContextMenuToolStripMenuItem
            // 
            this.desktopContextMenuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNextWallpaperOptionToDesktopContextMenuToolStripMenuItem,
            this.removeNextWallpaperOptionFromDesktopContextMenuToolStripMenuItem});
            this.desktopContextMenuToolStripMenuItem.Name = "desktopContextMenuToolStripMenuItem";
            this.desktopContextMenuToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.desktopContextMenuToolStripMenuItem.Text = "Desktop Context Menu";
            // 
            // addNextWallpaperOptionToDesktopContextMenuToolStripMenuItem
            // 
            this.addNextWallpaperOptionToDesktopContextMenuToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addNextWallpaperOptionToDesktopContextMenuToolStripMenuItem.Name = "addNextWallpaperOptionToDesktopContextMenuToolStripMenuItem";
            this.addNextWallpaperOptionToDesktopContextMenuToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.addNextWallpaperOptionToDesktopContextMenuToolStripMenuItem.Text = "Add Short-Cut";
            this.addNextWallpaperOptionToDesktopContextMenuToolStripMenuItem.Click += new System.EventHandler(this.addToContextButton_Click);
            // 
            // removeNextWallpaperOptionFromDesktopContextMenuToolStripMenuItem
            // 
            this.removeNextWallpaperOptionFromDesktopContextMenuToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.removeNextWallpaperOptionFromDesktopContextMenuToolStripMenuItem.Name = "removeNextWallpaperOptionFromDesktopContextMenuToolStripMenuItem";
            this.removeNextWallpaperOptionFromDesktopContextMenuToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.removeNextWallpaperOptionFromDesktopContextMenuToolStripMenuItem.Text = "Remove Short-Cut";
            this.removeNextWallpaperOptionFromDesktopContextMenuToolStripMenuItem.Click += new System.EventHandler(this.removeFromContextButton_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 765);
            this.Controls.Add(this.fileListView1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.schedulerGroupBox);
            this.Controls.Add(this.titleMenuStrip);
            this.KeyPreview = true;
            this.MainMenuStrip = this.titleMenuStrip;
            this.MinimumSize = new System.Drawing.Size(126, 39);
            this.Name = "MainForm";
            this.Text = "Background Changer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.fileContextMenuStrip.ResumeLayout(false);
            this.schedulerGroupBox.ResumeLayout(false);
            this.schedulerGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minutesNumericUpDown1)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.titleMenuStrip.ResumeLayout(false);
            this.titleMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Timer counterTimer;
        private System.Windows.Forms.ColumnHeader nameColumnHeader;
        private System.Windows.Forms.ColumnHeader pathColumnHeader;
        private System.Windows.Forms.ImageList largeImageList;
        private System.Windows.Forms.ContextMenuStrip fileContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem setToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem addDirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.GroupBox schedulerGroupBox;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ComboBox styleComboBox;
        private System.Windows.Forms.NumericUpDown minutesNumericUpDown1;
        private System.Windows.Forms.Label taskLabel1;
        private System.Windows.Forms.Label intervalLabel1;
        private System.Windows.Forms.CheckBox schedulerEnabledCheckBox1;
        private System.Windows.Forms.ListView fileListView1;
        private System.ComponentModel.BackgroundWorker imageListBackgroundWorker;
        private System.Windows.Forms.ComboBox queueModeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip titleMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ComboBox viewComboBox;
        private System.Windows.Forms.ToolStripMenuItem wallpaperToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectNoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem desktopContextMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeNextWallpaperOptionFromDesktopContextMenuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNextWallpaperOptionToDesktopContextMenuToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader styleColumnHeader;
        private System.Windows.Forms.Button nextWallButton;
        private System.Windows.Forms.ToolStripProgressBar statusToolStripProgressBar;
        private System.Windows.Forms.ToolStripMenuItem openDirToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel selectedToolStripStatusLabel;
    }
}

