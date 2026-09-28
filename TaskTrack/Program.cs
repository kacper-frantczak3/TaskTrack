using TaskTrack.Data;
using TaskTrack.Middleware;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=tasks.db"));
    
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskTrack v1");
        c.RoutePrefix = string.Empty;
    });
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/", () => Results.Ok(new
{
    message = "Welcome to TaskTrack!",
    version = "v1.0",
    endpoints = new
    {
        getAllTasks = "GET /api/tasks",
        getTaskById = "GET /api/tasks/{id}",
        createTask = "POST /api/tasks",
        updateTask = "PUT /api/tasks/{id}",
        deleteTask = "DELETE /api/tasks/{id}",
    }
}));

app.MapControllers();
app.Run();