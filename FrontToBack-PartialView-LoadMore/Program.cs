using FrontToBack_PartialView_LoadMore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var config = builder.Configuration;
builder.Services.Register(config);



var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(
    "default",
    "{controller=home}/{action=index}/{id?}"

    );

//app.MapGet("/", () => "Hello World!");

app.Run();
