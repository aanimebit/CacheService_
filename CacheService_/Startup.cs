using CacheService_.DatabaseLocal;
using Microsoft.EntityFrameworkCore;
using CacheService_.Services.ServiceInterfaces;
using CacheService_.Services;

var builder = WebApplication.CreateBuilder(args);

//database configure
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

//services configure
builder.Services.AddScoped<IAdmUserCacheService, AdmUserCacheService>();
builder.Services.AddScoped<IUserCacheService, UserCacheService>();
builder.Services.AddScoped<IUserCategoryService, UserCategoryService>();
builder.Services.AddScoped<IUserTaskResponsibilityService, UserTaskResponsibilityService>();

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

//data generation
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CacheService_.DatabaseLocal.AppDbContext>();
    DbStartup.GenerateUserCategories(context);
    DbStartup.GenerateAdmUserCategories(context);
    DbStartup.GenerateUserTasks(context);
    DbStartup.GenerateAdmUserResponsobilities(context);
}

app.Run();
