//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BlogSysMngmt.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class PostTag
    {
        public int post_tag_id { get; set; }
        public int post_id { get; set; }
        public int tag_id { get; set; }
        public string tag_name { get; set; }
    
        public virtual Post Post { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
