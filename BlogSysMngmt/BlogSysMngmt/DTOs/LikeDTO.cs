using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSysMngmt.DTOs
{
    public class LikeDTO
    {
        public int like_id { get; set; }
        public int user_id { get; set; }
        public int post_id { get; set; }
        public int flags { get; set; }
        public int count { get; set; }
    }
}