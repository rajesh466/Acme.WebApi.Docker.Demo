using Acme.WebApi.Docker.Demo.DatabaseContext;
using Acme.WebApi.Docker.Demo.Identity;
using Acme.WebApi.Docker.Demo.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();

//var dbHost = Environment.GetEnvironmentVariable("DB_HOST");
//var port = "1433";
//var dbName = Environment.GetEnvironmentVariable("DB_NAME");
//var user = "SA";
//var dbPassword = Environment.GetEnvironmentVariable("DB_SA_PASSWORD");
////var database = "AcmeCustomers";

//var connectionString = $"Data Source={dbHost};Initial Catalog={dbName};Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));
    //options.UseSqlServer(connectionString));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.add
builder.Services.AddSwaggerGen();
//builder.Services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
//{
//    options.Password.RequiredLength = 8;
//    options.Password.RequireLowercase = true;
//    options.Password.RequireNonAlphanumeric = true;
//    options.Password.RequireUppercase = true;
//    options.Password.RequireDigit = true;
//})
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders()
//    .AddUserStore<UserStore<ApplicationUser,ApplicationRole, ApplicationDbContext, Guid>>()
//    .AddRoleStore< RoleStore<ApplicationRole, ApplicationDbContext, Guid>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseCors();

app.UseMiddleware<ApiKeyMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
