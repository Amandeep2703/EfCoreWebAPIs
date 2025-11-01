using EfCoreWebAPIs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Application.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllAsync();
        Task<Employee?> GetByIdAsync(Guid id);
        Task<Employee> AddAsync(Employee employee);
        Task UpdateAsync(Guid id, Employee employee);
        Task<bool> DeleteAsync(Guid id);
    }
}
