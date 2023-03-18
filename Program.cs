using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using projectEF;
using Task = projectEF.Models.Task;
using projectEF.Models;

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

//CRUD TASK
app.MapGet("/tasks", async ([FromServices] TasksContext dbContext) => {
    return Results.Ok(dbContext.Tasks.Include(x => x.Category));
});

app.MapGet("/tasks/priority/{priority}", async ([FromServices] TasksContext dbContext, [FromRoute] int priority) => {
    return Results.Ok(dbContext.Tasks.Include(x => x.Category).Where(x => (int)x.Priority == priority));
});

app.MapPost("/tasks", async ([FromServices] TasksContext dbContext, [FromBody] Task task) => {
    task.IdTask = Guid.NewGuid();
    task.CreationDate = DateTime.Now;
    await dbContext.Tasks.AddAsync(task);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromBody] Task task, [FromRoute] Guid id) => {
    var currentTask = dbContext.Tasks.Find(id);

    if(currentTask == null){
        return Results.NotFound();
    }

    currentTask.IdCategory = task.IdCategory;
    currentTask.Title= task.Title;
    currentTask.Priority = task.Priority;
    currentTask.Description = task.Description;
    currentTask.CulminationDate = task.CulminationDate;

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapDelete("/tasks/{id}", async ([FromServices] TasksContext dbContext, [FromRoute] Guid id) => {
    var currentTask = dbContext.Tasks.Find(id);

    if(currentTask == null){
        return Results.NotFound();
    }

    dbContext.Remove(currentTask);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

//CRUD CATEGORIAS
app.MapGet("/categories", async ([FromServices] TasksContext dbContext) => {
    return Results.Ok(dbContext.Categories);
});

app.MapPost("/categories", async ([FromServices] TasksContext dbContext, [FromBody] Category category) => {
    category.IdCategory = Guid.NewGuid();
    await dbContext.Categories.AddAsync(category);
    await dbContext.SaveChangesAsync();
    return Results.Ok();
});

app.MapPut("/categories/{id}", async ([FromServices] TasksContext dbContext, [FromBody] Category category, [FromRoute] Guid id) => {
    var currentCategory = dbContext.Categories.Find(id);

    if(currentCategory == null){
        return Results.NotFound();
    }

    currentCategory.IdCategory = category.IdCategory;
    currentCategory.Name = category.Name;
    currentCategory.Description = category.Description;
    currentCategory.Impact = category.Impact;

    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.MapDelete("/categories/{id}", async ([FromServices] TasksContext dbContext, [FromRoute] Guid id) => {
    var currentCategory = dbContext.Categories.Find(id);

    if(currentCategory == null){
        return Results.NotFound();
    }

    dbContext.Remove(currentCategory);
    await dbContext.SaveChangesAsync();

    return Results.Ok();
});

app.Run();
