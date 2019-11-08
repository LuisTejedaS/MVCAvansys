using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCAvansys.DataLayer
{
    [Table("Student")]
    public class Student
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public Guid CareerID { get; set; }
        public virtual Career Career { get; set; }
    }
}
