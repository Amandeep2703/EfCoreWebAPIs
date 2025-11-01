using EfCoreWebAPIs.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Application.Commands.EmployeeCommands
{
    public record DeleteEmployeeCommand(Guid id) : IRequest<bool>
    {
    }
    public class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.DeleteAsync(request.id);
        }
    }
}
