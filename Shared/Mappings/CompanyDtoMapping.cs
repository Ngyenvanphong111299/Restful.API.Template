using Entities.Models;
using Shared.Dtos;

namespace Shared.Mappings
{
    public static class CompanyDtoMapping
    {
        public static CompanyDto MapToDto(this Company company)
            => new()
            {
                Id = company.Id,
                Name = company.Name ?? "",
                FullAddress = string.Join(' ', company.Address, company.Country),
                Employees = [.. company.Employees!.Select(x => x.MapToDto())]
            };

        public static IEnumerable<CompanyDto> MapToDtos(this IEnumerable<Company> companies)
            => [.. companies.Select(x => x.MapToDto())];

        public static Company MapToCreationEntity(this CompanyForCreationDto companyForCreationDto)
        {
            return new Company
            {
                Name = companyForCreationDto.Name,
                Address = companyForCreationDto.Address,
                Country = companyForCreationDto.Country,
                Employees = [.. companyForCreationDto.Employees!.Select(e => e.MapToCreationEntity())]
            };
        }

        public static IEnumerable<Company> MapToCreationEntities(this IEnumerable<CompanyForCreationDto> companyForCreationDtos)
            => [.. companyForCreationDtos.Select(x => x.MapToCreationEntity())];
    }
}
