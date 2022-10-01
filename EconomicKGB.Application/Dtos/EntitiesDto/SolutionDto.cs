namespace SmartSolution.Application.Dtos.EntitiesDto
{
    public partial class SolutionDto
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public string SolutionName { get; set; } = String.Empty;
        public DateTime Date { get; set; }
    }
}
