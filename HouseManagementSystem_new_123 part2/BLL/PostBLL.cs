using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseManagementSystem.BLL
{
    class PostBLL
    {
        public int postid { get; set; }
        public byte[] frontimg { get; set; }
        public byte[] Img_living { get; set; }
        public byte[] Img_bed { get; set;}
        public byte[] Img_bath { get; set;}
        public byte[] Img_kitchen { get; set;}
        public byte[] other_img { get; set; }
        public DateTime dateOfPost { get; set; }
        public int hid { get; set; }
        public int uid { get; set; }

    }
}
