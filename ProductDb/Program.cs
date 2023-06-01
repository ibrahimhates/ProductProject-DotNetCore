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

// IRepositoryManager ��z�lmesi i�in servis kaydi
builder.Services.ConfigureRepositoryManager();
 
// IServicesManager ��z�lmesi i�in servis kayd�
builder.Services.ConfigureServicesManager();

// Repositorylerin ��z�lmesi i�in servis kayd�
builder.Services.ConfigureRepositories();

// Servislerin ��z�lmesi i�in servis kayd�
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
