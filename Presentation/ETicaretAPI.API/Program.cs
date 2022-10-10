using ETicaretAPI.API.Extensions;
using ETicaretAPI.Application;
using ETicaretAPI.Application.CQRS.Product.Command.Add;
using ETicaretAPI.Application.Validators;
using ETicaretAPI.Infrastructure.Services.Storage.LocalStorage;
using ETicaretAPI.Persistence;
using ETicaretAPI.SignalR;
using ETicaretAPI.SignalR.Extensions;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Core;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

Logger logg = new LoggerConfiguration().
    WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("MSSQL"), "logs", autoCreateSqlTable: true)
    .WriteTo.Seq(builder.Configuration.GetConnectionString("SEQ"))
    .MinimumLevel.Information()
    .CreateLogger();

builder.Host.UseSerilog(logg);



builder.Services.AddPersistenceServices();
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService();
builder.Services.AddSignalRServices();
builder.Services.AddStoreage<LocalStorage>();

builder.Services.AddControllers().AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<AddProductCommandRequest>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication().AddJwtBearer("Admin", options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        ValidIssuer = builder.Configuration["Token:Issuer"],
        ValidAudience = builder.Configuration["Token:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
        LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false
    };
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());
app.UseSerilogRequestLogging();
app.UseStaticFiles();
app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.AddMapHub();

app.Run();
