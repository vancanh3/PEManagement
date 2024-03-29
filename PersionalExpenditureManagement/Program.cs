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

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapControllers();
app.Run();
