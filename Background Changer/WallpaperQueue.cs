using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Newtonsoft.Json.JsonConvert;

namespace Background_Changer.WallUtils
{
    class WallpaperQueue
    {
        public enum QueueMode
        {
            Name,
            Added,
            Shuffle,
            Random
        }

        #region Singleton declaration;
        private static readonly FileInfo dataFile = new FileInfo(Path.GetDirectoryName(Application.ExecutablePath) + "\\wallqueue.json");
        private static readonly Random random = new Random();
        private static WallpaperQueue instance;
        public static WallpaperQueue Instance
        {
            get
            {
                if (instance == null)
                {
                    if (dataFile.Exists)
                    {
                        try
                        {
                            using (StreamReader stream = new StreamReader(dataFile.OpenRead()))
                            {
                                instance = DeserializeObject<WallpaperQueue>(stream.ReadToEnd());
                                stream.Close();
                            }
                        }
                        catch (IOException) { MessageBox.Show("Wallpapers file exists but still there was a problem parsing it."); }
                    }
                    if (instance == null)
                        instance = new WallpaperQueue();
                }
                return instance;
            }
        }

        private WallpaperQueue()
        {
            wallpapersCleared = new EventHandler(onWallpapersCleared);
        }
        #endregion

        public int currentQueueIndex { get; set; }
        public int nextQueueIndex { get; set; }

        private Wallpaper current;
        public Wallpaper CurrentWallpaper
        {
            get
            {
                if (current == null)
                    current = getWallpaperById(currentQueueIndex);
                return current;
            }
            set { this.current = value; }
        }

        public Wallpaper NextWallpaper { get; set; }

        public QueueMode QueueOrder { get; set; }

        private List<int> queue;
        public List<int> Queue
        {
            get
            {
                if (queue == null)
                    queue = new List<int>();
                return queue;
            }
            private set { queue = value; }
        }
        private List<Wallpaper> walls;
        public List<Wallpaper> Wallpapers
        {
            get
            {
                if (walls == null) walls = new List<Wallpaper>();
                return walls;
            }
            private set { walls = value; }
        }

        private event EventHandler wallpapersCleared;
        public event EventHandler WallpapersCleared
        {
            add { this.wallpapersCleared += value; }
            remove { this.wallpapersCleared -= value; }
        }

        private void onWallpapersCleared(object sender, EventArgs e) { }

        public void addWallpapers(List<Wallpaper> wallpapers)
        {
            addWallpapers(wallpapers.ToArray());
        }

        public void addWallpapers(params Wallpaper[] wallpapers)
        {
            int sizeBefore = this.Wallpapers.Count;
            foreach (var wall in wallpapers)
            {
                if (this.Wallpapers.Contains(wall))
                    continue;
                this.Wallpapers.Add(wall);
                this.queue.Add(wall.ID);
            }
            if (sizeBefore <= 1)
                advance(CurrentWallpaper);
        }

        public void changeWallpapers(params Wallpaper[] wallpapers)
        {
            var shortWall = (from wall in wallpapers
                             join thisWall in this.Wallpapers
                             on wall.ID equals thisWall.ID
                             select thisWall).ToList();

            foreach (var wall in wallpapers)
            {
                Wallpaper orig = shortWall.Find(o => o.ID == wall.ID);
                orig.Name = wall.Name;
                orig.Path = wall.Path;
                orig.WallpaperStyle = wall.WallpaperStyle;
                if (orig.Equals(CurrentWallpaper))
                    WallHelper.Instance.SetWallpaper(orig);
            }
        }

        public void removeWallpaper(Wallpaper wallpaper)
        {
            Wallpapers.Remove(wallpaper);
            queue.Remove(wallpaper.ID);
            if (NextWallpaper != null && NextWallpaper.Equals(wallpaper))
            {
                NextWallpaper = null;
                advance(CurrentWallpaper);
            }
            if (Wallpapers.Count <= 0)
                wallpapersCleared(this, new EventArgs());
        }

        public Wallpaper getWallpaperById(int id)
        {
            Wallpaper wall = Wallpapers.Find(o => o.ID == id);
            return wall;
        }

        /// <summary>
        /// Will save the wallpaper list to a specific file.
        /// </summary>
        public void commitChanges()
        {
            using (StreamWriter stream = new StreamWriter(dataFile.Open(FileMode.Create)))
            {
                stream.Write(SerializeObject(this, Newtonsoft.Json.Formatting.Indented));
                stream.Close();
            }
        }

        public void reorderQueue()
        {
            switch (QueueOrder)
            {
                case QueueMode.Name:
                    var list = Wallpapers.OrderBy(o => o.Name);
                    queue = new List<int>();
                    foreach (var item in list)
                        queue.Add(item.ID);
                    break;
                default:
                case QueueMode.Added:
                    queue = new List<int>();
                    foreach (var item in Wallpapers)
                        queue.Add(item.ID);
                    break;
                case QueueMode.Shuffle:
                    queue = new List<int>();
                    var sorted = Wallpapers.ToList();
                    for (int count = sorted.Count - 1; count > 0; count--)
                    {
                        int k = random.Next(count + 1);
                        Wallpaper wall = sorted[k];
                        sorted[k] = sorted[count];
                        sorted[count] = wall;
                    }
                    foreach (var item in sorted)
                        queue.Add(item.ID);
                    break;
            }
            advance(CurrentWallpaper);
        }

        public void advance(Wallpaper current)
        {
            CurrentWallpaper = current;
            currentQueueIndex = Queue.IndexOf(current.ID);

            nextQueueIndex = currentQueueIndex + 1;
            if (nextQueueIndex >= Queue.Count)
                nextQueueIndex = 0;

            if (Queue.Count < 1)
                NextWallpaper = CurrentWallpaper;
            else
                if (QueueOrder == QueueMode.Random)
                NextWallpaper = Wallpapers[random.Next(Wallpapers.Count - 1)];
            else
                NextWallpaper = getWallpaperById(Queue[nextQueueIndex]);
        }
    }
}