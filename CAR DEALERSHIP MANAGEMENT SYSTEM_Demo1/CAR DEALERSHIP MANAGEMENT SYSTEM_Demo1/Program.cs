using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Data;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.MappingProfile;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Impelmentation;
using CAR_DEALERSHIP_MANAGEMENT_SYSTEM_Demo1.Repo.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAutoMapper(
    x => x.AddProfile<MapperProfile>()
    );


builder.Services.AddScoped<VehicleCustomRepo>();
builder.Services.AddScoped<SalesCustomRepo>();
builder.Services.AddScoped<CustomerCustomRepo>();
builder.Services.AddScoped<CustomerProfileCustomRepo>();
builder.Services.AddScoped<EmployeeCustomRepo>();
builder.Services.AddScoped<CategoryCustomRepo>();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IVehicle, VehicleCustomRepo>();
builder.Services.AddScoped<ISales, SalesCustomRepo>();
builder.Services.AddScoped<ICustomer, CustomerCustomRepo>();
builder.Services.AddScoped<ICustomerProfile, CustomerProfileCustomRepo>();
builder.Services.AddScoped<IEmployee, EmployeeCustomRepo>();
builder.Services.AddScoped<ICategory, CategoryCustomRepo>();

builder.Services.AddDbContext<My_AppContext>(
    options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("conn")
        ));

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
