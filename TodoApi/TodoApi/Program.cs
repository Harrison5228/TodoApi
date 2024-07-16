using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using TodoApi.Filters;
using TodoApi.Models;
using TodoApi.Models.Dto;
using TodoApi.Models.Request;
using TodoApi.Models.ViewModel;
using TodoApi.Repositories;
using TodoApi.Repositories.Interfaces;
using TodoApi.Services;
using TodoApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(ValidUserFilter));
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHealthChecks();
builder.Services.AddDistributedMemoryCache();


var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<UserDto, User>();
    cfg.CreateMap<TodoItemDto, TodoItem>();
    cfg.CreateMap<TodoItem, TodoItemDto>();
    cfg.CreateMap<TodoSearchRequest, TodoSearchCondition>();
    cfg.CreateMap<CreateTodoRequest, TodoItem>();
    cfg.CreateMap<UpdateTodoRequest, TodoItem>();
    cfg.CreateMap<TodoItem, TodoViewModel>();
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);


// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("Policy",policyBuilder => policyBuilder
            .WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials()
            .SetPreflightMaxAge(TimeSpan.FromDays(1))
        );
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromDays(1);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<IConnectionService, ConnectionService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();


builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<ISessionService, SessionService>();


builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
    });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("Policy");
app.UseSession();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();


app.Run();