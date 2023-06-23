using HBS.Core;
using HBS.Data;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
{
    services.AddCore(builder.Configuration);
    services.AddData(builder.Configuration);
    services.AddControllers();
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();
    services.AddHealthChecks();
}

var app = builder.Build();
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseExceptionHandler("/error");
    app.UseHealthChecks("/health");
    app.MapControllers();
}

app.Run();
