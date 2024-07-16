using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace introCF.EF.TableDesigns
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DeptHeadName { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public Department() 
        { 
            Courses = new HashSet<Course>();
        }

        // initializing to an empty hashcat, hashcat to ensures that there are no duplicate courses in the collection
    }
}