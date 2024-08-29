using Microsoft.EntityFrameworkCore;
using ApartmentPaymentsAPI.DataContexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Добавление строки подключения.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? 
    throw new InvalidOperationException("Connection string for 'ApartmentPaymentsAPI' not found.")));

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

/*app.UseWelcomePage();

// app.MapGet("/", () => "Hello World!");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");*/

//app.Run(async (context) =>
//{
//    var path = context.Request.Path;
//    var fullPath = @$"html/{path}";
//    var response = context.Response;

//    response.ContentType = "text/html; charset=utf-8";
//    if (File.Exists(fullPath))
//    {
//        await response.SendFileAsync(fullPath);
//    }
//    else
//    {
//        response.StatusCode = 404;
//        await response.WriteAsync("<h2>Not Found</h2>");
//    }
//});

app.Run();
