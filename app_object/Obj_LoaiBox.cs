using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SafeControl.app_object
{
    public class Obj_LoaiBox
    {
        public int width { get; set; }
        public int height { get; set; }
        public int depth { get; set; }
        public Obj_LoaiBox() { }
        public Obj_LoaiBox (int w, int h, int d)
        {
            width = w;
            height = h;
            depth = d;
        }

    }
}
