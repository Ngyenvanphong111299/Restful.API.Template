using Constracts;
using Entities.Exceptions;
using Service.Contracts;
using Shared.Dtos;
using Shared.Mappings;

namespace Service
{
    internal sealed class CompanyService(IRepositoryManager repository, ILoggerManager logger) : ICompanyService
    {
        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
            var companies = repository.Company.GetAllCompanies(trackChanges);
            var companiesDto = companies.MapToDtos();
            return companiesDto;
        }

        public CompanyDto GetCompany(Guid id, bool trackChanges)
        {
            var company = repository.Company.GetCompany(id, trackChanges) ?? throw new CompanyNotFoundException(id);
            var companyDto = company.MapToDto();
            return companyDto;
        }
    }
}
