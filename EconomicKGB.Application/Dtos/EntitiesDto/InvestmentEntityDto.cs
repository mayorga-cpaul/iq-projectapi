namespace SmartSolution.Application.Dtos.EntitiesDto
{
    public partial class InvestmentEntityDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public bool IsPorcentage { get; set; }
        public decimal? Contribution { get; set; }
        public decimal? Tmar { get; set; }
        public byte[]? ProfileImage { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Dni { get; set; }
        public bool MoneyLoan { get; set; }
        public bool? FeeLevel { get; set; }
        public int LoanTerm { get; set; }
    }
}
