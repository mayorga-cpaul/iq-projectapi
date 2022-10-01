namespace SmartSolution.Application.Dtos.EntitiesDto
{
    public partial class InvesmentAreaDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Name { get; set; }
        public bool IsInTheFirstYear { get; set; }
        public int Start { get; set; }
        public decimal Amount { get; set; }
        public bool IsDepreciable { get; set; }
        public int LifeSpan { get; set; }
        public bool? IsDiferida { get; set; }
        public string? Metodo { get; set; }
    }
}
