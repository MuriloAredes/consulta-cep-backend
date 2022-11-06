using consultaCep_backend.Application.Delete;
using consultaCep_backend.Application.GetAll;
using consultaCep_backend.Application.Register;
using consultaCep_backend.Application.Update;
using consultaCep_backend.Database;
using consultaCep_backend.Entities;
using consultaCep_backend.interactor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISearchByZipCodeInteractor, SearchByZipCodeInteractor>();
builder.Services.AddScoped<IRegisterCep, RegisterCep>();
builder.Services.AddScoped<IGetAllEnderecosService, GetAllEnderecosService>();
builder.Services.AddScoped<IUpdateEnderecosService, UpdateEnderecosService>();
builder.Services.AddScoped<IDeleteEnderecoService, DeleteEnderecoService>();

string strConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<Context>(options =>
{
    options.UseSqlServer(strConnection);
});
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
