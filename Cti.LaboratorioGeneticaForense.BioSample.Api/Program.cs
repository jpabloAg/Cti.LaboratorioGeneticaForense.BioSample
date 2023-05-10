using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Persistence;
using Cti.LaboratorioGeneticaForense.BioSample.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(op =>
        op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IMuestradanteRepository, MuestradanteRepository>();
builder.Services.AddTransient<IMuestraRepository, MuestraRepository>();
builder.Services.AddTransient<IDesaparecidoRepository, DesaparecidoRepository>();
builder.Services.AddTransient<IMuestraDesaparecidoRepository, MuestraDesaparecidoRepository>();
builder.Services.AddTransient<IAnexoRepository, AnexoRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(config => 
    config.RegisterServicesFromAssembly(Cti.LaboratorioGeneticaForense.BioSample.Application.AssemblyReference.Assembly));

var connectionString = builder.Configuration.GetConnectionString("Database");

builder.Services.AddDbContext<ApplicationDbContext>(
    optionsBuilder => optionsBuilder.UseNpgsql(connectionString));

builder.Services.AddCors(options =>
{

    options.AddPolicy("MyAllowedOrigins",
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("MyAllowedOrigins");

app.MapControllers();

app.Run();
