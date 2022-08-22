using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using The3BlackBro.WebQueue.Api.Options;
using The3BlackBro.WebQueue.Infra.Context;
using The3BlackBro.WebQueue.Service;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<WebQueueContext>(options =>
    options.UseNpgsql(connectionString));


builder.Services.AddMvc().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.RegisterServices(builder.Configuration.GetConnectionString("DefaultConnection"));


builder.Services.AddSwaggerGen(x =>
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "Web Queue Api", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
 
    var swaggerOptions = new SwaggerOptions();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(swaggerOptions.UIEndpoint, swaggerOptions.Description);
        options.RoutePrefix = string.Empty;
    });

    builder.Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

}


app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseHttpsRedirection();

app.UseCors(x => x.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());

//app.UseAuthorization();

app.MapControllers();

app.Run();
