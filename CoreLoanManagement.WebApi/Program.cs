using LoanManagement.DB.Data;
using LoanManagement.DB.Interfaces;
using LoanManagement.DB.Repositories;
using LoanManagement.Interfaces;
using LoanManagement.Repositories;
using LoanManagement.Web.Models;

var builder = WebApplication.CreateBuilder(args);
//builder.WebHost.UseKestrel();
//builder.WebHost.UseIISIntegration();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

LoanManagement.Platform.Mapper.CustomMapper.RegisterMapping<Customer, CustomerItem>();
LoanManagement.Platform.Mapper.CustomMapper.RegisterMapping<CustomerItem, Customer>();

builder.Services.AddSingleton<ILoanManagerRepository,LoanManagerRepository>();
builder.Services.AddSingleton<IDBLoanManagerRepository, DBLoanManagerRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
