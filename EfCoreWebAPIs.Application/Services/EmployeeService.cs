using EfCoreWebAPIs.Application.Interfaces;
using EfCoreWebAPIs.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Application.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Employee>> GetAllAsync() => _repository.GetAllAsync();

        public Task<Employee?> GetByIdAsync(Guid id) => _repository.GetByIdAsync(id);

        public Task<Employee> AddAsync(Employee employee) => _repository.AddAsync(employee);

        public Task UpdateAsync(Guid id,Employee employee) => _repository.UpdateAsync(id,employee);

        public Task DeleteAsync(Guid id) => _repository.DeleteAsync(id);
    }
}
