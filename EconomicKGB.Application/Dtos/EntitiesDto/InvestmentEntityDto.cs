namespace SmartSolution.Application.Dtos.EntitiesDto
{
    public partial class InvestmentEntityDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string Name { get; set; } = String.Empty!;
        public string Email { get; set; } = String.Empty!;
        public bool IsPorcentage { get; set; }
        //esa es la propiedad que me dice que metodo quiere
        public decimal Contribution { get; set; }
        public decimal Tmar { get; set; }
        public string TipoDeAmortizacion { get; set; } = String.Empty!;
        public bool MoneyLoan { get; set; }
        public bool FeeLevel { get; set; }
        //el tiempo que dura el prestamo
        public int LoanTerm { get; set; }
    }
}
