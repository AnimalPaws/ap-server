using ap_server.Entities;
using ap_server.Helpers;
using ap_server.Models.Adoption;
using ap_server.Models.Announcement;
using ap_server.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var config = new MapperConfiguration(cfg => {
    cfg.CreateMap<AnnounceCreateRequest, Announcement>().ReverseMap();
    cfg.CreateMap<AnnounceUpdateRequest, Announcement>();
    cfg.CreateMap<AdoptionCreateRequest, Adoption>().ReverseMap();
    cfg.CreateMap<AdoptionUpdateRequest, Adoption>();
});

IMapper mapper = config.CreateMapper();


// Add services to the container.
{
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
    services.AddScoped<IAnnouncementService, AnnounceService>();
    services.AddScoped<IProfileService, ProfileService>();
    services.AddScoped<IAdoptionService, AdoptionService>();

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