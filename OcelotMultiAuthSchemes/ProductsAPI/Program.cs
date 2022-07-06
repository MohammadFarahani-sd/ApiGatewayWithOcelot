using System;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductsAPI.Authentication;
using ProductsAPI.Authentication.Authorization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IUserContextPopulator, UserContextPopulator>();
builder.Services.AddScoped<IUserContext, UserContext>();





builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

builder.Services.AddCors(options => options.AddPolicy("AllowCors", policyBuilder =>
{
    policyBuilder.SetIsOriginAllowed(_ => true)
        .AllowCredentials()
        .AllowAnyHeader()
        .AllowAnyMethod();
}));

builder.Services.AddEndpointsApiExplorer();



var app = builder.Build();


app.UseMiddleware<JwtMiddleware>();

app.UseCors("AllowCors");

app.UseAuthorization();



app.MapControllers();

app.Use(async (context, next) =>
{
    // Do work that can write to the Response.
    await next.Invoke();
    // Do logging or other work that doesn't write to the Response.
});

app.Run();

public partial class Program
{
}