using JobRecruitmentApp.Appcodes;
using JobRecruitmentApp.Interface;
using JobRecruitmentApp.MappingProfiles;
using JobRecruitmentApp.Models;
using JobRecruitmentApp.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<JobContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IJobRepository, JobRepository>();
builder.Services.AddAutoMapper(typeof(JobProfile));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<JobContext>();

    if (!context.Jobs.Any()) // Nếu chưa có dữ liệu, thêm mới
    {
        context.Jobs.AddRange(new List<Job>
        {
            new Job { Title = "Backend Developer", Company = "Google", Salary = 1100 },
            new Job { Title = "Frontend Developer", Company = "Facebook", Salary = 1200 },
            new Job { Title = "Data Scientist", Company = "Amazon", Salary = 1300 }
        });

        context.SaveChanges();
    }
}
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/hello")
    {
        await context.Response.WriteAsync("Xin chào từ Middleware!");
    }
    else
    {
        await next(); // Chuyển tiếp request
    }
});

app.Run();
