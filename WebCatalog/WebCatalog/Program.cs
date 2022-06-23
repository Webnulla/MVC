using Serilog;
using WebCatalog.DAL.Repository;
using WebCatalog.DAL.Repository.Interfaces;
using WebCatalog.Domain.EmailSender;
using WebCatalog.Domain.Entity;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();
Log.Information("Starting up");
try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddControllersWithViews();
    builder.Services.AddSingleton<ICatalogRepository, CatalogRepository>();
    builder.Services.AddScoped<EmailService>();
    builder.Host.UseSerilog((_, conf) => conf.WriteTo.Console());

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Server down");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}

