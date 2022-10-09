namespace SmartSolution.API.Settings
{
    public class SqlDbSettings
    {
        public string? Server { get; set; }
        public int Port { get; set; }
        public string? User { get; set; }
        public string? Database { get; set; }
        public string? Password { get; set; }
        public string ConnectionString() => $"Data source={Server}, {Port}; Initial Catalog={Database}; User Id={User}; Password={Password}";
    }
}
