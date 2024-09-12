namespace Shared.Dtos
{
    public record EmployeeDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Position { get; set; }
    };

    public record EmployeeForCreationDto
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public string? Position { get; set; }
    };
}
