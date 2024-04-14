using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Product.Api.Applications.Seedworls;
using Product.Doamin.AggregateModels.ProductAggrerate;
using Product.Doamin.SeedWork;
using Product.Infrastucture;
using Product.Infrastucture.Repositories;
using Product.Infrastucture.Seedworks;
using System.Reflection;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        try
        {
            RegisterServices(builder);
            var app = builder.Build();
            await ConfigurePipeline(app);
            app.Run();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private static void RegisterServices(WebApplicationBuilder builder)
    {
        IConfiguration configuration = builder.Configuration;

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = Assembly.GetEntryAssembly().GetName().Name, Version = "v1" });
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme.",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Scheme = "bearer",
                Type = SecuritySchemeType.Http,
                BearerFormat = "JWT"
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference {Type = ReferenceType.SecurityScheme, Id = "Bearer"}
                    },
                    new List<string>()
                }
            });
            c.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Product.Api.xml"));
        });
        builder.Services.AddTransient<ProductContext>();
        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        string mySqlConnectionStr = configuration.GetSection("MySqlConnection:Main").Value;
        builder.Services.AddDbContext<ProductContext>(options =>
            options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr), options => options.SchemaBehavior(MySqlSchemaBehavior.Ignore))
        );

        builder.Services.AddScoped<IUnitOfWorkDapper>((context) =>
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            return new UnitOfWork(new MySqlConnection(configuration.GetSection("MySqlConnection:Main").Value),
                new MySqlConnection(configuration.GetConnectionString("MYSqlConnection:Secondary")));
        });

        var assemblyNames = Assembly.GetExecutingAssembly().GetReferencedAssemblies();
        var profileAssemblies = assemblyNames.Select(assenbly => Assembly.Load(assenbly)).ToList();
        profileAssemblies.Add(Assembly.GetExecutingAssembly());
        builder.Services.AddAutoMapper(profileAssemblies);

        builder.Services.AddScoped<IProductRepository, ProductRepository>();
        builder.Services.AddScoped<IProductQuery, ProductQuery>();
    }

    private static async Task ConfigurePipeline(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
    }
}