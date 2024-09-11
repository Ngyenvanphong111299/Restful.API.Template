using Constracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.Dtos;
using Shared.Mappings;

namespace Service
{
    internal sealed class EmployeeService(IRepositoryManager _repository, ILoggerManager _logger) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeesFromDb = _repository.Employee.GetEmployees(companyId, trackChanges);
            var employeesDto = employeesFromDb.MapToDtos();
            return employeesDto;
        }
    }
}

