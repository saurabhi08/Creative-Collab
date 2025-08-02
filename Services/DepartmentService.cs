using Microsoft.EntityFrameworkCore;
using MindAndMarket.Data;
using MindAndMarket.DTOs;
using MindAndMarket.Models;

namespace MindAndMarket.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly MindAndMarketContext _context;

        public DepartmentService(MindAndMarketContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            return await _context.Departments
                .Select(d => new DepartmentDto
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    ManagerName = d.ManagerName,
                    IsActive = d.IsActive
                })
                .ToListAsync();
        }

        public async Task<DepartmentDto?> GetDepartmentByIdAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null) return null;

            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                ManagerName = department.ManagerName,
                IsActive = department.IsActive
            };
        }

        public async Task<DepartmentDto> CreateDepartmentAsync(CreateDepartmentDto createDepartmentDto)
        {
            var department = new Department
            {
                Name = createDepartmentDto.Name,
                Description = createDepartmentDto.Description,
                ManagerName = createDepartmentDto.ManagerName,
                IsActive = createDepartmentDto.IsActive
            };

            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                ManagerName = department.ManagerName,
                IsActive = department.IsActive
            };
        }

        public async Task<DepartmentDto?> UpdateDepartmentAsync(int id, UpdateDepartmentDto updateDepartmentDto)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null) return null;

            department.Name = updateDepartmentDto.Name;
            department.Description = updateDepartmentDto.Description;
            department.ManagerName = updateDepartmentDto.ManagerName;
            department.IsActive = updateDepartmentDto.IsActive;

            await _context.SaveChangesAsync();

            return new DepartmentDto
            {
                Id = department.Id,
                Name = department.Name,
                Description = department.Description,
                ManagerName = department.ManagerName,
                IsActive = department.IsActive
            };
        }

        public async Task<bool> DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null) return false;

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
            return true;
        }
    }
} 