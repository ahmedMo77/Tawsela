using Microsoft.EntityFrameworkCore;
using Tawsela.Entities;
using Tawsela.Repositories.Interfaces;
using Tawsela.Repositories.Implementations;
using Tawsela.Services.Interfaces;
using Tawsela.Services.Implementations;
using Tawsela.Patterns;
using Tawsela.Enums;
using Tawsela.Data;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

// Services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IShipmentService, ShipmentService>();
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IReviewService, ReviewService>();

builder.Services.AddSingleton<IUserFactory, UserFactory>();
//var factory = new UserFactory();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    await SampleData.InitializeAsync(context);
}

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();