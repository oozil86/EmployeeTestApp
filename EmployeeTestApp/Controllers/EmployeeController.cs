using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTestApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("Test")]
    public class EmployeeController : ControllerBase
    {
        private static readonly List<Employee> Employees = new List<Employee>
       {
            new Employee { Id = 1,Age=25,Name="Hossam Saoud AbdulFattah",Salary=1000},
                     new Employee { Id = 2,Age=26,Name="Mohamed Ali",Salary=2000},
                      new Employee { Id = 3,Age=26,Name="Mohamed Ali",Salary=2000},
        };
        public EmployeeController()
        {
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(Employees.ToList());
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            int id = Employees.Max(x => x.Id);
            employee.Id = id+1;
            Employees.Add(employee);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateEmployee(Employee employee)
        {
            var Emp = Employees.Where(x => x.Id == employee.Id).FirstOrDefault();

            if (Emp != null) {
                Employees[Emp.Id - 1].Salary = employee.Id;
                Employees[Emp.Id - 1].Name = employee.Name;
                Employees[Emp.Id - 1].Salary = employee.Salary;
                Employees[Emp.Id - 1].Age = employee.Age;
            }

            return Ok();
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int Id)
        {
            var emp = Employees.Where(c=>c.Id.Equals(Id)).FirstOrDefault();
            Employees.Remove(emp);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetEmployee(int Id)
        {
            return Ok(Employees.Where(c => c.Id == Id));
        }

    }
}
