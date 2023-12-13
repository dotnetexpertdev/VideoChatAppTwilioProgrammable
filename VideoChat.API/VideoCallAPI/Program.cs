using Microsoft.AspNetCore;
using VideoCallAPI.Hubs;
using VideoCallAPI.Options;
using VideoCallAPI.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.Configure<TwilioSettings>(
    settings =>
    {
        //settings.AccountSid = "ACbde62746afb776ac7bb34e63a50202aa";// Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
        settings.AccountSid = "AC24f47c526b78b0b888a81594ad5e651b";// Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
        settings.ApiSecret = "9E3AJ5Qd5wKh0crUVIxe3mBb0iwwXRNm";// Environment.GetEnvironmentVariable("TWILIO_API_SECRET");
        settings.ApiKey = "SK96b05a5850bfc2b548a6562a939bb539";// Environment.GetEnvironmentVariable("TWILIO_API_KEY");
    })
    .AddTransient<IVideoService, VideoService>();
    //.AddSpaStaticFiles(config => config.RootPath = "ClientApp/dist");

builder.Services.AddSignalR();

var allowedOrigin = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("myAppCors", policy =>
    {
        policy.WithOrigins(allowedOrigin)
                .AllowAnyHeader()
                .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.MapHub<NotificationHub>("/notificationHub");

app.UseCors("myAppCors");

//app.UseEndpoints(
//    endpoints =>
//    {
//        endpoints.MapHub<NotificationHub>("/notificationHub");
//    });

app.Run();
