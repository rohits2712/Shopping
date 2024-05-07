var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var configuration = builder.Configuration;

builder.Services.AddHttpClient("ShoppingAPIClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5000");  //shopping.api url , named parameter is the base address
    client.BaseAddress = new Uri(configuration["ShoppingAPIUrl"]);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
