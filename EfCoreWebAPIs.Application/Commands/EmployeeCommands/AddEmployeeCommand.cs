using EfCoreWebAPIs.Application.Interfaces;
using EfCoreWebAPIs.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Application.Commands.EmployeeCommands
{
    public record AddEmployeeCommand(Employee employee): IRequest<Employee>
    {
    }
    public class AddEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<AddEmployeeCommand, Employee>
    {
        public async Task<Employee> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.AddAsync(request.employee);
        }
    }
}
