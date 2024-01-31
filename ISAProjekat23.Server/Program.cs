using ISAProjekat23.Database;
using ISAProjekat23.Repository.Appointments;
using ISAProjekat23.Repository.Companies;
using ISAProjekat23.Repository.Complaints;
using ISAProjekat23.Repository.Products;
using ISAProjekat23.Repository.Reservations;
using ISAProjekat23.Repository.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
builder.Services.AddScoped<ICompaniesRepository, CompaniesRepository>();
builder.Services.AddScoped<IComplaintsRepository, ComplaintsRepository>();
builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IReservationsRepository, ReservationsRepository>();

builder.Services.AddAuthentication("MyAuthScheme")
    .AddCookie("MyAuthScheme", options =>
    {
        options.LoginPath = "/Login";
        options.LogoutPath = "/Logout";
        options.AccessDeniedPath = "/AccessDenied";
    });

builder.Services.AddHttpContextAccessor();


//builder.Services.AddDbContext<DatabaseContext>(options => options.UseMySQL("server=localhost;port=3306;database=ISAProjekat;Uid=root;Pwd=asd123"));
builder.Services.AddDbContext<DatabaseContext>();

builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyHeader()
    .AllowAnyMethod()
    //.AllowAnyOrigin()
    .SetIsOriginAllowed(origin => true)
    .AllowCredentials()
);

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();

