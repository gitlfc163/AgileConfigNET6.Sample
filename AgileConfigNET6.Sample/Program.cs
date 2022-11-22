using AgileConfigNET6.Sample.Models;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//采用下面的形式把配置类型 实体注入到容器,以支持IOptions/IOptionsSnapshot/IOptionsMonitor
builder.Services.Configure<AppSetting>(builder.Configuration.GetSection("AppSetting"));

//use agileconfig client
builder.Host.UseAgileConfig();

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
