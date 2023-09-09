using FrontToBack_PartialView_LoadMore;
using FrontToBack_PartialView_LoadMore.Services;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
builder.Services.Register(config);
builder.Services.AddHttpContextAccessor();

var app = builder.Build();
app.UseStaticFiles();
app.UseSession();

app.MapControllerRoute(
    "default",
    "{controller=home}/{action=index}/{id?}"

    );

//app.MapGet("/", () => "Hello World!");

app.Run();
