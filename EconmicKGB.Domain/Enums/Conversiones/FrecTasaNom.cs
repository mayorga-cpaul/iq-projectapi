namespace SmartSolution.Domain.Enums.Conversiones
{
    public enum FrecTasaNom
    {
        AnualCapSemestralmente = 2,
        AnualCapCuatrimestralmente = 3,
        AnualCapTrimestralmente = 4,
        AnualCapBimestralmente = 6,
        AnualCapMensualmente = 12,
        AnualCapSemanalmente = 52,
        AnualCapDiariamnete = 360,
        AnualCapContinuamente = int.MaxValue,
    }
}
