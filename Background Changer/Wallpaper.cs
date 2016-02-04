using Newtonsoft.Json;
using System.IO;

namespace Background_Changer.WallUtils
{
    public class Wallpaper
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public WallHelper.WallpaperStyle? WallpaperStyle { get; set; }
        public bool PathExist { get { return File.Exists(Path); } }

        [JsonConstructor]
        internal Wallpaper(int id, string name, string path, WallHelper.WallpaperStyle? wallpaperStyle)
        {
            this.ID = path.GetHashCode();
            this.Name = name;
            this.Path = path;
            this.WallpaperStyle = wallpaperStyle;
        }

        public Wallpaper(string name, string path, WallHelper.WallpaperStyle? wallpaperStyle) : this(path.GetHashCode(), name, path, wallpaperStyle)
        { }

        public Wallpaper(string name, string path) : this(name, path, null)
        { }

        public Wallpaper(string path) : this(System.IO.Path.GetFileNameWithoutExtension(path), path)
        { }

        public override bool Equals(object obj)
        {
            Wallpaper other = obj as Wallpaper;
            return Path == other.Path;
        }

        public bool SameAs(Wallpaper other)
        {
            if (other.ID == ID)
                if (other.Name == Name)
                    if (other.WallpaperStyle == WallpaperStyle)
                        return other.Path == Path;
            return false;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public Wallpaper copy()
        {
            return new Wallpaper(ID, Name, Path, WallpaperStyle);
        }
    }
}