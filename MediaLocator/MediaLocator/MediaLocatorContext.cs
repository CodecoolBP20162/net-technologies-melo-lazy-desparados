using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MediaLocator
{
    public class MedialocatorContext : DbContext
    {
        public MedialocatorContext() : base()
        {

        }

        public DbSet<Audio> Audios { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
        public DbSet<Folder> Folders { get; set; }

    }
}
