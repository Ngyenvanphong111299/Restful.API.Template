using Entities.Models;
using Shared.Dtos;

namespace Shared.Mappings
{
    public static class EmployeeDtoMapping
    {
        public static EmployeeDto MapToDto(this Employee employee)
            => new(Id: employee.Id,
                Name: employee.Name ?? string.Empty,
                Age: employee.Age,
                Position: employee.Position ?? string.Empty);

        public static IEnumerable<EmployeeDto> MapToDtos(this IEnumerable<Employee> employees)
            => [.. employees.Select(x => x.MapToDto())];

        public static Employee MapToCreationEntity(this EmployeeForCreationDto employeeForCreationDto)
            => new()
            {
                Name = employeeForCreationDto.Name,
                Age = employeeForCreationDto.Age,
                Position = employeeForCreationDto.Position,
            };

        public static Employee MapToUpdateEntity(this Employee employee, EmployeeForUpdateDto employeeForUpdateDto)
        {
            employee.Name = employeeForUpdateDto.Name;
            employee.Age = employeeForUpdateDto.Age;
            employee.Position = employeeForUpdateDto.Position;
            return employee;
        }

        public static EmployeeForUpdateDto MapToUpdateDto(this Employee employee)
           => new()
           {
               Age = employee.Age,
               Name = employee.Name ?? string.Empty,
               Position = employee.Position ?? string.Empty,
           };
    }
}
