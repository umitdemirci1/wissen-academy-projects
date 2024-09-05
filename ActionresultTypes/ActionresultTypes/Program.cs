/*
 * Action kýsýtlarý
 * 1 - Public olmalý
 * 2 - static olamazlar
 * 3 - ref ya da out paametre alamazlar
 * 
 * Action Geri Dönüþ Tipleri
 * 1 - ViewResult
 * 2 - PartialViewResult
 * 3 - ContentResult
 * 4 - EmptyResult
 * 5 - JsonResult
 * 6 - StatusCodeResult
 * 7 - FileResult
 * 8 - RedirectResult
 * 9 - RedirectToActionResult
 * 10 - JavaScriptResult MVC 5 ve öncesi Core da yok
 */


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
