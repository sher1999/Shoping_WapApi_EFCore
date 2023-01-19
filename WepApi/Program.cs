using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
    var connection = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<DataContext>(conf => conf.UseNpgsql(connection));
    builder.Services.AddControllers();
    builder.Services.AddScoped<CustomerService>();
    builder.Services.AddScoped<OrderService>();
    builder.Services.AddScoped<ProductService>();
    builder.Services.AddScoped<OrderDetailService>();


    


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
