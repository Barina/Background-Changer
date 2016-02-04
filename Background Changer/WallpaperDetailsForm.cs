using Background_Changer.WallUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Background_Changer
{
    public partial class WallpaperDetailsForm : Form
    {
        public WallpaperDetailsForm()
        {
            InitializeComponent();
        }

        private Wallpaper[] walls;
        private Wallpaper[] originalWalls;
        public Wallpaper[] Result
        {
            get
            {
                if (DialogResult == DialogResult.OK)
                    return originalWalls;
                return null;
            }
        }
        private Wallpaper previousWall
        {
            get
            {
                if (wallPositionScrollBar.Value < 1)
                    return null;
                return walls?[wallPositionScrollBar.Value - 1];
            }
        }
        private Wallpaper currentWall
        {
            get
            {
                if (wallPositionScrollBar.Value < 0 || wallPositionScrollBar.Value >= walls.Length)
                    return null;
                return walls?[wallPositionScrollBar.Value];
            }
        }
        private Wallpaper nextWall
        {
            get
            {
                if (wallPositionScrollBar.Value + 1 >= walls.Length)
                    return null;
                return walls?[wallPositionScrollBar.Value + 1];
            }
        }

        private Wallpaper previousOriginalWall
        {
            get
            {
                if (wallPositionScrollBar.Value < 1)
                    return null;
                return originalWalls?[wallPositionScrollBar.Value - 1];
            }
        }
        private Wallpaper currentOriginalWall
        {
            get
            {
                if (wallPositionScrollBar.Value < 0 || wallPositionScrollBar.Value >= originalWalls.Length)
                    return null;
                return originalWalls?[wallPositionScrollBar.Value];
            }
        }
        private Wallpaper nextOriginalWall
        {
            get
            {
                if (wallPositionScrollBar.Value + 1 >= walls.Length)
                    return null;
                return originalWalls?[wallPositionScrollBar.Value + 1];
            }
        }

        public WallpaperDetailsForm(params Wallpaper[] walls) : this()
        {
            this.originalWalls = walls;
            if (walls.Length < 1)
                Close();

            this.walls = new Wallpaper[originalWalls.Length];
            for (int i = 0; i < originalWalls.Length; i++)
                this.walls[i] = originalWalls[i].copy();

            wallPositionScrollBar.Maximum = walls.Length - 1;
            wallPositionScrollBar.Visible = walls.Length > 1;
            applyAllButton.Visible = walls.Length > 1;

            Array array = Enum.GetValues(typeof(WallHelper.WallpaperStyle));
            foreach (var item in array)
                styleComboBox.Items.Add(item);

            updateComponent();
        }

        private void updateComponent()
        {
            prevPictureBox.Visible = wallPositionScrollBar.Value != 0;
            nextPictureBox.Visible = wallPositionScrollBar.Value != wallPositionScrollBar.Maximum;
            if (!string.IsNullOrEmpty(previousWall?.Path) && previousWall.Path != prevPictureBox.ImageLocation)
                prevPictureBox.ImageLocation = previousWall.Path;
            wallpaperPictureBox.Visible = !string.IsNullOrEmpty(currentWall?.Path) && (currentWall?.PathExist ?? false);
            wallpaperPictureBox.Wallpaper = currentWall;
            //nextPictureBox.Visible = !string.IsNullOrEmpty(nextWall?.Path);
            if (!string.IsNullOrEmpty(nextWall?.Path) && nextWall.Path != nextPictureBox.ImageLocation)
                nextPictureBox.ImageLocation = nextWall.Path;

            titleLabel.Text = currentWall?.Name ?? "None";
            positionLabel.Text = string.Format("({0}/{1})", wallPositionScrollBar.Value + 1, this.walls.Length);
            nameTextBox.Text = currentWall?.Name ?? "None";
            pathTextBox.Text = currentWall?.Path ?? "None";
            if (currentWall != null)
                pathTextBox.BackColor = currentWall.PathExist ? nameTextBox.BackColor : Color.DarkRed;

            if (currentWall?.WallpaperStyle != null)
                styleComboBox.SelectedItem = (WallHelper.WallpaperStyle)currentWall.WallpaperStyle;
            else
                styleComboBox.SelectedIndex = 0;
        }

        private bool valuesChanged()
        {
            for (int i = 0; i < walls.Length; i++)
                if (!walls[i].SameAs(originalWalls[i]))
                    return true;
            return false;
        }

        /// <summary>
        /// Indicates if there's wrong values in the list and return the index of the first Wallpaper.
        /// </summary>
        /// <returns>The index of the first Wallpaper with the wrong values, or -1 if everything is ok.</returns>
        private int hasWrongValues()
        {
            for (int i = 0; i < walls.Length; i++)
                if (!walls[i].PathExist)
                    return i;
            return -1;
        }

        private bool saveChanges()
        {
            int wrongValueIndex = hasWrongValues();
            if (wrongValueIndex > 0)
            {
                DialogResult result = MessageBox.Show("Some values are incorrect. Pleaes Fix.", "Please Confirm");
                wallPositionScrollBar.Value = wrongValueIndex;
                updateComponent();
            }
            else
            {
                for (int i = 0; i < walls.Length; i++)
                    if (!walls[i].SameAs(originalWalls[i]))
                        originalWalls[i] = walls[i].copy();
                return true;
            }
            return false;
        }

        private void revertChanges()
        {
            for (int i = 0; i < walls.Length; i++)
                if (!walls[i].SameAs(originalWalls[i]))
                    walls[i] = originalWalls[i].copy();
            updateComponent();
        }

        private void nextPictureBox_Click(object sender, EventArgs e)
        {
            ++wallPositionScrollBar.Value;
            updateComponent();
        }

        private void prevPictureBox_Click(object sender, EventArgs e)
        {
            --wallPositionScrollBar.Value;
            updateComponent();
        }

        private void wallPositionScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            updateComponent();
        }

        private void styleComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (styleComboBox.SelectedIndex == 0)
                currentWall.WallpaperStyle = null;
            else
                currentWall.WallpaperStyle = (WallHelper.WallpaperStyle)styleComboBox.SelectedItem;
            updateComponent();
        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            currentWall.Name = nameTextBox.Text;
            updateComponent();
        }

        private void pathTextBox_TextChanged(object sender, EventArgs e)
        {
            currentWall.Path = pathTextBox.Text;
            if (!currentWall.PathExist)
                errorProvider.SetError(pathTextBox, "Path does not exist.");
            else
                errorProvider.Clear();
            updateComponent();
        }

        private void WallpaperDetailsForm_Load(object sender, EventArgs e)
        {
            this.Size = Properties.Settings.Default.DetailsSize;
            this.Location = Properties.Settings.Default.DetailsLocation;
            this.WindowState = Properties.Settings.Default.DetailsState;
        }

        private void WallpaperDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (valuesChanged())
            {
                DialogResult result = MessageBox.Show("Save changes?", "Please Confirm", MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.OK:
                    case DialogResult.Yes:
                        if (!saveChanges())
                        {
                            e.Cancel = true;
                            return;
                        }
                        DialogResult = DialogResult.OK;
                        break;
                    case DialogResult.Cancel:
                        DialogResult = DialogResult.Cancel;
                        e.Cancel = true;
                        break;
                    default:
                        DialogResult = DialogResult.Cancel;
                        break;
                }
            }
            if (!e.Cancel)
            {
                Properties.Settings.Default.DetailsState = this.WindowState;
                if (this.WindowState == FormWindowState.Normal)
                {
                    Properties.Settings.Default.DetailsSize = this.Size;
                    Properties.Settings.Default.DetailsLocation = this.Location;
                }
                else
                {
                    Properties.Settings.Default.DetailsSize = this.RestoreBounds.Size;
                    Properties.Settings.Default.DetailsLocation = this.RestoreBounds.Location;
                }
                Properties.Settings.Default.Save();
            }
        }

        private void apllyAllButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure to apply current style to all wallpapers?", "Please Confirm", MessageBoxButtons.OKCancel) != DialogResult.OK)
                return;

            WallHelper.WallpaperStyle? style = null;
            if (styleComboBox.SelectedIndex > 0)
                style = (WallHelper.WallpaperStyle)styleComboBox.SelectedItem;

            foreach (var wall in this.walls)
                wall.WallpaperStyle = style;
        }
    }
}
