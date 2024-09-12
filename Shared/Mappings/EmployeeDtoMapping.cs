using Entities.Models;
using Shared.Dtos;

namespace Shared.Mappings
{
    public static class EmployeeDtoMapping
    {
        public static EmployeeDto MapToDto(this Employee employee)
            => new()
            {
                Id = employee.Id,
                Name = employee.Name ?? "",
                Age = employee.Age,
                Position = employee.Position ?? "",
            };

        public static IEnumerable<EmployeeDto> MapToDtos(this IEnumerable<Employee> employees)
            => [.. employees.Select(x => x.MapToDto())];

        public static Employee MapToCreationEntity(this EmployeeForCreationDto employeeForCreationDto)
        {
            return new()
            {
                Name = employeeForCreationDto.Name,
                Age = employeeForCreationDto.Age,
                Position = employeeForCreationDto.Position,
            };
        }
    }
}
