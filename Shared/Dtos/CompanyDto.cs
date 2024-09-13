namespace Shared.Dtos
{
    public record CompanyDto(Guid Id, string Name, string Address, IEnumerable<EmployeeDto> Employees);

    public record CompanyForCreationDto(string Name, string Address, string Country, IEnumerable<EmployeeForCreationDto> Employees);

    public record CompanyForUpdateDto(string Name, string Address, string Country, IEnumerable<EmployeeForCreationDto> Employees);
}
