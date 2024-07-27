using EmployeeManagerAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagerAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagerDbContext _context;

        public EmployeeRepository(EmployeeManagerDbContext context)
        {
            _context = context;
        }

        public int GetTotalEmployees()
        {
            try
            {
                return _context.Employees.Count();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return _context.Employees.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetEmployeesEngagedForClientCount()
        {
            try
            {
                return _context.Employees.Count(e => e.EngagedForClient);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Employee> GetEmployeesEngagedForClient()
        {
            try
            {
                return _context.Employees.Where(e => e.EngagedForClient).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int GetEmployeesOnBenchCount()
        {
            try
            {
                return _context.Employees.Count(e => e.OnBench);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Employee> GetEmployeesOnBench()
        {
            try
            {
                return _context.Employees.Where(e => e.OnBench).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public int GetEmployeesOnPIPCount()
        {
            try
            {
                return _context.Employees.Count(e => e.OnPip);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Employee> GetEmployeesOnPIP()
        {
            try
            {
                return _context.Employees.Where(e => e.OnPip).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Employee> GetEmployeesMatchingSkillSet(List<string> skills)
        {
            try
            {
                if (skills == null || skills.Count == 0)
                {
                    return new List<Employee>();
                }
                // Prepare SQL query
                var sqlQuery = "SELECT * FROM Employee WHERE ";

                // Add conditions for each skill
                var skillConditions = skills.Select((skill, index) => $"Skillset LIKE @p{index}").ToList();
                sqlQuery += string.Join(" and ", skillConditions);

                // Prepare SQL parameters
                var sqlParameters = skills.Select((skill, index) => new Microsoft.Data.SqlClient.SqlParameter($"p{index}", $"%{skill.Trim()}%")).ToArray();

                // Execute SQL query
                var employees = _context.Employees.FromSqlRaw(sqlQuery, sqlParameters).ToList();

                return employees;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Employee> GetEmployeesNeedToUpgradeSkillSet(string skill)
        {
            try
            {
                return _context.Employees.Where(e => !e.SkillSet.Contains(skill)).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<Employee> GetCertifiedEmployees()
        {
            try
            {
                return _context.Employees.Where(e=>e.Certification != "").ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void UpdateEmployee(int id, Employee employee)
        {
            try
            {
                var existingEmployee = _context.Employees.Find(id);
                if (existingEmployee == null)
                {
                    throw new Exception("Employee not found");
                }

                existingEmployee.Name = employee.Name;
                existingEmployee.Department = employee.Department;
                existingEmployee.SubDepartment = employee.SubDepartment;
                existingEmployee.Manager = employee.Manager;
                existingEmployee.ProjectName = employee.ProjectName;
                existingEmployee.EngagedForClient = employee.EngagedForClient;
                existingEmployee.OnBench = employee.OnBench;
                existingEmployee.OnPip = employee.OnPip;
                existingEmployee.IsBillable = employee.IsBillable;
                existingEmployee.SkillSet = employee.SkillSet;
                existingEmployee.Certification = employee.Certification;
                existingEmployee.Experience = employee.Experience;
                existingEmployee.ModifiedOn = DateTime.Now;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
