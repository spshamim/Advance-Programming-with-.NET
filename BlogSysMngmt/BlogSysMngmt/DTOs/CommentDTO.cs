using BlogSysMngmt.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogSysMngmt.DTOs
{
    public class CommentDTO
    {
        public int comment_id { get; set; }
        public int user_id { get; set; }
        public int post_id { get; set; }
        public string c_content { get; set; }
        public System.DateTime c_post_date { get; set; }
        public virtual User User { get; set; }
    }
}