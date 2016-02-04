namespace Background_Changer
{
    partial class WallpaperDetailsForm
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
            this.prevPictureBox = new System.Windows.Forms.PictureBox();
            this.nextPictureBox = new System.Windows.Forms.PictureBox();
            this.detailsPanel = new System.Windows.Forms.Panel();
            this.applyAllButton = new System.Windows.Forms.Button();
            this.styleComboBox = new System.Windows.Forms.ComboBox();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.styleLabel = new System.Windows.Forms.Label();
            this.pathLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.positionLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.wallPositionScrollBar = new System.Windows.Forms.HScrollBar();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.wallpaperPictureBox = new Background_Changer.WallpaperPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.prevPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextPictureBox)).BeginInit();
            this.detailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // prevPictureBox
            // 
            this.prevPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.prevPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.prevPictureBox.Location = new System.Drawing.Point(12, 403);
            this.prevPictureBox.Name = "prevPictureBox";
            this.prevPictureBox.Size = new System.Drawing.Size(280, 188);
            this.prevPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.prevPictureBox.TabIndex = 1;
            this.prevPictureBox.TabStop = false;
            this.prevPictureBox.Click += new System.EventHandler(this.prevPictureBox_Click);
            // 
            // nextPictureBox
            // 
            this.nextPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nextPictureBox.Location = new System.Drawing.Point(831, 403);
            this.nextPictureBox.Name = "nextPictureBox";
            this.nextPictureBox.Size = new System.Drawing.Size(280, 188);
            this.nextPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.nextPictureBox.TabIndex = 1;
            this.nextPictureBox.TabStop = false;
            this.nextPictureBox.Click += new System.EventHandler(this.nextPictureBox_Click);
            // 
            // detailsPanel
            // 
            this.detailsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailsPanel.BackColor = System.Drawing.Color.Gray;
            this.detailsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.detailsPanel.Controls.Add(this.applyAllButton);
            this.detailsPanel.Controls.Add(this.styleComboBox);
            this.detailsPanel.Controls.Add(this.pathTextBox);
            this.detailsPanel.Controls.Add(this.nameTextBox);
            this.detailsPanel.Controls.Add(this.styleLabel);
            this.detailsPanel.Controls.Add(this.pathLabel);
            this.detailsPanel.Controls.Add(this.nameLabel);
            this.detailsPanel.Controls.Add(this.positionLabel);
            this.detailsPanel.Controls.Add(this.titleLabel);
            this.detailsPanel.Location = new System.Drawing.Point(298, 380);
            this.detailsPanel.Name = "detailsPanel";
            this.detailsPanel.Size = new System.Drawing.Size(527, 233);
            this.detailsPanel.TabIndex = 2;
            // 
            // applyAllButton
            // 
            this.applyAllButton.BackColor = System.Drawing.Color.DimGray;
            this.applyAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.applyAllButton.ForeColor = System.Drawing.Color.White;
            this.applyAllButton.Location = new System.Drawing.Point(262, 135);
            this.applyAllButton.Name = "applyAllButton";
            this.applyAllButton.Size = new System.Drawing.Size(75, 23);
            this.applyAllButton.TabIndex = 5;
            this.applyAllButton.Text = "Apply for All";
            this.applyAllButton.UseVisualStyleBackColor = false;
            this.applyAllButton.Click += new System.EventHandler(this.apllyAllButton_Click);
            // 
            // styleComboBox
            // 
            this.styleComboBox.BackColor = System.Drawing.Color.DimGray;
            this.styleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.styleComboBox.ForeColor = System.Drawing.Color.White;
            this.styleComboBox.FormattingEnabled = true;
            this.styleComboBox.Items.AddRange(new object[] {
            "Auto"});
            this.styleComboBox.Location = new System.Drawing.Point(135, 137);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.Size = new System.Drawing.Size(121, 21);
            this.styleComboBox.TabIndex = 4;
            this.styleComboBox.SelectedIndexChanged += new System.EventHandler(this.styleComboBox_SelectedIndexChanged);
            // 
            // pathTextBox
            // 
            this.pathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pathTextBox.BackColor = System.Drawing.Color.DimGray;
            this.pathTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pathTextBox.ForeColor = System.Drawing.Color.White;
            this.pathTextBox.Location = new System.Drawing.Point(135, 108);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.Size = new System.Drawing.Size(334, 20);
            this.pathTextBox.TabIndex = 3;
            this.pathTextBox.Text = "Wallpaper path";
            this.pathTextBox.TextChanged += new System.EventHandler(this.pathTextBox_TextChanged);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.BackColor = System.Drawing.Color.DimGray;
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.ForeColor = System.Drawing.Color.White;
            this.nameTextBox.Location = new System.Drawing.Point(135, 82);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(334, 20);
            this.nameTextBox.TabIndex = 2;
            this.nameTextBox.Text = "Wallpaper name";
            this.nameTextBox.TextChanged += new System.EventHandler(this.nameTextBox_TextChanged);
            // 
            // styleLabel
            // 
            this.styleLabel.AutoSize = true;
            this.styleLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.styleLabel.Location = new System.Drawing.Point(39, 140);
            this.styleLabel.Name = "styleLabel";
            this.styleLabel.Size = new System.Drawing.Size(84, 13);
            this.styleLabel.TabIndex = 1;
            this.styleLabel.Text = "Wallpaper Style:";
            // 
            // pathLabel
            // 
            this.pathLabel.AutoSize = true;
            this.pathLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.pathLabel.Location = new System.Drawing.Point(39, 111);
            this.pathLabel.Name = "pathLabel";
            this.pathLabel.Size = new System.Drawing.Size(32, 13);
            this.pathLabel.TabIndex = 1;
            this.pathLabel.Text = "Path:";
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.nameLabel.Location = new System.Drawing.Point(39, 85);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(38, 13);
            this.nameLabel.TabIndex = 1;
            this.nameLabel.Text = "Name:";
            // 
            // positionLabel
            // 
            this.positionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.positionLabel.BackColor = System.Drawing.Color.Transparent;
            this.positionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.positionLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.positionLabel.Location = new System.Drawing.Point(5, 39);
            this.positionLabel.Name = "positionLabel";
            this.positionLabel.Size = new System.Drawing.Size(517, 17);
            this.positionLabel.TabIndex = 0;
            this.positionLabel.Text = "Title";
            this.positionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleLabel.BackColor = System.Drawing.Color.Transparent;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.titleLabel.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.titleLabel.Location = new System.Drawing.Point(3, 10);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(519, 29);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Title";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wallPositionScrollBar
            // 
            this.wallPositionScrollBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.wallPositionScrollBar.LargeChange = 1;
            this.wallPositionScrollBar.Location = new System.Drawing.Point(0, 622);
            this.wallPositionScrollBar.Maximum = 0;
            this.wallPositionScrollBar.Name = "wallPositionScrollBar";
            this.wallPositionScrollBar.Size = new System.Drawing.Size(1123, 56);
            this.wallPositionScrollBar.TabIndex = 1;
            this.wallPositionScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.wallPositionScrollBar_Scroll);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // wallpaperPictureBox
            // 
            this.wallpaperPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wallpaperPictureBox.Location = new System.Drawing.Point(0, 0);
            this.wallpaperPictureBox.Name = "wallpaperPictureBox";
            this.wallpaperPictureBox.Size = new System.Drawing.Size(1123, 678);
            this.wallpaperPictureBox.TabIndex = 4;
            this.wallpaperPictureBox.Wallpaper = null;
            // 
            // WallpaperDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1123, 678);
            this.Controls.Add(this.wallPositionScrollBar);
            this.Controls.Add(this.detailsPanel);
            this.Controls.Add(this.nextPictureBox);
            this.Controls.Add(this.prevPictureBox);
            this.Controls.Add(this.wallpaperPictureBox);
            this.IsMdiContainer = true;
            this.Name = "WallpaperDetailsForm";
            this.Text = "Wallpaper Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.WallpaperDetailsForm_FormClosing);
            this.Load += new System.EventHandler(this.WallpaperDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.prevPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nextPictureBox)).EndInit();
            this.detailsPanel.ResumeLayout(false);
            this.detailsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox prevPictureBox;
        private System.Windows.Forms.PictureBox nextPictureBox;
        private System.Windows.Forms.Panel detailsPanel;
        private System.Windows.Forms.Label positionLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.HScrollBar wallPositionScrollBar;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label pathLabel;
        private System.Windows.Forms.Label styleLabel;
        private System.Windows.Forms.Button applyAllButton;
        private System.Windows.Forms.ComboBox styleComboBox;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.TextBox nameTextBox;
        private WallpaperPictureBox wallpaperPictureBox;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}