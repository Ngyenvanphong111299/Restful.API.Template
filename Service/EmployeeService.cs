using Constracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.Dtos;
using Shared.Mappings;

namespace Service
{
    internal sealed class EmployeeService(IRepositoryManager _repository, ILoggerManager _logger) : IEmployeeService
    {
        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
            
            var employeesFromDb = _repository.Employee.GetEmployees(companyId, trackChanges);
            
            var employeesDto = employeesFromDb.MapToDtos();
            return employeesDto;
        }

        public EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
            
            var employeeDb = _repository.Employee.GetEmployee(companyId, id, trackChanges) ?? throw new EmployeeNotFoundException(id);
            
            var employee = employeeDb.MapToDto();
            return employee;
        }

        public EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges) ?? throw new CompanyNotFoundException(companyId);
            
            var employeeEntity = employeeForCreation.MapToCreationEntity();
            _repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
            _repository.Save();

            var employeeToReturn = employeeEntity.MapToDto();
            return employeeToReturn;
        }

    }
}

