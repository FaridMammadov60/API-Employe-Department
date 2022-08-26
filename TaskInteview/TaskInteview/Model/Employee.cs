using System;

namespace TaskInteview.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public DateTime CreateDate { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
