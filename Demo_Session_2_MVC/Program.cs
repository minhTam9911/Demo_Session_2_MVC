using Demo_Session_2_MVC.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<DemoService, DemoServiceImpl>();
builder.Services.AddScoped<CeculaService, CeculaServiceImpl>();
builder.Services.AddScoped<RectangService, RectangleServiceImplcs>();
builder.Services.AddScoped<ProductService, ProductServiceImpl>();
builder.Services.AddScoped<AccountService, AccountImpl>();

builder.Services.AddSession();

var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller}/{action}");

app.Run();