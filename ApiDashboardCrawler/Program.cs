using ApiDashboardCrawler.models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<dbbenchdashboardContext>();


//// Configurar CORS
//builder.Services.AddCors(options =>
//{
//    var corsOrigins = builder.Configuration.GetSection("CorsOrigins").Get<string[]>();

//    options.AddDefaultPolicy(builder =>
//    {
//        foreach (var origin in corsOrigins)
//        {
//            builder.WithOrigins(origin);
//        }
        
//        builder.AllowAnyMethod()
//               .AllowAnyHeader();
//    });
//});



var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.UseCors(policy =>
{


    policy.WithOrigins("*", "http://3.145.53.73:*")
          .AllowAnyMethod()
          .AllowAnyOrigin()
          .AllowAnyHeader();
});
app.MapControllers();

app.Run("https://localhost:8080");
