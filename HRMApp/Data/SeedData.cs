using HRMApp.Models;

namespace HRMApp.Data
{
    public class SeedData
    {
        public IEnumerable<Branch> GetBranchList()
        {
            return new List<Branch>
            {
                new Branch { Name = "Autumn", Description = "TBD", },
                new Branch { Name = "Spring", Description = "TBD", },
                new Branch { Name = "Winter", Description = "TBD", },
                new Branch { Name = "Test Branch", Description = "TBD", },
            };
        }
        public IEnumerable<Department> GetDepartmentList()
        {
            return new List<Department>
            {
                new Department { Name = "CSE", Description = "TBD", Address = "TBD" },
                new Department { Name = "EEE", Description = "TBD", Address = "TBD" },
                new Department { Name = "ECE", Description = "TBD", Address = "TBD" },
                new Department { Name = "Test Department", Description = "TBD", Address = "TBD" },
            };
        }
    }
}
