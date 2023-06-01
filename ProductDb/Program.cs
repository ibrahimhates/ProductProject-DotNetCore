using Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddApplicationPart(typeof(PresentationLayer.AssemblyRefence).Assembly)
    .AddNewtonsoftJson(opt =>
    {
        opt.SerializerSettings.ReferenceLoopHandling =
        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEndpointsApiExplorer();

// Configure connectionString 
builder.Services.ConfigureSqlContext(builder.Configuration);

// IRepositoryManager çözülmesi için servis kaydi
builder.Services.ConfigureRepositoryManager();
 
// IServicesManager çözülmesi için servis kaydý
builder.Services.ConfigureServicesManager();

// Repositorylerin çözülmesi için servis kaydý
builder.Services.ConfigureRepositories();

// Servislerin Çözülmesi için servis kaydý
builder.Services.ConfigureServices();

var app = builder.Build();
app.ConfigureExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
