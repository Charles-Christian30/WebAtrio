using Microsoft.EntityFrameworkCore;
using Web_Atrio.Context;
using Web_Atrio.Mapping;
using Web_Atrio.Repository;
using Web_Atrio.Services;
using Web_Atrio.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["DbConnection"];
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WebContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddAutoMapper(typeof(MappingConfiguration));
builder.Services.AddScoped<IPersonneRepository, PersonneRepository>();
builder.Services.AddScoped<IPersonneService, PersonneService>();
builder.Services.AddScoped<IEmploisRepository, EmploisRepository>();
builder.Services.AddScoped<IEmploisService, EmploisService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWorkImplementation>();


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
