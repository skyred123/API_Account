using Business_Logic_Layer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using DataModels;
using DataModels.Implementation;
using System.Text;
using API_Account.Configuration;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http.Features;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContextPool<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
	options.UseLoggerFactory(LoggerFactory.Create(log =>
	{
		log.AddConsole();
	}));
	options.EnableSensitiveDataLogging();
	options.EnableDetailedErrors();
	options.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var auth0Domain = builder.Configuration["Auth0:Domain"];
var auth0Audience = builder.Configuration["Auth0:ClientId"];


/*builder.Services.AddAuthentication(options =>
{
	options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
	options.Authority = $"https://{auth0Domain}/";
	options.Audience = auth0Audience;
});*/

builder.Services.Configure<FormOptions>(options =>
{
	options.MultipartBodyLengthLimit = 1024 * 1024 * 1024; // 1GB expressed in bytes
	options.ValueLengthLimit = int.MaxValue;
	options.MultipartHeadersLengthLimit = int.MaxValue;
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
	options.RequireHttpsMetadata = false;
	options.SaveToken = true;
	options.TokenValidationParameters = new TokenValidationParameters()
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidAudience = builder.Configuration["Jwt:Audience"],
		ValidIssuer = builder.Configuration["Jwt:Issuer"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
	};
});

builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddNewtonsoftJson(options =>
{
	options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
	options.SerializerSettings.ContractResolver = new DefaultContractResolver();
});

new API_Account.Configuration.ServiceConfiguration(builder.Services);
new API_Account.Configuration.ServiceConfiguration(builder.Services);


var app = builder.Build();

new DataSeeder().Initialize(app);

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

app.Run();
