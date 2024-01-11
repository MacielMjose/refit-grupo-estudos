using Refit;
using RefitGrupoDeEstudos.Interfaces;
using RefitGrupoDeEstudos.Interfaces.External;
using RefitGrupoDeEstudos.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Add service with factory
builder.Services.AddHttpClient<IAdviceServiceApi, AdviceServiceApi>
(
    h => h.BaseAddress = new Uri("https://api.adviceslip.com/advice")
);

//Add Refit Interfaces
builder.Services.AddRefitClient<IAdviceApi>().ConfigureHttpClient(c =>
{
    c.BaseAddress = new Uri("https://api.adviceslip.com/advice");
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
