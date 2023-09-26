using FrontToBack_PartialView_LoadMore;
using FrontToBack_PartialView_LoadMore.Entities;
using FrontToBack_PartialView_LoadMore.Services;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
builder.Services.Register(config);
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(

      name: "areas",
      pattern: "{area:exists}/{controller=dashboard}/{action=Index}/{id?}"

);
app.MapControllerRoute(
    "default",
    "{controller=home}/{action=index}/{id?}"

    );
app.MapHub<ChatHub>("/AtillasWhatsupp");


//app.MapGet("/", () => "Hello World!");

app.Run();
