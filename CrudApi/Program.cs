using CrudApi.DB;
using CrudApi.Interface;
using CrudApi.Repository;
using Microsoft.EntityFrameworkCore;
using CrudApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProdutoContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddCors();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.AddConsole();
builder.Services.AddScoped<IGenericRepository<Produto>, ProdutoRepository>();
builder.Services.AddScoped<ProdutoRepository>();
builder.Services.AddControllers();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}
app.UseAuthorization();
app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.MapControllers(); 
app.UseHttpsRedirection();
app.Run();
