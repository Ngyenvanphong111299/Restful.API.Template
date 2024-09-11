using Entities.Models;
using Shared.Dtos;

namespace Shared.Mappings
{
    public static class CompanyDtoMapping
    {
        public static CompanyDto MapToDto(this Company company)
            => new(company.Id, company.Name ?? "", string.Join(' ', company.Address, company.Country));

        public static IEnumerable<CompanyDto> MapToDtos(this IEnumerable<Company> companies)
            => companies.Select(x => x.MapToDto()).ToList();
    }
}
