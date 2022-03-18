using Microsoft.EntityFrameworkCore;
using ToDo_List.Infrastructure.Context;
using ToDo_List.Infrastructure.Interfaces;
using ToDo_List.Infrastructure.Services;
using ToDo_List.Services.Interfaces;
using ToDo_List.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ToDoContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddTransient<IContextService, ContextService>();
builder.Services.AddTransient<IUserService, UserService>();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
