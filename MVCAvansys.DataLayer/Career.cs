using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCAvansys.DataLayer
{
    [Table("Career")]
    public class Career
    {
        public Guid ID { get; set; }
        public string Name { get; set; } 
    }   
}
