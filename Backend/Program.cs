var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddHttpClient<ITriviaApiService, TriviaApiService>();
builder.Services.AddScoped<ITriviaService, TriviaService>();


var app = builder.Build();

app.MapControllers();
app.Run();