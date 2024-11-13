using Admin.Infrastructure;
using Microsoft.Extensions.FileProviders;
using Utilities.Model;

var builder = WebApplication.CreateBuilder(args);

var appsettingsSection = builder.Configuration.GetSection("appsettings");
builder.Services.Configure<AppSettingsModel>(appsettingsSection);

var appSettingsModel = builder.Configuration.Get<AppSettingsModel>() ?? throw new Exception("Error occured");
builder.Services.AddSingleton(appSettingsModel);

builder.AddDbContext();
builder.AddAutoMapper();
builder.RegisterService();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

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
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Uploads")),
    RequestPath = "/Uploads"
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
