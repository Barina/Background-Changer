using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Microsoft.Win32.TaskScheduler;
using System.Collections.Specialized;
using static Newtonsoft.Json.JsonConvert;
using System.Windows.Forms;
using Background_Changer.WallUtils;
using System.Drawing;
using System.Drawing.Imaging;

namespace Background_Changer
{
    public class WallHelper
    {
        public enum WallpaperStyle
        {
            Tile,
            Center,
            Stretch,
            Fit,
            Fill
        }

        #region Singleton declaration
        private static WallHelper instance;
        public static WallHelper Instance
        {
            get
            {
                if (instance == null)
                    instance = new WallHelper();
                return instance;
            }
        }

        private WallHelper()
        {
            queue.WallpapersCleared += Queue_WallpapersCleared;
        }
        #endregion

        private WallpaperQueue queue { get { return WallpaperQueue.Instance; } }

        private const int SPI_SETDESKWALLPAPER = 20;
        private const int SPIF_UPDATEINIFILE = 0x01;
        private const int SPIF_SENDWININICHANGE = 0x02;
        private const string TASK_NAME = "BackgroundChangerTask";
        public readonly string[] ALLOWED_EXTENSIONS = new string[] { ".BMP", ".PNG", ".JPG", ".JPEG" };

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        public bool extAllowed(string ext)
        {
            if (string.IsNullOrEmpty(ext))
                return false;
            ext.ToUpper();
            return ALLOWED_EXTENSIONS.Contains(ext);
        }

        public WallpaperStyle CurrentStyle
        {
            get { return (WallpaperStyle)Properties.Settings.Default.WallpaperStyle; }
            set
            {
                Properties.Settings.Default.WallpaperStyle = (int)value;
                Properties.Settings.Default.Save();
            }
        }

        public void SetWallpaper(Wallpaper wall)
        {
            if (wall == null || !wall.PathExist)
                return;
            WallpaperStyle? style = CurrentStyle;
            if (wall?.WallpaperStyle != null)
                style = wall.WallpaperStyle;

            Uri uri = new Uri(wall.Path);
            Stream s = new System.Net.WebClient().OpenRead(uri.ToString());

            System.Drawing.Image img = System.Drawing.Image.FromStream(s);
            string tempPath = Path.Combine(Path.GetTempPath(), "wallpaper.bmp");
            img.Save(tempPath, System.Drawing.Imaging.ImageFormat.Bmp);

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);

            switch (style)
            {
                case WallpaperStyle.Tile:
                    key.SetValue(@"WallpaperStyle", 0.ToString());
                    key.SetValue(@"TileWallpaper", 1.ToString());
                    break;
                case WallpaperStyle.Stretch:
                    key.SetValue(@"WallpaperStyle", 2.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                    break;
                case WallpaperStyle.Center:
                    key.SetValue(@"WallpaperStyle", 0.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                    break;
                case WallpaperStyle.Fit: // (Windows 7 and later)
                    key.SetValue(@"WallpaperStyle", 6.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                    break;
                case WallpaperStyle.Fill: // (Windows 7 and later)
                    key.SetValue(@"WallpaperStyle", 10.ToString());
                    key.SetValue(@"TileWallpaper", 0.ToString());
                    break;
            }

            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, tempPath, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
        }

        public void SetNewSchedule(TimeSpan interval)
        {
            // Get the service on the local machine
            using (TaskService ts = new TaskService())
            {
                // Create a new task definition and assign properties
                TaskDefinition td = ts.NewTask();
                td.RegistrationInfo.Description = "Change the Desktop Wallpaper";

                // Create a trigger that will fire the task
                DailyTrigger trigger = new DailyTrigger();
                trigger.Repetition.Interval = interval;
                td.Triggers.Add(trigger);

                // Create an action that will launch Notepad whenever the trigger fires
                td.Actions.Add(new ExecAction(System.Reflection.Assembly.GetExecutingAssembly().Location, "c", null));

                // Register the task in the root folder
                try
                {
                    ts.RootFolder.RegisterTaskDefinition(TASK_NAME, td);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show("Can't register the task. Be sure to run this app as admin." + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        public void ClearSchedule()
        {
            // Get the service on the local machine
            using (TaskService ts = new TaskService())
            {
                Microsoft.Win32.TaskScheduler.Task task = ts.FindTask(TASK_NAME, true);
                if (task != null)
                {
                    task.Stop();
                    // Remove the task
                    try
                    {
                        ts.RootFolder.DeleteTask(TASK_NAME);
                    }
                    catch (UnauthorizedAccessException ex)
                    {
                        MessageBox.Show("There was an error deleting task. Be sure to run this app as admin." + Environment.NewLine + ex.Message, "Error", MessageBoxButtons.OK);
                    }
                }
            }
        }

        private void Queue_WallpapersCleared(object sender, EventArgs e)
        {
            ClearSchedule();
        }

        public Microsoft.Win32.TaskScheduler.Task GetCurrentTask()
        {
            using (TaskService ts = new TaskService())
            {
                return ts.FindTask(TASK_NAME, true);
            }
        }

        public void SetNextWallpaper()
        {
            SetWallpaper(queue.NextWallpaper);
            queue.advance(queue.NextWallpaper);
            queue.commitChanges();
        }

        public static Image resizeImage(Image image, int Width, int Height)
        {
            int sourceWidth = image.Width;
            int sourceHeight = image.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Width / (float)sourceWidth);
            nPercentH = ((float)Height / (float)sourceHeight);
            if (nPercentH > nPercentW)
            {
                nPercent = nPercentH;
                destX = Convert.ToInt16(Math.Ceiling((Width - (sourceWidth * nPercent)) / 2));
            }
            else
            {
                nPercent = nPercentW;
                destY = Convert.ToInt16(Math.Ceiling((Height - (sourceHeight * nPercent)) / 2));
            }

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            //grPhoto.Clear(Color.Red);
            grPhoto.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;

            grPhoto.DrawImage(image,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }
    }
}