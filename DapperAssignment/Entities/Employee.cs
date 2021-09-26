
namespace EfAssignmentDapper.Entities
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ImagePath { get; set; }
        public string ViewType { get; set; }
        public int DeptId { get; set; }
        public Department Department { get; set; }  // navigation property
    }
}