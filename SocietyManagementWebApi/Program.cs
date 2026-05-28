using Application.Helper;
using Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi; 
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var ram = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<MissionEducationDbContext>(
  options => options.UseSqlServer(ram)
    );
builder.Services.AddLogging(logingBuilder =>
{
    logingBuilder.ClearProviders();


});

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "EduAuthServer",
            ValidAudience = "EduUsers",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345678901234567890"))
        };
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                //PREVENT OPTIONS FROM AUTH
                if (context.HttpContext.Request.Method == "OPTIONS")
                {
                    context.NoResult();
                }
                return Task.CompletedTask;
            }
        };
    });


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
    
});

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MissionEducation App", Version = "v1" });
    // Customizing Swagger document
    c.CustomOperationIds(apiDesc =>
        apiDesc.TryGetMethodInfo(out MethodInfo methodInfo) ? methodInfo.Name : null);

    // Add a security definition for JWT Bearer token
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Description = "Enter 'Bearer {Token}'",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        /*Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }*/
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

 /*   c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            Array.Empty<string>()
        }
    });*/
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<UnitOfWork>();
//builder.Services.AddScoped<MissionEducationDbContext>();
builder.Services.AddHttpClient();
builder.Services.AddSignalR(); 

var app = builder.Build();
 

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(options =>
{
options.SwaggerEndpoint("/swagger/v1/swagger.json", "MissionEducation App v1");
options.RoutePrefix = string.Empty;
});
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
    app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting(); 
app.UseCors("AllowAll");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
