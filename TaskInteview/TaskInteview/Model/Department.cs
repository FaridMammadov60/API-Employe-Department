using System;
using System.Collections.Generic;

namespace TaskInteview.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employee { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
