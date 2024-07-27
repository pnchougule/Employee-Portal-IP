using EmployeeManagerAPI.Models;

namespace EmployeeManagerMVC.Models
{
    public class EmployeeViewModel
    {
        public int TotalEmployees { get; set; }
        public List<Emp> AllEmployees { get; set; }
        public int EmployeesEngagedForClientTotal { get; set; }
        public List<Emp> EmployeesEngagedForClient { get; set; }
        public int EmployeesOnBenchTotal { get; set; }
        public List<Emp> EmployeesOnBench { get; set; }
        public int EmployeesOnPipTotal { get; set; }
        public List<Emp> EmployeesOnPip { get; set; }
        public List<Emp> CertifiedEmployees { get; set; }
        public string SkillSet { get; set; }
        public List<Emp> MatchingSkillset { get; set; }
        public List<Emp> UpgradeSkillset { get; set; }
    }

    public class Emp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SkillSet { get; set; }
        public string ProjectName { get; set; }
    }
}
