global using eCommerce.Models;
using eCommerce.APIEF.Database;
using eCommerce.APIEF.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region ConfigureService()
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUsuarioRepository,UsuarioRepository>();

builder.Services.AddDbContext<eCommerceContext>(
    //GetConnectionString é próprio para pegar a string de conexão do appsetings
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("eCommerceEF"))
    );
#endregion

var app = builder.Build();

#region Configure
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
#endregion