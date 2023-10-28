

using Application.interfaces;
using Application.Mapper;
using Application.Models;
using Application.Reposaitry;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<Result_student_courcesContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<Result_student_courcesContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IUniteOfWork, UniteOfWork>();
builder.Services.AddScoped<IStudentRepo, StudentRepo>();
builder.Services.AddScoped<ICourcesRepo, CourseRepo>();
builder.Services.AddScoped<IResultRepo,ResultRepo >();
builder.Services.AddAutoMapper(M => M.AddProfile(new StudentProfile()));
builder.Services.AddAutoMapper(M => M.AddProfile(new CourcesProfile()));
builder.Services.AddAutoMapper(M => M.AddProfile(new ResultProfile()));




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
