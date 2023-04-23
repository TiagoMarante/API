using System.Text;
using Catalog.Interfaces.RepositoryInterfaces;
using Catalog.Interfaces.ServiceInterfaces;
using Catalog.Middlewares;
using Catalog.Repositories.Clients;
using Catalog.Repositories.Products;
using Catalog.Services;
using Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var policyName = "_myAllowSpecificOrigins";


// Add services to the container.
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDb"));

// Dependency Injection
// ------------------------------ Client ------------------------------------------//
builder.Services.AddSingleton<IClientServices, ClientService>();
builder.Services.AddSingleton<IClientRepository, ClientsInMemRepository>();
// ------------------------------ Zone ------------------------------------------//
builder.Services.AddSingleton<IZoneServices, ZoneService>();
builder.Services.AddSingleton<IZonesRepository, ZonesInMemRepository>();
// ------------------------------ Products ------------------------------------------//
builder.Services.AddSingleton<IProductServices, ProductService>();
builder.Services.AddSingleton<IProductRepository, ProductsInMemRepository>();
// ------------------------------ Products ------------------------------------------//
builder.Services.AddSingleton<IOrderServices, OrdersService>();
builder.Services.AddSingleton<IOrdersRepository, OrdersInMemRepository>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme(\"bearer{token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value ??
                          throw new InvalidOperationException())),
            ValidateIssuer = false,
            ValidateAudience = false
        };

        options.Events = TokenHandling.CheckIfValid();
    });


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
        corsPolicyBuilder =>
        {
            corsPolicyBuilder
                .WithOrigins("http://localhost:3000", "https://casadosdocesgestao.pt")
                //.AllowAnyOrigin()
                .WithMethods("GET")
                .AllowAnyHeader();
        });
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(policyName);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();