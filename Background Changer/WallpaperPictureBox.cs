using Background_Changer.WallUtils;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Background_Changer
{
    public partial class WallpaperPictureBox : UserControl
    {
        private Image wallImage;
        private Wallpaper wallpaper;
        public Wallpaper Wallpaper
        {
            get { return this.wallpaper; }
            set
            {
                Wallpaper oldWall = this.wallpaper;
                this.wallpaper = value;

                if (this.wallpaper == oldWall)
                {
                    if (this.wallpaper?.Path != (string)wallImage?.Tag)
                        refreshWallpaper();
                }
                else
                    refreshWallpaper();
            }
        }

        private void refreshWallpaper()
        {
            if (wallImage != null)
            {
                wallImage.Dispose();
                wallImage = null;
            }
            if (!string.IsNullOrEmpty(this.wallpaper?.Path) && this.wallpaper.PathExist)
            {
                wallImage = Image.FromFile(this.wallpaper.Path);
                wallImage.Tag = this.Wallpaper.Path;
                Invalidate();
            }
        }

        public WallpaperPictureBox()
        {
            InitializeComponent();
        }

        private void WallpaperPictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (wallImage == null)
                return;
            Graphics g = e.Graphics;
            try
            {
                Rectangle src = new Rectangle(0, 0, wallImage.Width, wallImage.Height);
                Rectangle dst = new Rectangle();
                switch (Wallpaper?.WallpaperStyle ?? WallHelper.Instance.CurrentStyle)
                {
                    case WallHelper.WallpaperStyle.Center:
                        dst.X = (this.Width - wallImage.Size.Width) / 2;
                        dst.Y = (this.Height - wallImage.Size.Height) / 2;
                        dst.Size = src.Size;
                        break;
                    case WallHelper.WallpaperStyle.Fill:
                        dst = resizeRectangle(src, true);
                        break;
                    case WallHelper.WallpaperStyle.Fit:
                        dst = resizeRectangle(src, false);
                        break;
                    case WallHelper.WallpaperStyle.Stretch:
                        dst.X = 0;
                        dst.Y = 0;
                        dst.Size = Size;
                        break;
                    case WallHelper.WallpaperStyle.Tile:
                        TextureBrush tBrush = new TextureBrush(wallImage);
                        e.Graphics.FillRectangle(tBrush, new Rectangle(0, 0, Width, Height));
                        break;
                }
                if ((Wallpaper?.WallpaperStyle ?? WallHelper.Instance.CurrentStyle) != WallHelper.WallpaperStyle.Tile)
                    g.DrawImage(wallImage, dst, src, GraphicsUnit.Pixel);
            }
            catch (ArgumentException) { }
        }

        public Rectangle resizeRectangle(Rectangle src, bool fill)
        {
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)src.Width);
            nPercentH = ((float)Height / (float)src.Height);

            if (fill ? nPercentH > nPercentW : nPercentH < nPercentW)
            {
                nPercent = nPercentH;
                destX = Convert.ToInt16(Math.Ceiling((Width - (src.Width * nPercent)) / 2));
            }
            else
            {
                nPercent = nPercentW;
                destY = Convert.ToInt16(Math.Ceiling((Height - (src.Height * nPercent)) / 2));

            }

            int destWidth = (int)(src.Width * nPercent);
            int destHeight = (int)(src.Height * nPercent);

            return new Rectangle(destX, destY, destWidth, destHeight);
        }

        private void WallpaperPictureBox_Resize(object sender, System.EventArgs e)
        {
            Invalidate();
        }
    }
}