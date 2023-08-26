using ISAProjekat23.Database;
using ISAProjekat23.Repository.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();  //set the allowed origin  
        });
});

builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddAuthentication("MyAuthScheme")
    .AddCookie("MyAuthScheme", options => {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Logout";
        options.AccessDeniedPath = "/AccessDenied";
    });

builder.Services.AddHttpContextAccessor();


//builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySQL("server=localhost;port=3306;database=ISAProjekat;Uid=root;Pwd=NodiDarbr3466"));
builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();

