using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using PedidoAPI.Application.Interfaces;
using PedidoAPI.Application.Services;
using PedidoAPI.Domain.Interfaces;
using PedidoAPI.Infrastructure.Db;
using PedidoAPI.Infrastructure.Repositorys;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PedidoContext>(Options =>
Options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));

builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IPedidosService, PedidoService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


