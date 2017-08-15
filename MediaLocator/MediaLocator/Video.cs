using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLocator
{
    public class Video
    {
        public Video()
        {

        }
        public int VideoID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime? SavedAt { get; set; }
        public byte[] Photo { get; set; }
        public decimal Long { get; set; }
        public decimal Size { get; set; }

        public virtual Folder Folder { get; set; }
    }
}
