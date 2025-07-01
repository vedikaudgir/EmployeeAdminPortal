using EmployeeAdminPortal.Data;
using EmployeeAdminPortal.Models;
using EmployeeAdminPortal.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ApplicationDBContext dbContext;

        public EmployeeController(ApplicationDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllEmployees()
        {
            return Ok(dbContext.Employee.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetEmployeByID(Guid id)
        {
            var employee = dbContext.Employee.Find(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto) 
        { 
        var employeeEntity = new Employee()
        {
            Name = addEmployeeDto.Name,
            Email = addEmployeeDto.Email,
            PhoneNumber = addEmployeeDto.PhoneNumber,
            Salary = addEmployeeDto.Salary

        };
            dbContext.Employee.Add(employeeEntity);
            dbContext.SaveChanges();

            return Ok(employeeEntity);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, updateEmployeeDto updateEmployeeDto)
        {
            var employeeEntity = dbContext.Employee.Find(id);
            if (employeeEntity == null)
            {
                return NotFound();
            }
            employeeEntity.Name = updateEmployeeDto.Name;
            employeeEntity.Email = updateEmployeeDto.Email;
            employeeEntity.PhoneNumber = updateEmployeeDto.PhoneNumber;
            employeeEntity.Salary = updateEmployeeDto.Salary;

            dbContext.SaveChanges();
            return Ok(employeeEntity);
        }

        [HttpDelete]
        [Route("{id:guid}")]

        public IActionResult DeleteEmployee(Guid id) 
        {
            var employeeEntity = dbContext.Employee.Find(id);
            if (employeeEntity == null)
            {
                return NotFound();
            }
            dbContext.Employee.Remove(employeeEntity);
            dbContext.SaveChanges();
            return Ok(employeeEntity);
        }

    }
}
