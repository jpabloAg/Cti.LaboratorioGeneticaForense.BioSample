using Cti.LaboratorioGeneticaForense.BioSample.Domain.Abstractions.Repositories;
using Cti.LaboratorioGeneticaForense.BioSample.Persistence;
using Cti.LaboratorioGeneticaForense.BioSample.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(config => 
    config.RegisterServicesFromAssembly(Cti.LaboratorioGeneticaForense.BioSample.Application.AssemblyReference.Assembly));

var connectionString = builder.Configuration.GetConnectionString("Database");

builder.Services.AddDbContext<ApplicationDbContext>(
    optionsBuilder => optionsBuilder.UseNpgsql(connectionString));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });


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

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("MyAllowedOrigins");

app.MapControllers();

app.Run();
