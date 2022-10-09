namespace SmartSolution.Application.Dtos.EntitiesDto
{
    public partial class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string? PhoneNumber { get; set; }
        public string? Dni { get; set; }
        public string Password { get; set; } = String.Empty;
        public DateTime Creation { get; set; }
        public bool State { get; set; }

    }
}
