using AutoMapper.API.DependencyInjection;
using Domain.Constants.CorsConstants;
using Domain.Constants.EnviromentConstants;
using Domain.Middlewares;
using Infra.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDependencyInjection(configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseMiddleware<UnexpectedErrorMiddleware>();
}

app.UseHttpsRedirection();
app.UseCors(CorsPoliciesNamesConstants.CorsPolicy);
app.UseAuthorization();
app.MapControllers();

if (Environment.GetEnvironmentVariable("DOCKER_ENVIROMENT") == ContainerContants.DockerEnviroment)
    app.UseInfraSettings();

app.Run();
