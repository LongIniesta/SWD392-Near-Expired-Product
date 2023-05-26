using BusinessTier.Mapper;
using Microsoft.EntityFrameworkCore;
using NearExpiredProduct.Data.Models;
using NearExpiredProduct.Data.UnitOfWork;
using NearExpiredProduct.Service.ImplService;
using NearExpiredProduct.Service.InterfaceService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddAutoMapper(typeof(Mapping));
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<NearExContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
app.UseSwagger();
app.UseSwaggerUI();
}*/
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "NearExpiredProduct.API1");
    options.RoutePrefix = String.Empty;
});
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
