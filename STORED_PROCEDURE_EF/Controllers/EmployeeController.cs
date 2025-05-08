using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using STORED_PROCEDURE_EF.Services;

namespace STORED_PROCEDURE_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly iEmployeeService _iEmployeeService;

        public EmployeeController(iEmployeeService employeeService)
        {
            _iEmployeeService = employeeService;
        }


        [HttpPost("Add Employee")]
        public async Task<IActionResult> AddEmployee([FromForm] UpdateEmpDto empDto)
        {
            return Ok(await _iEmployeeService.AddEmployee(empDto));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        { 
            //await _iEmployeeService.GetAllEmployee();
            return Ok(await _iEmployeeService.GetAllEmployee());
        }
        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _iEmployeeService.GetById(id));
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateEmp([FromForm]UpdateEmpDto empDto,int id)
        {
            return Ok(await _iEmployeeService.UpdateEmployee(empDto,id));
        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteEmp(int id)
        {
            return Ok(await _iEmployeeService.DeleteEmployee(id));
        }
    }
}
