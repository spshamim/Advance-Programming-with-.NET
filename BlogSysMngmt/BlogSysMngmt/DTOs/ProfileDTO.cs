using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BlogSysMngmt.DTOs
{
    public class ProfileDTO
    {
        public int profile_id { get; set; }
        public int user_id { get; set; }
        public string fullname { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public string education { get; set; }
        public string gender { get; set; }
        public string hobbies { get; set; }
        public string social_link { get; set; }
        public string img_name { get; set; }
    }
}