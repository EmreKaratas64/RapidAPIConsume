using RapidAPIConsume_BusinessLayer.Abstract;
using RapidAPIConsume_BusinessLayer.Concrete;
using RapidAPIConsume_DataAccessLayer.Abstract;
using RapidAPIConsume_DataAccessLayer.Concrete;
using RapidAPIConsume_DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>();

builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IStaffDal, EfStaffDal>();
builder.Services.AddScoped<IStaffService, StaffManager>();
builder.Services.AddScoped<IRoomDal, EfRoomDal>();
builder.Services.AddScoped<IRoomService, RoomManager>();
builder.Services.AddScoped<ITestimonialDal, EfTestimonialDal>();
builder.Services.AddScoped<ITestimonialService, TestimonialManager>();
builder.Services.AddScoped<IServiceDal, EfServiceDal>();
builder.Services.AddScoped<IServiceService, ServiceManger>();
builder.Services.AddScoped<IWorkLocationDal, EfWorkLocationDal>();
builder.Services.AddScoped<IWorkLocationService, WorkLocationManager>();
builder.Services.AddScoped<ISubscribeDal, EfSubscribeDal>();
builder.Services.AddScoped<ISubscribeService, SubscribeManager>();
builder.Services.AddScoped<IBookingDal, EfBookingDal>();
builder.Services.AddScoped<IBookingService, BookingManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IGuestDal, EfGuestDal>();
builder.Services.AddScoped<IGuestService, GuestManager>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("APICors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("APICors");
app.UseAuthorization();

app.MapControllers();

app.Run();
