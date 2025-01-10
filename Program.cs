using ApiDemo.Data;
using ApiDemo.Interfaces;
using ApiDemo.Services;
using Microsoft.EntityFrameworkCore;
using ApiDemo.Mapping;

var builder = WebApplication.CreateBuilder(args);


// Adiciona o AutoMapper
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddAutoMapper(typeof(TarefaProfile));

// Add services to the container.
builder.Services.AddControllers();

// Configuração do DbContext (adicione sua string de conexão aqui)
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro do serviço IUserService e sua implementação UserService
builder.Services.AddScoped<IUserService, UserService>();

// Configuração do Swagger (para documentação da API)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Middleware de autorização (caso necessário)
app.UseAuthorization();

// Mapear controllers
app.MapControllers();

app.Run();
