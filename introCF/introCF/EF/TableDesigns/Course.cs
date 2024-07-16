using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace introCF.EF.TableDesigns
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreditHr { get; set; }

        [ForeignKey("Dept")] // pointing through annotation
        public int DeptID { get; set; }
        public virtual Department Dept { get; set; } // navigation property for the foreign key
        // virtual -> to treat as nav. prop.
        // one course belongs to one department
    }
}