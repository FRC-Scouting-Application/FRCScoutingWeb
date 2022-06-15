using FRCScouting_API.Models;
using FRCScouting_API.Services;
using FRCScouting_API.Services.Interfaces;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

/***** Services *****/
var builder = WebApplication.CreateBuilder(args);

// Get Api Settings
var configuration = builder.Configuration;
builder.Services.Configure<ApiSettings>(configuration.GetSection("Api"));
builder.Services.Configure<Info>(configuration.GetSection("Info"));

// Bind an instance of our settings to a local variable for referencing in this method
var apiSettings = new ApiSettings();
var info = new Info();
configuration.GetSection("Api").Bind(apiSettings);
configuration.GetSection("Info").Bind(info);

// Sql Server connection string
var connectionString = apiSettings.ConfigurationDataContext!
    .Replace("{ConfigurationDataContextCredentials}", apiSettings.ConfigurationDataContextCredentials);

// Add DB Context
builder.Services.AddDbContext<AppDataContext>(options =>
{
    options.UseSqlServer(connectionString, options =>
    {
        options.MinBatchSize(1)
            .MaxBatchSize(100);
    })
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});
builder.Services.AddScoped<IAppDataRepository, AppDataRepository>();

// Services
builder.Services.AddHttpClient<ITBAService, TBAService>();
builder.Services.AddScoped<IUpdateService, UpdateService>();
builder.Services.AddScoped<IReportsService, ReportsService>();

// Misc
builder.Services.AddDirectoryBrowser();
builder.Services.AddMemoryCache();
builder.Services.AddHealthChecks();

// Add Controllers with settings
builder.Services.AddControllers(options =>
{
    options.SuppressOutputFormatterBuffering = true;
})
    .AddNewtonsoftJson();

// Kestrel allow syncronus io
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc($"v{info.Version}", new()
    {
        Title = info.Title,
        Version = $"v{info.Version}",
        Description = info.Description
    });  
});

// Applicaton Insights
builder.Services.AddApplicationInsightsTelemetry();


/***** APP *****/
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();
app.UseAuthorization();
app.UseHttpsRedirection();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint($"/swagger/v{info.Version}/swagger.json", info.Title);
    c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/");
    endpoints.MapControllers();
});

app.UseStaticFiles();
app.Run();
