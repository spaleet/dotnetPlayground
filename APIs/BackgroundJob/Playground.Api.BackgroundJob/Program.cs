using Hangfire;
using Playground.Api.BackgroundJob;
using Playground.Api.BackgroundJob.Db;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

var app = builder.Build();

// Initialize Db
using (var scope = app.Services.CreateScope())
{
    var initialiser = scope.ServiceProvider.GetRequiredService<AppDbContextInitializer>();
    await initialiser.InitializeAsync();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseHangfireDashboard();

app.MapControllers();
app.MapHangfireDashboard();

app.Run();
