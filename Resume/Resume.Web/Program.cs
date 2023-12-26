using GoogleReCaptcha.V3;
using GoogleReCaptcha.V3.Interface;
using Microsoft.EntityFrameworkCore;
using Resume.Domain.ViewModels.Common;
using Resume.Infra.Data.Context;
using Resume.Infra.Ioc;
using System.Text.Encodings.Web;
using System.Text.Unicode;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


#region Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
#endregion



#region Services
RegisterServices(builder.Services);

#region Google Recaptcha
builder.Services.AddHttpClient<ICaptchaValidator, GoogleReCaptchaValidator>();

#endregion

#endregion


#region Encoder
builder.Services.AddSingleton<HtmlEncoder>(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.All }));

#endregion

static void RegisterServices(IServiceCollection services)
{
    DependencyContainers.RegisterServicse(services);
}





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

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();
