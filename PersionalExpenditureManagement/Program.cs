using Microsoft.EntityFrameworkCore;
using PersionalExpenditureManagement.PE.DbContext;
using PersionalExpenditureManagement.PE.DbContext.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<PEDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PEDataContext"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
