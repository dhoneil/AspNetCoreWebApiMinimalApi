using aspnetcorewebapiminimalapi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using aspnetcorewebapiminimalapi.Endpoints;
using DataLibrary;
using aspnetcorewebapiminimalapi.GlobalVariables;

//CORS POLICY NAME DECLERATION
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);


//CORS POLICY SETTINGS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
    policy =>
    {
        policy.WithOrigins("http://example.com",
                            "http://www.contoso.com",
                            "https://localhost:7280",
                            "https://localhost:7134").AllowAnyHeader().AllowAnyMethod();
    });
});



builder.Services.AddAuthorization();
builder.Services.AddHealthChecks();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();
builder.Services.AddHealthChecks();

//SERVICES
GlobalVariables.CONNECTIONSTRING = builder.Configuration.GetConnectionString("aquipcebuconnection");
GlobalVariables.MYSQLCONNECTIONSTRING = builder.Configuration.GetConnectionString("mysqlconnectionlocal");
builder.Services.AddDbContext<accounting_systemContext>(options => options.UseSqlServer(GlobalVariables.CONNECTIONSTRING), ServiceLifetime.Transient);
builder.Services.AddTransient<IDataAccess, DataAccess>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//ENDPOINTS
app.ItemEndpoints();
app.BeauticianEndpoints();

//CORS SETTINGS
app.UseStaticFiles();
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization(); //<< This needs to be between app.UseRouting(); and app.UseEndpoints();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});




app.Run();