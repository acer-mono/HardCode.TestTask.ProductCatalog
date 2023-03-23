using HardCode.TestTask.ProductCatalog.Contracts;
using HardCode.TestTask.ProductCatalog.Extensions;
using HardCode.TestTask.ProductCatalog.Repository;
using HardCode.TestTask.ProductCatalog.Service;
using HardCode.TestTask.ProductCatalog.Service.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "HardCode.TestTask.ProductCatalog.API.xml"));
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "HardCode.TestTask.ProductCatalog.Shared.xml"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var connectionString = builder.Configuration.GetConnectionString("WebApiDatabase");
builder.Services.AddDbContext<RepositoryContext>(options => options
    .UseNpgsql(connectionString, npgsqlBuilder =>
        npgsqlBuilder.MigrationsAssembly("HardCode.TestTask.ProductCatalog.Repository")));
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

var app = builder.Build();
app.ConfigureExceptionHandler();

// Практика не из лучших, используется в демонстрационных целях
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RepositoryContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();