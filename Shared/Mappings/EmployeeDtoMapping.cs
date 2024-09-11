using Entities.Models;
using Shared.Dtos;

namespace Shared.Mappings
{
    public static class EmployeeDtoMapping
    {
        public static EmployeeDto MapToDto(this Employee employee)
            => new(employee.Id, employee.Name ?? "", employee.Age, employee.Position ?? "");

        public static IEnumerable<EmployeeDto> MapToDtos(this IEnumerable<Employee> employees)
            => employees.Select(x => x.MapToDto()).ToList();
    }
}
