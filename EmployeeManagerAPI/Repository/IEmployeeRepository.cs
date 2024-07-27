using EmployeeManagerAPI.Models;
using System.Collections.Generic;

namespace EmployeeManagerAPI.Repository
{
    public interface IEmployeeRepository
    {
        int GetTotalEmployees();
        IEnumerable<Employee> GetAllEmployees();
        int GetEmployeesEngagedForClientCount();
        IEnumerable<Employee> GetEmployeesEngagedForClient();
        int GetEmployeesOnBenchCount();
        IEnumerable<Employee> GetEmployeesOnBench();
        int GetEmployeesOnPIPCount();
        IEnumerable<Employee> GetEmployeesOnPIP();
        IEnumerable<Employee> GetEmployeesMatchingSkillSet(List<string> skillSet);
        IEnumerable<Employee> GetEmployeesNeedToUpgradeSkillSet(string skill);
        IEnumerable<Employee> GetCertifiedEmployees();
        void AddEmployee(Employee employee);
        void UpdateEmployee(int id, Employee employee);
    }
}
