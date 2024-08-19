global using eCommerce.Models;
using eCommerce.APIEF.Database;
using eCommerce.APIEF.Repositories;
using Microsoft.EntityFrameworkCore;
using WatchDog;
using WatchDog.src.Enums;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region ConfigureService()
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUsuarioRepository,UsuarioRepository>();

builder.Services.AddWatchDogServices(opt =>
{
    opt.IsAutoClear = true;
    //opt.ClearTimeSchedule = WatchDogAutoClearScheduleEnum.Weekly;
    opt.SetExternalDbConnString = "Data Source=(localdb)\\MSSQLLocalDB";
    opt.DbDriverOption = WatchDogDbDriverEnum.MSSQL;


});

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

app.UseWatchDogExceptionLogger();

app.UseWatchDog(opt =>
{
    opt.WatchPageUsername = "admin";
    opt.WatchPagePassword = "12345678";
});
app.Run();
#endregion