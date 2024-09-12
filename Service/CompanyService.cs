using Constracts;
using Entities.Exceptions;
using Entities.Models;
using Service.Contracts;
using Shared.Dtos;
using Shared.Mappings;

namespace Service
{
    internal sealed class CompanyService(IRepositoryManager _repository, ILoggerManager logger) : ICompanyService
    {
        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
            var companies = _repository.Company.GetAllCompanies(trackChanges);
            var companiesDto = companies.MapToDtos();
            return companiesDto;
        }

        public CompanyDto GetCompany(Guid id, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(id, trackChanges) ?? throw new CompanyNotFoundException(id);
            var companyDto = company.MapToDto();
            return companyDto;
        }

        public CompanyDto CreateCompany(CompanyForCreationDto company)
        {
            var companyEntity = company.MapToCreationEntity();
            _repository.Company.CreateCompany(companyEntity);
            _repository.Save();

            var companyToReturn = companyEntity.MapToDto();
            return companyToReturn;
        }

        public IEnumerable<CompanyDto> GetByIds(IEnumerable<Guid> ids, bool trackChanges)
        {
            if (ids is null)
                throw new IdParametersBadRequestException();
            
            var companyEntities = _repository.Company.GetByIds(ids, trackChanges);
            
            if (ids.Count() != companyEntities.Count())
                throw new CollectionByIdsBadRequestException();
            
            var companiesToReturn = companyEntities.MapToDtos();
            return companiesToReturn;
        }

        public (IEnumerable<CompanyDto> companies, string ids) CreateCompanyCollection(IEnumerable<CompanyForCreationDto> companyCollection)
        {
            if (companyCollection is null)
                throw new CompanyCollectionBadRequest();

            var companyEntities = companyCollection.MapToCreationEntities();
            foreach (var company in companyEntities)
            {
                _repository.Company.CreateCompany(company);
            }
            _repository.Save();

            var companyCollectionToReturn = companyEntities.MapToDtos();
            var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));
            return (companies: companyCollectionToReturn, ids);
        }
    }
}
