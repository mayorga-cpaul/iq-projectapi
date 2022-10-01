﻿namespace SmartSolution.Application.Dtos.EntitiesDto
{
    public partial class ProjectExpenseDto
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public decimal Expense { get; set; }
        public decimal? Growth { get; set; }
        public string? TypeGrowth { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
        public string? TypeExpense { get; set; }
    }
}
