using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnlineShop.Db;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repository;
using OnlineShopWebApi.Middleware;
using ReviewClientWebApi.Interfaces;
using ReviewClientWebApi.Models;
using ReviewClientWebApi.Service;
using Serilog;

try
{
    Log.Information("starting server.");
    Log.Logger = new LoggerConfiguration()
    .CreateLogger();

    var builder = WebApplication.CreateBuilder(args);

    var configuration = builder.Configuration;
    string connection = builder.Configuration.GetConnectionString("Online_Shop_Vishnyakov");

    builder.Services.AddControllers().AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
    }
    );

    builder.Host.UseSerilog((context, loggerConfiguration) =>
    {
        loggerConfiguration.ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .Enrich.WithProperty("ApplicationName", "Online Shop");
    });

    builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
    builder.Services.AddIdentity<User, IdentityRole>()
                        // устанавливаем тип хранилища - наш контекст
                        .AddEntityFrameworkStores<DatabaseContext>()
                    .AddDefaultTokenProviders();


    builder.Services.Configure<IdentityOptions>(options =>
    {
        options.User.RequireUniqueEmail = true;
        options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    });

    // Add services to the container.


    builder.Services.AddScoped<ProductService>();
    builder.Services.AddScoped<ImagesProvider>();
    builder.Services.AddScoped<UserService>();
    builder.Services.AddScoped<ReviewService>();

    builder.Services.AddTransient<IAccountService, AccountService>();
    builder.Services.AddTransient<IProductsRepository, ProductDbRepository>();
    builder.Services.AddTransient<ImagesProvider>();
    builder.Services.AddTransient<IReviewDbRepository, ReviewDbRepository>();
    builder.Services.AddScoped<IRatingDbRepository, RatingDbRepository>();

    builder.Services.AddTransient<IUserRepository, UserDbRepository>();
    builder.Services.AddHttpContextAccessor();

    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Online shop API",
            Description = "Online shop ASP.NET Core Web API"

        });

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",

        });

        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
        {
                                      new OpenApiSecurityScheme
                          {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}

        }
        });
    });

    builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(configuration["Jwt:Key"]))
        };
    });

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI((c =>
        {
            c.ConfigObject.AdditionalItems.Add("persistAuthorization", "true");
        }));

    }

    app.UseHttpsRedirection();
    app.UseAuthentication();
    app.UseAuthorization();

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        dbContext.Database.Migrate();
    }
    app.MapControllerRoute(

            name: "MyArea",
            pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

    app.MapControllerRoute(

        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    using var serviceScope = app.Services.CreateScope();
    var services = serviceScope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    IdentityInitializer.Initialize(userManager, roleManager);
    app.UseMiddleware<JWTMiddleware>();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}
