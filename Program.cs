using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ap_server.Helpers;
using ap_server.Services;
using ap_server.Authorization;
using AutoMapper;
using ap_server.Entities.User;
using ap_server.Entities.Foundation;
using ap_server.Entities.Veterinary;
using System.Text.Json.Serialization;
using ap_server.Models.Announcement;
using ap_server.Entities;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var config = new MapperConfiguration(cfg => {
    cfg.CreateMap<CreateRequest, Announcement>().ReverseMap();
    cfg.CreateMap<UpdateRequest, Announcement>();
});

IMapper mapper = config.CreateMapper();

    var services = builder.Services;

    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();


    // DataContext
    services.AddDbContext<DataContext>(option => option.UseMySQL(builder.Configuration.GetConnectionString("APDatabase")));

    // Controllers and cors policies
    services.AddControllers().AddJsonOptions(x =>
    {
        // serialize enums as strings in api responses (e.g. Role)
        x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
    services.AddCors();
    services.AddHttpContextAccessor();
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    // Interfaces
    services.AddScoped<IAnnouncementService, AnnouncementService>();

    // AutoMapper
    services.AddSingleton(mapper);
    services.AddAutoMapper(typeof(AutoMapperProfile));

    // AppSettings configuration
    services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "AnimalPaws Auth Server");
        x.RoutePrefix = string.Empty;
    });
}

// Global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseCors(x => x
        .SetIsOriginAllowed(origin => true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();