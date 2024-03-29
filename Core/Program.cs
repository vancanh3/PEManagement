using Microsoft.EntityFrameworkCore;
using PersionalExpenditureManagement.PE.DbContext;
using PersionalExpenditureManagement.PE.DbContext.Infrastructure;
using PersionalExpenditureManagement.Service;
using PersionalExpenditureManagement.Service.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PEDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("PEDataContext"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
