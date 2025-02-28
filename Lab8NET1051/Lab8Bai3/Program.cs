using Lab8Bai3.Services;

var builder = WebApplication.CreateBuilder(args);

// ✅ Đăng ký dịch vụ trước khi build
builder.Services.AddHttpClient<ReservationService>();
builder.Services.AddControllersWithViews();

var app = builder.Build(); // 🔥 Build ứng dụng sau khi đăng ký xong dịch vụ

// ✅ Cấu hình Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// ✅ Định tuyến mặc định
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Reservation}/{action=Index}/{id?}");

app.Run();
