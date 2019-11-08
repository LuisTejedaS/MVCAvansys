using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCAvansysWebApp.Models

{
    public class StudentModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public string CareerID   { get; set; }
        public string CareerName   { get; set; }
    }
}
