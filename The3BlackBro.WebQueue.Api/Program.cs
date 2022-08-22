using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
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
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    var _swaggerOp = new The3BlackBro.WebQueue.Api.Options.SwaggerOptions();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(_swaggerOp.UIEndpoint, _swaggerOp.Description); ;
        options.RoutePrefix = string.Empty;
    });
}

var swaggerOptions = new SwaggerOptions();
builder.Configuration.GetSection(nameof(SwaggerOptions)).Bind(swaggerOptions);

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSwagger(options =>
{
    options.RouteTemplate = swaggerOptions.RouteTemplate;
});


app.UseHttpsRedirection();

// Para testes locais
app.UseCors(x => x.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());

// Descomentar quando for utilizar autenticação
//app.UseAuthorization();

app.MapControllers();

app.Run();
