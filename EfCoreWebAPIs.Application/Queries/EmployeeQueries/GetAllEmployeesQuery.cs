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
    public record GetAllEmployeesQuery : IRequest<IEnumerable<Employee>>
    {
    }

    public class GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<GetAllEmployeesQuery, IEnumerable<Employee>>
    {
        public async Task<IEnumerable<Employee>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetAllAsync();
        }
    }
}
