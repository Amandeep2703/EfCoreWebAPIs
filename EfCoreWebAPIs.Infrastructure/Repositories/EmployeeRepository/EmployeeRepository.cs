using EfCoreWebAPIs.Core.Entities;
using EfCoreWebAPIs.Infrastructure.Data;
using EfCoreWebAPIs.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Infrastructure.Repositories.EmployeeRepository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            return await _context.Employees
                .Where(e => e.IsDeleted != true)
                .ToListAsync();
        }

        public async Task<Employee?> GetByIdAsync(Guid id)
        {
            return await _context.Employees
                .FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted != true);
        }

        public async Task<Employee> AddAsync(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employee.CreatedOn = DateTime.UtcNow;
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task UpdateAsync(Guid id, Employee employee)
        {
            Employee? emp = await _context.Employees.FirstOrDefaultAsync(e => e.Id == id && e.IsDeleted != true);
            if (emp is not null)
            {
                emp.UpdatedOn = DateTime.UtcNow;
                emp.FirstName = employee.FirstName ?? emp.FirstName;
                emp.LastName = employee.LastName ?? emp.LastName;
                emp.IsActive = employee.IsActive ?? emp.IsActive;
                emp.Email = employee.Email ?? emp.Email;
                emp.Department = employee.Department ?? emp.Department;
                emp.Salary = employee.Salary ?? emp.Salary;
                await _context.SaveChangesAsync();
            }

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var employee = await GetByIdAsync(id);
            if (employee != null)
            {
                employee.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
