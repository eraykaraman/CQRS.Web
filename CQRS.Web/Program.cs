using CQRS.Web.CQRS.Handlers;
using CQRS.Web.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
builder.Services.AddDbContext<StudentContext>(opt =>
{
    opt.UseSqlServer("server=(localdb)\\mssqllocaldb; database=StudentDb; integrated security=true;");
});

builder.Services.AddScoped<GetStudentByIdQueryHandler>();
builder.Services.AddScoped<GetStudentsQueryHandler>();
builder.Services.AddScoped<CreateStudentCommandHandler>();
builder.Services.AddScoped<RemoveStudentCommandHandler>();
builder.Services.AddScoped<UpdateStudentCommandHandler>();

var app = builder.Build();


app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
