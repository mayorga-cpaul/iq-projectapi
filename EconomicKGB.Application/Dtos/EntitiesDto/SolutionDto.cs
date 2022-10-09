namespace SmartSolution.Application.Dtos.EntitiesDto
{
    public partial class SolutionDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SolutionName { get; set; } = null!;
        public string Description { get; set; } = String.Empty!;
        public DateTime Date { get; set; }
    }
}
