namespace SmartSolution.Application.Dtos.EntitiesDto
{
    public partial class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public byte[]? ProfileImage { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Dni { get; set; }
        public byte[]? Password { get; set; }
        public DateTime Creation { get; set; }
    }
}
