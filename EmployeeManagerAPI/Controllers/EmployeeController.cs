using Microsoft.AspNetCore.Mvc;
using EmployeeManagerAPI.Models;
using EmployeeManagerAPI.Repository;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IUnitOfWorkRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesController"/> class.
        /// </summary>
        /// <param name="repository">The IUnitOfWorkRepository value.</param>
        public EmployeesController(IUnitOfWorkRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Method to return total employee count.
        /// </summary>
        /// <returns>A count of total employees.</returns>
        [HttpGet("total")]
        public ActionResult<int> TotalEmployee()
        {
            try
            {
                var count = _repository.empRepo.GetTotalEmployees();
                return Ok(count);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Method to return list of employees.
        /// </summary>
        /// <returns>A list of all employees.</returns>
        [HttpGet("getallemployees")]
        public ActionResult<Employee> GetAllEmployees()
        {
            try
            {
                var employees = _repository.empRepo.GetAllEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Method to return count of employee engaged for client.
        /// </summary>
        /// <returns>The count of employee.</returns>
        [HttpGet("engagedforclient/total")]
        public ActionResult<int> EmployeeEngagedforClient()
        {
            try
            {
                var count = _repository.empRepo.GetEmployeesEngagedForClientCount();
                return Ok(count);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Method to return list of employees engagaed for client.
        /// </summary>
        /// <returns>A list of employees engaged for a client</returns>
        [HttpGet("engagedforclient")]
        public ActionResult<IEnumerable<Employee>> EmployeesEngagedforClient()
        {
            try
            {
                var employees = _repository.empRepo.GetEmployeesEngagedForClient();
                return Ok(employees);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Method to return count of employee on bench.
        /// </summary>
        /// <returns>A count of employee on bench.</returns>
        [HttpGet("onbench/total")]
        public ActionResult<int> EmployeeOnBench()
        {
            try
            {
                var count = _repository.empRepo.GetEmployeesOnBenchCount();
                return Ok(count);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Method to return list of employee on bench.
        /// </summary>
        /// <returns>A list of employee on bench.</returns>
        [HttpGet("onbench")]
        public ActionResult<IEnumerable<Employee>> EmployeesOnBench()
        {
            try
            {
                var employees = _repository.empRepo.GetEmployeesOnBench();
                return Ok(employees);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Method to return count of employees on pip.
        /// </summary>
        /// <returns>A count of employees on pip.</returns>
        [HttpGet("onpip/total")]
        public ActionResult<int> EmployeeOnPIP()
        {
            try
            {
                var count = _repository.empRepo.GetEmployeesOnPIPCount();
                return Ok(count);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Method to return list of employees on PIP.
        /// </summary>
        /// <returns>A list of employees on PIP.</returns>
        [HttpGet("onpip")]
        public ActionResult<IEnumerable<Employee>> EmployeesOnPIP()
        {
            try
            {
                var employees = _repository.empRepo.GetEmployeesOnPIP();
                return Ok(employees);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Method to return list of employees matching skillset.
        /// </summary>
        /// <param name="skills">The skills to compare.</param>
        /// <returns>A list of employees matching skillset.</returns>
        [HttpGet("matchingskillset/{skills}")]
        public ActionResult<IEnumerable<Employee>> EmployeesMatchingSkillSet(string skills)
        {
            try
            {
                if (string.IsNullOrEmpty(skills))
                {
                    return BadRequest("Skills parameter is required.");
                }

                var skillList = skills.Split(',').Select(s => s.Trim().ToLower()).ToList();
                var employees = _repository.empRepo.GetEmployeesMatchingSkillSet(skillList);

                return Ok(employees);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Method to return list of employees need to upgrade skillset.
        /// </summary>
        /// <param name="skill">The skills to compare.</param>
        /// <returns>A list of employees need to upgrade skillset.</returns>
        [HttpGet("upgradeskillset/{skill}")]
        public ActionResult<IEnumerable<Employee>> EmployeesNeedToUpgradeSkillSet(string skill)
        {
            try
            {
                var employees = _repository.empRepo.GetEmployeesNeedToUpgradeSkillSet(skill);
                return Ok(employees);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Method to return list of certified employees.
        /// </summary>
        /// <returns>A list of certified employees.</returns>
        [HttpGet("certified")]
        public ActionResult<IEnumerable<Employee>> CertifiedEmployees()
        {
            try
            {
                var employees = _repository.empRepo.GetCertifiedEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Method to add employee.
        /// </summary>
        /// <param name="employee">The employee object value.</param>
        [HttpPost("add")]
        public ActionResult AddEmployee([FromBody] Employee employee)
        {
            try
            {
                _repository.empRepo.AddEmployee(employee);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// Method to updat existing employee.
        /// </summary>
        /// <param name="id">The ID of the employee to update.</param>
        /// <param name="employee">The updated employee data.</param>
        /// <exception cref="Exception">Thrown when there is an error updating the employee.</exception>
        [HttpPut("update/{id}")]
        public ActionResult UpdateEmployee(int id, [FromBody] Employee employee)
        {
            try
            {
                _repository.empRepo.UpdateEmployee(id, employee);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
