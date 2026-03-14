var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient<ITriviaApiService, TriviaApiService>();
builder.Services.AddScoped<ITriviaService, TriviaService>();
builder.Services.AddSingleton<IStorageProvider, InMemoryStorageProvider>();
builder.Services.AddScoped<ITriviaStorageService, TriviaStorageService>();

var app = builder.Build();

app.MapControllers();
app.Run();