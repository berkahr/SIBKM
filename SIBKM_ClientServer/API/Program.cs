using API.Context;
using API.Repositories.Data;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Configure DbContext to sql server database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyContext>(options => options.UseSqlServer(connectionString));

// Add dependency Injection for Repository
builder.Services.AddScoped<IUniversitiesRepository, UniversitiesRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IProfilingsRepository,ProfilingsRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEducationsRepository, EducationRepository>();
builder.Services.AddScoped<IAccountsRepository, AccountRepository>();
builder.Services.AddScoped<IAccountRolesRepository, AccountRolesRepository>();
//builder.Services.AddScoped(typeof(IGeneralRepository<,>), typeof(GeneralRepository<,,>));

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
