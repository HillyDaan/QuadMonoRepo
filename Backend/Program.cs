var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactDevServer", policy =>
    {
        policy.WithOrigins("http://localhost:3000")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient<ITriviaApiService, TriviaApiService>();
builder.Services.AddScoped<ITriviaService, TriviaService>();
builder.Services.AddSingleton<IStorageProvider, InMemoryStorageProvider>();
builder.Services.AddScoped<ITriviaStorageService, TriviaStorageService>();


var app = builder.Build();

app.UseCors("AllowReactDevServer");

app.MapControllers();
app.Run();