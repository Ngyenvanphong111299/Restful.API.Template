namespace Shared.Dtos
{
    public record CompanyDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? FullAddress { get; set; }
        public IEnumerable<EmployeeDto>? Employees { get; set; }
    }

    public record CompanyForCreationDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public IEnumerable<EmployeeForCreationDto>? Employees { get; set; }
    };

}
