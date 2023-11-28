using BookTracker.BusinessLogic.Extensions;
using BookTracker.Persistence;
using BookTracker.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookTrackerDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();
builder.Services.AddBusinessLogic();
builder.Services.AddPersistence(connectionString);


var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
