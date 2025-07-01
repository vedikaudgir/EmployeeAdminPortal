namespace EmployeeAdminPortal.Models
{
    public class updateEmployeeDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Salary { get; set; }
    }
}
