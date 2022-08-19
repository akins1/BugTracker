using Auth0.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using BugTracker.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddAuth0WebAppAuthentication(options =>
{
    options.Domain = builder.Configuration["Auth0:Domain"];
    options.ClientId = builder.Configuration["Auth0:ClientId"];
    //options.ClientSecret = builder.Configuration["Auth0:ClientSecret"]; ////
});
    /*.WithAccessToken(options =>
    {
        options.Audience = builder.Configuration["Auth0:Audience"];
    });*/

builder.Services.AddDbContext<BugTrackerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

/*app.MapControllerRoute(name: "project",
                pattern: "{controller}/{projectId? : int}/",
                defaults: new { controller = "Project", action = "Projects", projectId="" });
*/
/*app.MapControllerRoute(name: "tickets",
                pattern: "{controller}/{projectId? : int}/tickets/{ticketId? : int}",
                defaults: new { controller = "Project", action = "TicketView", projectId="" });
*/
app.Run();
