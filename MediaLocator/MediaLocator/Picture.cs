﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLocator
{
    public class Picture
    {
        public Picture()
        {

        }
        public int PictureID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
    
        public virtual Folder Folder { get; set; }       
    }
}
