using AutoMapper;
using MarketplaceCF.Data;
using MarketplaceCF.Data.Repositories;
using MarketplaceCF.Data.Repositories.Interfaces;
using MarketplaceCF.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Конфигурация Mapper
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Конфигурация жизниных циклов
builder.Services.AddTransient<IProductRepository, ProductRepository>(); 
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
    options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});
app.Run();
