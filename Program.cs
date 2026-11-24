
using System.Data.Common;

var builder = WebApplication.CreateBuilder(args);

// Register MVC services
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<LabTrace.Data.DbConnection>();
builder.Services.AddScoped<LabTrace.Repositories.IComplaintRepository, LabTrace.Repositories.ComplaintRepository>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
