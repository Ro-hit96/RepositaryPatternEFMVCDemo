using Microsoft.EntityFrameworkCore;
using RepositaryPatternEFMVCDemo.Data;
using RepositaryPatternEFMVCDemo.Repositary;
using RepositaryPatternEFMVCDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//To read connection string from appsetting.json file
var connectionString = builder.Configuration.GetConnectionString("defaultConection");
//assign the connection string to ApplicationDbcontext class for CRUD
builder.Services.AddDbContext<ApplicationDbContext>(op => op.UseSqlServer(connectionString));

//inject the services in project
builder.Services.AddScoped<IBookRepository,BookRepository>();
builder.Services.AddScoped<IBookService,BookService>();
//Inject the service student project
builder.Services.AddScoped<IStudentRepository,StudentRepository>();
builder.Services.AddScoped<IstudentService,StudentService>();
//Inject the service Employyee project
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();


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
