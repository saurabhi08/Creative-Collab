using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using MindAndMarket.Filters;
using MindAndMarket.Data;
using MindAndMarket.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (System.IO.File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
    }

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Mind and Market API",
        Version = "v1",
        Description = "API documentation with XML summaries for all endpoints."
    });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "X-Admin-Key",
        Type = SecuritySchemeType.ApiKey,
        In = ParameterLocation.Header,
        Description = "Provide the admin API key in the X-Admin-Key header to access admin-only endpoints",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "AdminApiKey"
        }
    };

    options.AddSecurityDefinition("AdminApiKey", securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { securityScheme, Array.Empty<string>() }
    });
});

// Add DbContext + Identity
builder.Services.AddDbContext<MindAndMarketContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services
    .AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<MindAndMarketContext>()
    .AddDefaultTokenProviders();

// Add Services
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAisleService, AisleService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IReadingSpotService, ReadingSpotService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IDataSeedService, DataSeedService>();
builder.Services.AddScoped<AdminOnlyFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapDefaultControllerRoute();

app.Run(); 