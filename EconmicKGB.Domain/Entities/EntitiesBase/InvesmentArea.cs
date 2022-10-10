namespace SmartSolution.Domain.Entities.EntitiesBase
{
    public partial class InvesmentArea
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string? Name { get; set; }
        public int Start { get; set; }
        public decimal Amount { get; set; }
        public bool? IsDiferida { get; set; }
        public decimal RecoveryCt { get; set; }
        public virtual Project Project { get; set; } = null!;
    }
}
