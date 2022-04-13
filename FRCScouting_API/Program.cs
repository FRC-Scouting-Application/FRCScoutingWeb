using FRCScouting_API.Models;
using FRCScouting_API.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;

/***** Services *****/
var builder = WebApplication.CreateBuilder(args);

// Get Api Settings
var configuration = builder.Configuration;
builder.Services.Configure<ApiSettings>(configuration.GetSection("Api"));

// Bind an instance of our settings to a local variable for referencing in this method
var apiSettings = new ApiSettings();
configuration.GetSection("Api").Bind(apiSettings);

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

// TBA API
builder.Services.AddHttpClient<ITBAService, TBAService>();

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
var swagger_title = "FRC Scoting API";
var swagger_version = "v0.1.0";
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(swagger_version, new()
    {
        Title = swagger_title,
        Version = swagger_version,
        Description = "API for connecting the web portal and android app together with data"
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
    c.SwaggerEndpoint($"/swagger/{swagger_version}/swagger.json", swagger_title);
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/");
    endpoints.MapControllers();
});

app.Run();
