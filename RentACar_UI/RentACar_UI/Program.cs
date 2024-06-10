var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Sessionu Kullanmak i�in Eklemek laz�m
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
//Sessionu Kullanmak i�in Eklemek laz�m
app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapAreaControllerRoute(
     areaName: "AdminPanel",
     name: "AdminPanel",
     pattern: "AdminPanel/{controller=Home}/{action=Index}/{id?}"
    );
app.Run();
