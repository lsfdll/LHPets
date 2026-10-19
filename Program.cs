var builder = WebApplication.CreateBuilder(args);

// 1. REGISTRO DE SERVIÇOS
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 2. CONFIGURAÇÃO DO PIPELINE DE REQUISIÇÕES HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Ativa a interface visual do Swagger
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Mapeia os controladores (Clientes e Pets)
app.MapControllers();

app.Run();
