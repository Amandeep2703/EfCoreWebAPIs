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
    public  record UpdateEmployeeCommand(Guid id, Employee emp) : IRequest<Employee>
    {
    }
    public class UpdateEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<UpdateEmployeeCommand, Employee>
    {
        public async Task<Employee> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            await employeeRepository.UpdateAsync(request.id, request.emp);
            return request.emp;
        }
    }
}
