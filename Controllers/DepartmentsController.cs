using Microsoft.AspNetCore.Mvc;
using MindAndMarket.DTOs;
using MindAndMarket.Services;

namespace MindAndMarket.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetDepartments()
        {
            var departments = await _departmentService.GetAllDepartmentsAsync();
            return Ok(departments);
        }

        // GET: api/departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartment(int id)
        {
            var department = await _departmentService.GetDepartmentByIdAsync(id);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        // POST: api/departments
        [HttpPost]
        public async Task<ActionResult<DepartmentDto>> CreateDepartment(CreateDepartmentDto createDepartmentDto)
        {
            var department = await _departmentService.CreateDepartmentAsync(createDepartmentDto);
            return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, department);
        }

        // PUT: api/departments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, UpdateDepartmentDto updateDepartmentDto)
        {
            var department = await _departmentService.UpdateDepartmentAsync(id, updateDepartmentDto);
            if (department == null)
            {
                return NotFound();
            }
            return Ok(department);
        }

        // DELETE: api/departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var result = await _departmentService.DeleteDepartmentAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
} 