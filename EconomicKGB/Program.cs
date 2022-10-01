using SmartSolution.API.IOC;
using SmartSolution.API.Settings;
using SmartSolution.Application.Mappers.MappingDto;
using SmartSolution.Domain.EconomicContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers( options =>
{
    options.SuppressAsyncSuffixInActionNames = false;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var sqlbdSettings = builder.Configuration.GetSection(nameof(SqlDbSettings)).Get<SqlDbSettings>();
builder.Services.AddSqlServer<EconomicKGBContext>(sqlbdSettings.ConnectionString());
builder.Services.AddAutoMapper(typeof(Program).Assembly, typeof(AutoMapperProfile).Assembly);
DependencyInjection.IOCEconomic(builder);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
