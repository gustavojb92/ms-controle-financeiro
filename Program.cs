using Microsoft.EntityFrameworkCore;
using ms_controle_financeiro.Data;
using ms_controle_financeiro.Domain;
using ms_controle_financeiro.Interfaces;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IUser, UserDomain>();
builder.Services.AddScoped<ILog, LogDomain>();
builder.Services.AddScoped<IInput, InputDomain>();
builder.Services.AddScoped<IOutput, OutputDomain>();


// Add services to the container.
builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("SampleDbConnection"),
       assembly => assembly.MigrationsAssembly(typeof(AppDBContext).Assembly.FullName));
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(x => x
            .AllowAnyOrigin() // Permite todas as origens
            .AllowAnyMethod() // Permite todos os métodos
            .AllowAnyHeader()) // Permite todos os cabeçalhos
            .UseAuthentication();

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
