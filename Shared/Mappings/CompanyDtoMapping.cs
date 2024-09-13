using Entities.Models;
using Microsoft.VisualBasic;
using Shared.Dtos;

namespace Shared.Mappings
{
    public static class CompanyDtoMapping
    {
        public static CompanyDto MapToDto(this Company company)
            => new(Id: company.Id,
                Name: company.Name ?? string.Empty,
                Address: string.Join(' ', company.Address, company.Country),
                Employees: company.Employees?.Select(x => x.MapToDto()) ?? []);

        public static IEnumerable<CompanyDto> MapToDtos(this IEnumerable<Company> companies)
            => [.. companies.Select(x => x.MapToDto())];

        public static Company MapToCreationEntity(this CompanyForCreationDto companyForCreationDto)
            => new()
            {
                Name = companyForCreationDto.Name,
                Address = companyForCreationDto.Address,
                Country = companyForCreationDto.Country,
                Employees = companyForCreationDto.Employees?.Select(e => e.MapToCreationEntity()).ToList() ?? []
            };

        public static IEnumerable<Company> MapToCreationEntities(this IEnumerable<CompanyForCreationDto> companyForCreationDtos)
            => [.. companyForCreationDtos.Select(x => x.MapToCreationEntity())];

        public static Company MapToUpdateEntity(this Company company, CompanyForUpdateDto companyForUpdateDto)
        {
            company.Name = companyForUpdateDto.Name;
            company.Address = companyForUpdateDto.Address;
            company.Country = companyForUpdateDto.Country;
            company.Employees = companyForUpdateDto.Employees?.Select(e => e.MapToCreationEntity()).ToList() ?? [];
            return company;
        }
    }
}
