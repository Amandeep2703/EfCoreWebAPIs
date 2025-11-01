using EfCoreWebAPIs.Application.Interfaces;
using EfCoreWebAPIs.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWebAPIs.Application.Queries.EmployeeQueries
{
    public record GetEmployeeById(Guid id) : IRequest<Employee?>
    {
    }
    public class GetEmployeeByIdHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<GetEmployeeById, Employee?>
    {
        public async Task<Employee?> Handle(GetEmployeeById request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetByIdAsync(request.id);
        }
    }

}
