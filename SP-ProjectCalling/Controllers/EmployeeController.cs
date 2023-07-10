using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SP_ProjectCalling.Interfaces;
using SP_ProjectCalling.Models.Domain;

namespace SP_ProjectCalling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employee;

        public EmployeeController(IEmployee employee)
        {
            this.employee = employee;
        }


        [HttpGet]
        [Route("GetEmployees")]
        public ActionResult<List<Employee>> GetEmployees()
        {
            var data = employee.GetAllEmployees();

            if (data == null)
            {
                return NotFound();
            }

            return data;

        }
        [HttpGet]
        [Route("GetSupervise")]
        public ActionResult<List<Supervisor>> GetSupervise()
        {
            var data = employee.GetAllSupervisors();
            if (data == null)
            {
                return NotFound();
            }

            return data;
        }
       


    }
}
