using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Db;
using OnlineShop.Db.Interfaces;
using OnlineShop.Db.Models;
using OnlineShop.Db.Repository;
using OnlineShopWebApp.Helpers;
using OnlineShopWebApp.Redis;
using OnlineShopWebApp.Service;
using Serilog;
using StackExchange.Redis;



try
{
    Log.Information("starting server.");
    Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();
    var builder = WebApplication.CreateBuilder(args);
    string connection = builder.Configuration.GetConnectionString("online_shop_Vishnyakov");

    builder.Host.UseSerilog((context, loggerConfiguration) =>
    {
        loggerConfiguration.ReadFrom.Configuration(context.Configuration)
        .Enrich.FromLogContext()
        .Enrich.WithProperty("ApplicationName", "Online Shop");
    });
    builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));

    var redisConfiguration = ConfigurationOptions.Parse(builder.Configuration.GetSection("Redis:ConnectionString").Value);
    redisConfiguration.AbortOnConnectFail = false;
    redisConfiguration.ConnectTimeout = 5000;

    builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
    {
        try
        {
            var multiplexer = ConnectionMultiplexer.Connect(redisConfiguration);
            multiplexer.ConnectionFailed += (sender, args) =>
            {
                Console.WriteLine($"Connection failed: {args.Exception}");
            };
            multiplexer.ErrorMessage += (sender, args) =>
            {
                Console.WriteLine($"Error message: {args.Message}");
            };
            return multiplexer;
        }
        catch (RedisConnectionException ex)
        {
            Console.WriteLine($"Redis connection error: {ex.Message}");
            throw;
        }
    });

    builder.Services.AddSingleton<RedisCacheService>();



    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddDistributedMemoryCache();

    builder.Services.AddSession(options =>
    {
        options.Cookie.Name = ".MyApp.Session";
        options.IdleTimeout = TimeSpan.FromSeconds(1200);
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
    });

    builder.Services.AddTransient<ProductService>();
    builder.Services.AddScoped<IProductsRepository, ProductDbRepository>();
    builder.Services.AddTransient<CartService>();
    builder.Services.AddScoped<ICartsRepository, CartsDbRepository>();
    builder.Services.AddTransient<OrderService>();
    builder.Services.AddScoped<IOrdersRepository, OrderRepository>();
    builder.Services.AddTransient<ComparisonService>();
    builder.Services.AddScoped<IComparisonRepository, ComparisonsDbRepository>();
    builder.Services.AddTransient<FavouriteService>();
    builder.Services.AddScoped<IFavouriteRepository, FavouriteDbRepository>();
    builder.Services.AddTransient<AuthorizationService>();
    builder.Services.AddTransient<RoleService>();
    builder.Services.AddScoped<UserService>();
    builder.Services.AddScoped<IUserRepository, UserDbRepository>();
    builder.Services.AddTransient<ImagesProvider>();
    builder.Services.AddScoped<AccountService>();
    builder.Services.AddTransient<CartItemService>();
    builder.Services.AddScoped<ICartItemsRepository, CartItemDbRepository>();
    builder.Services.AddTransient<ReviewService>();
    builder.Services.AddScoped<IReviewDbRepository, ReviewDbRepository>();
    builder.Services.AddScoped<IRatingDbRepository, RatingDbRepository>();

    // указываем тип пользователя и роли
    builder.Services.AddIdentity<User, IdentityRole>()
                    // устанавливаем тип хранилища - наш контекст
                    .AddEntityFrameworkStores<DatabaseContext>();
    builder.Services.Configure<IdentityOptions>(options =>
    {
        options.User.RequireUniqueEmail = true;
        options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
    });

    // настройка cookie
    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.ExpireTimeSpan = TimeSpan.FromHours(72);
        options.LoginPath = "/Authorization/Login";
        options.LogoutPath = "/Authorization/Logout";
        options.Cookie = new CookieBuilder
        {
            IsEssential = true
        };
    });

    builder.Services.AddMvc();

    builder.Services.AddAuthentication("Cookies");
    builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options => options.LoginPath = "/login");

    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.WriteIndented = true;
    });
    var app = builder.Build();

    app.UseSession();
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();
    app.UseStaticFiles();




    app.UseRouting();
    app.MapGet("/Logout", async (HttpContext context) =>
    {
        await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Results.Redirect("/login");
    });
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllerRoute(

        name: "MyArea",
        pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

    app.MapControllerRoute(

        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    using (var scope = app.Services.CreateScope())
    {
        var dbContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        dbContext.Database.Migrate();
    }

    using var serviceScope = app.Services.CreateScope();
    var services = serviceScope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<User>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    IdentityInitializer.Initialize(userManager, roleManager);


    app.Run();
}

catch (Exception ex)
{
    Log.Fatal(ex, "server terminated unexpectedly");
}

finally
{
    Log.CloseAndFlush();
}
