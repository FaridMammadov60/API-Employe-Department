using System;

namespace TaskInteview.Dtos
{
    public class EmployeeReturnDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string BirthDate { get; set; }
        public DateTime CreateDate { get; set; }
        public EmployeeDepartmentDto Department { get; set; }
    }
    public class EmployeeDepartmentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
