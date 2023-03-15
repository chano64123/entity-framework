using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectEF;

var builder = WebApplication.CreateBuilder(args);

//* DB in memory
//builder.Services.AddDbContext<TasksContext>(x => x.UseInMemoryDatabase("DB_Tasks"));
builder.Services.AddSqlServer<TasksContext>(builder.Configuration.GetConnectionString("dbTasks"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/check", ([FromServices] TasksContext dbContext) => {
    bool dbInServer = dbContext.Database.EnsureCreated();
    bool dbInMemory = dbContext.Database.IsInMemory();
    return Results.Ok($"BD in memory => {dbInMemory}, DB in server => {dbInServer}");
});

app.Run();
