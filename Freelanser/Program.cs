using BLL.Infrastructure;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DLL.Context;
using Microsoft.AspNetCore.Identity.UI.Services;
using Freelanser;
using Serilog;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);



var keyVaultEndpoint = new Uri("https://freelanservault1.vault.azure.net/");
builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

// Add services to the container.
var connectionString = builder.Configuration.GetValue(typeof(string),"DefaultConnection").ToString();
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Host.UseSerilog((hostingContext, services, configuration) => { configuration.WriteTo.File(builder.Environment.WebRootPath + "/Log.txt"); });

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var t = builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true);
ConfigureBLL.Configure(builder.Services, connectionString,t );
builder.Services.AddTransient<IEmailSender, SendGridEmailSender>();
builder.Services.AddControllersWithViews();
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddApplicationInsightsTelemetry();
builder.Services.AddApplicationInsightsTelemetry();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
